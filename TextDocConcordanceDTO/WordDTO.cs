using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextDocConcordanceDTO
{
    public class WordDTO
    {
        public string Words { get; set; }
        public int ConcordanceCount { get; set; }
        public string OccuranceInSentence { get; set; }
    }
}
