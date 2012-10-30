using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextDocConcordance.DomainModel
{
    public class Sentence
    {
        //public int SentenceId { get; set; }
        //public int DocumentId { get; set; }
        //public Document document { get; set; }
        public List<string> Sentences { get; set; }

        //public virtual List<Word> words { get; set; }
    }
}
