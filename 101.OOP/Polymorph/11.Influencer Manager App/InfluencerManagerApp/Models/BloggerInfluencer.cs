﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        private const double ENG = 2.0;

        public BloggerInfluencer(string username, int followers) : base(username, followers, ENG)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)(Followers * EngagementRate * 0.2);
        }
    }
}
