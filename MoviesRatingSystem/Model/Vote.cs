﻿using MoviesRatingSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRatingSystem.Model
{
    public class Vote
    {
        public Vote(dynamic token)
        {           
            GeneratedTime = token.generatedTime;
            ItemId = token.itemId;
            ItemCount = token.itemCount;
        }
      
        public DateTime GeneratedTime { get; set; }
        public long ItemId { get; set; }
        public int ItemCount { get; set; }
    }
}
