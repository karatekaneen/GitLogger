using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogger.Models
{
    public class User
    {
        public string login { get; set; }
        public int id { get; set; }
        public string avatar_url { get; set; }
        public List<Repos> repos { get; set; }
    }
}
