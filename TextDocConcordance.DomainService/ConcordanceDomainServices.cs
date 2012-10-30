using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextDocConcordance.IDomainService;
using TextDocConcordance.DomainModel;
using System.Text.RegularExpressions;

namespace TextDocConcordance.DomainService
{
    public class ConcordanceDomainServices : IConcordanceDomainServices
    {
        public Sentence GetSentencesFrom(string docText)
        {
            Sentence sentence = new Sentence();

            sentence.Sentences = Regex.Split(docText, @"(?<=['""A-Za-z0-9][\.\!\?])\s+(?=[A-Z])").ToList();

            //Todo : adding " " to each sentence at the end. Its not good coding style but for timebeing i have done it in this way, I need to manage it using regex
            for (int i = 0; i < sentence.Sentences.Count; i++)
            {
                sentence.Sentences[i] = " " + sentence.Sentences[i] + " ";
            }

            return sentence;
        }

        public IList<Word> GetConcordanceWordsFrom(string docText)
        {
            IList<Word> concordanceWords = new List<Word>();

            var wordsInDocText = (from word in docText.Split()
                                  orderby word
                                  select word).ToList();

            concordanceWords = (from word in wordsInDocText
                                group word by word into g
                                select new Word
                                {
                                    Words = " " + g.Key + " ",
                                    ConcordanceCount = g.Count()
                                }).ToList();

            

            //If ConcordanceWords exist then need to loop for each word in sentances and feelup the occurance of word in sentance
            if (concordanceWords != null && concordanceWords.Count>0)
            {
                Sentence sentence = GetSentencesFrom(docText);
                string searchWord;
                if (sentence != null && sentence.Sentences.Count > 0)
                {
                    for (int i = 0; i < concordanceWords.Count; i++)
                    {
                        searchWord = concordanceWords[i].Words.ToString();
                        string OccuranceInSentence = concordanceWords[i].OccuranceInSentence;
                        for (int j = 0; j < sentence.Sentences.Count; j++)
                        {
                            findWordInSentence(j + 1, sentence.Sentences[j].ToString(), searchWord, ref OccuranceInSentence, 0, sentence.Sentences[j].Length+1);
                        }
                        if (OccuranceInSentence != null && OccuranceInSentence.Length > 0)
                        {
                            concordanceWords[i].OccuranceInSentence = OccuranceInSentence.Substring(0, OccuranceInSentence.Length - 1);
                        }
                    }
                    
                }
            }

            return concordanceWords;
        }

        private void findWordInSentence(int sentenceNo, string source,string searchWord, ref string OccuranceInSentence, int startIndex, int endIndex)
        {
            int searchWordIndex = source.IndexOf(searchWord,startIndex);
            if (searchWordIndex != -1 && searchWordIndex < endIndex - searchWord.Length)
            {
                OccuranceInSentence += sentenceNo.ToString() + ",";
                startIndex = searchWordIndex+searchWord.Length;
                findWordInSentence(sentenceNo, source, searchWord, ref OccuranceInSentence, startIndex, endIndex);
            }
            else if (searchWordIndex != -1)
            {
                OccuranceInSentence = sentenceNo.ToString();
            }
        }
    }
}
