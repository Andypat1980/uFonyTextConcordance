using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextDocConcordance.DomainModel;
using TextDocConcordanceDTO;

namespace TextDocConcordance.IApplicationService
{
    public interface ITextConcordanceAppService
    {
        SentenceDTO GetSentencesFrom(string docText);
        IList<WordDTO> GetConcordanceWordsFrom(string docText);
    }
}
