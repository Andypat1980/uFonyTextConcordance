using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextDocConcordance.DomainModel;

namespace TextDocConcordance.IDomainService
{
    public interface IConcordanceDomainServices
    {
        Sentence GetSentencesFrom(string docText);
        IList<Word> GetConcordanceWordsFrom(string docText);
    }
}
