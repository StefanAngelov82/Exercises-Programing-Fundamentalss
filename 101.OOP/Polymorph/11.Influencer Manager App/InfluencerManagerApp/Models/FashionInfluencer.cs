using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class FashionInfluencer : Influencer
    {
        private const double ENG = 4.0;

        public FashionInfluencer(string username, int followers) : base(username, followers, ENG)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)(Followers * EngagementRate * 0.1);
        }
    }
}
