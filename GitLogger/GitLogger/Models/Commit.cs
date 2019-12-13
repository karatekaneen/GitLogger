using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogger.Models
{
    public class Commit
    {
        public string message { get; set; }
        public DateTime date { get; set; }
    }
}
