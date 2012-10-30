using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextDocConcordance.IApplicationService;
using TextDocConcordance.DomainModel;
using TextDocConcordanceDTO;
using System.Text.RegularExpressions;
using TextDocConcordance.IDomainService;
using AutoMapper;

namespace TextDocConcordance.ApplicationService
{
    public class TextConcordanceAppService : ITextConcordanceAppService
    {
        IConcordanceDomainServices concordanceDomainService;

        public TextConcordanceAppService(IConcordanceDomainServices concordanceDomainService)
        {
            this.concordanceDomainService = concordanceDomainService;
        }

        public SentenceDTO GetSentencesFrom(string docText)
        {
            SentenceDTO sentenceDto = new SentenceDTO();
            Sentence sentence = concordanceDomainService.GetSentencesFrom(docText);

            sentenceDto = Mapper.Map<Sentence, SentenceDTO>(sentence);

            return sentenceDto;
        }

        public IList<WordDTO> GetConcordanceWordsFrom(string docText)
        {
            IList<WordDTO> concordanceWordsDto = new List<WordDTO>();
            IList<Word> concordanceWords = new List<Word>();

            concordanceWords = concordanceDomainService.GetConcordanceWordsFrom(docText);
            concordanceWordsDto = Mapper.Map<IList<Word>, IList<WordDTO>>(concordanceWords);

            return concordanceWordsDto;
        }


    }
}
