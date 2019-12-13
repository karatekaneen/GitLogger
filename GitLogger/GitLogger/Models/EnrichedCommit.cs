using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogger.Models
{
    public class EnrichedCommit
    {
        public EnrichedCommit(Commit commit, Repos repo)
        {
            this.message = commit.message;
            this.date = commit.date;
            this.repoName = repo.name;
        }

        public string message { get; set; }
        public DateTime date { get; set; }

        public string repoName { get; set; }
    }

}
