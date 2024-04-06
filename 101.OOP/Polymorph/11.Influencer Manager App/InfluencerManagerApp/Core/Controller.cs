using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;

        public Controller()
        {
            this.influencers = new InfluencerRepository();
            this.campaigns = new CampaignRepository();
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var inf in influencers.Models.OrderByDescending(x =>x.Income).ThenByDescending(x =>x.Followers))
            {
                sb.AppendLine(inf.ToString());

                if (inf.Participations.Count != 0)
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (var item in inf.Participations)
                    {
                        ICampaign c = campaigns.Models.FirstOrDefault(x => x.Brand == item);
                        sb.AppendLine($"--{c.ToString()}");
                    }
                }

               
                
            }

            return sb.ToString().Trim();
        }

        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = influencers.FindByName(username);
            ICampaign campaign = campaigns.FindByName(brand);

            if (influencer == null)
            {
                return String.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);
            }
            if (campaign == null)
            {
                return String.Format(OutputMessages.CampaignNotFound, brand);
            }

            if (influencer.Participations.Contains(brand))
            {
                return String.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            if (campaign.GetType().Name == nameof(ProductCampaign) && influencer.GetType().Name == nameof(BloggerInfluencer))
            {
                return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (campaign.GetType().Name == nameof(ServiceCampaign) && influencer.GetType().Name == nameof(FashionInfluencer))
            {
                return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (campaign.Budget < influencer.CalculateCampaignPrice())
            {
                return String.Format(OutputMessages.UnsufficientBudget, brand, username );
            }

            influencer.EarnFee(influencer.CalculateCampaignPrice());
            influencer.EnrollCampaign(brand);
            campaign.Engage(influencer);

            return String.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);

        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName != nameof(ProductCampaign) && typeName != nameof(ServiceCampaign))
            {
                return String.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }
            if (campaigns.Models.FirstOrDefault(x =>x.Brand == brand) != null)
            {
                return String.Format(OutputMessages.CampaignDuplicated, brand);   
            }

            ICampaign campaign;

            if (typeName == nameof(ProductCampaign))
            {
                campaign = new ProductCampaign(brand); 
            }
            else
            {
                campaign = new ServiceCampaign(brand);
            }

            campaigns.AddModel(campaign);

            return String.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string CloseCampaign(string brand)
        {
            if (campaigns.FindByName(brand) == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToClose);
            }
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign.Budget <= 10_000)
            {
                return String.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            foreach (var name in campaign.Contributors)
            {
                IInfluencer influencer = influencers.FindByName(name);
                influencer.EarnFee(2000);
                influencer.EndParticipation(brand);
            }

            campaigns.RemoveModel(campaign);

            return String.Format(OutputMessages.CampaignClosedSuccessfully, brand);

        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.FindByName(username);
            if (influencers == null)
            {
                return String.Format(OutputMessages.InfluencerNotSigned, username);
            }

            if (influencer.Participations.Count != 0)
            {
                return String.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            influencers.RemoveModel(influencer);

            return String.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string FundCampaign(string brand, double amount)
        {
            if (campaigns.FindByName(brand) == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount <= 0)
            {
                return String.Format(OutputMessages.NotPositiveFundingAmount);
            }

            ICampaign campaign = campaigns.FindByName(brand);
            campaign.Gain(amount);
            return String.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName != nameof(BusinessInfluencer) && typeName != nameof(FashionInfluencer) && typeName != nameof(BloggerInfluencer))
            {
                return String.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (influencers.Models.FirstOrDefault(x =>x.Username == username) != null)
            {
                return String.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
            }

            IInfluencer influencer;

            if (typeName == nameof(BusinessInfluencer))
            {
                influencer = new BusinessInfluencer(username, followers);
            }
            else if (typeName == nameof(FashionInfluencer))
            {
                influencer = new FashionInfluencer(username, followers);
            }
            else
            {
                influencer = new BloggerInfluencer(username, followers);
            }

            influencers.AddModel(influencer);
            return String.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);

        }
    }
}
