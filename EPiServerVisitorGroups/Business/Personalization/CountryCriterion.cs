using System;
using System.Linq;
using EPiServer.Personalization;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.Personalization.VisitorGroups.Criteria;
using Newtonsoft.Json;

namespace EPiServerVisitorGroups.Business.Personalization
{
    [VisitorGroupCriterion(
        Category = "Time and Place Criteria",
        DisplayName = "Countries",
        Description = "Check the visitor's current country")]
    public class CountryVisitorCriterion : GeographicCriterionBase<CountryCriterionSettings>
    {
        protected override bool IsMatch(IGeolocationResult location, Capabilities capabilities)
        {
            if (!string.IsNullOrEmpty(Model.Countries))
            {
                var countries = JsonConvert.DeserializeObject<string[]>(Model.Countries);

                return countries.Any(c => c.Equals(location.CountryCode, StringComparison.InvariantCultureIgnoreCase));
            }
            return false;
        }
    }
}