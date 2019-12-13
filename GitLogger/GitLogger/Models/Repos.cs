using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogger.Models
{
    public class Repos
    {
        public string name { get; set; }
        public List<Commit> commits { get; set; }
    }
}
