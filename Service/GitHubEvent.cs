﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GitHubEvent
    {
        public string Type { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public string Repo { get; set; }
    }
}
