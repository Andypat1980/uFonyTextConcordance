using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextDocConcordance.DomainModel
{
    public class Document
    {
        public virtual int DocumentId { get; set; }
        public virtual string DocumentType { get; set; }
        public virtual string DocumentName { get; set; }

        public virtual List<Sentence> sentences { get; set; }
    }
}
