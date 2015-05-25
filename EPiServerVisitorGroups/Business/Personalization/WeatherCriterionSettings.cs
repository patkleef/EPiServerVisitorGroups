using System.ComponentModel.DataAnnotations;
using EPiServer.Personalization.VisitorGroups;

namespace EPiServerVisitorGroups.Business.Personalization
{
    public class Weather1CriterionSettings : CriterionModelBase
    {
        [Required]
        public int MinTempature { get; set; }

        [Required]
        public int MaxTempature { get; set; }

        public override ICriterionModel Copy()
        {
            return ShallowCopy();
        }
    }
}