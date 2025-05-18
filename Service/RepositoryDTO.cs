using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RepositoryDTO
    {
        public string? Name { get; set; }
        public string Url { get; set; }
        public List<string>? Languages { get; set; }
        public DateTime? LastCommitDate { get; set; }
        public int StarsCount { get; set; }
        public int PullRequestsCount { get; set; }
    }
}