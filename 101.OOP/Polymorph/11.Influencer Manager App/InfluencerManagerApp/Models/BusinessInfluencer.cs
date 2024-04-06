using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        private const double ENG = 3.0;
        public BusinessInfluencer(string username, int followers) : base(username, followers, ENG)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)(Followers * EngagementRate * 0.15);
        }
    }
}
