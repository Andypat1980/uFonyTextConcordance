using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextDocConcordance.DomainModel
{
    public class Word
    {
        //public int WordId { get; set; }
        //public int SentenceId { get; set; }
        //public Sentence sentence { get; set; }
        public string Words { get; set; }
        public int ConcordanceCount { get; set; }
        public string OccuranceInSentence { get; set; }
    }
}
