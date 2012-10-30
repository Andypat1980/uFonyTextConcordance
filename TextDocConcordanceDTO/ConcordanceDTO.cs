using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextDocConcordanceDTO
{
    public class ConcordanceDTO
    {
        public string DocText { get; set; }
        public IList<WordDTO> Words { get; set; }
    }
}
