using System.ComponentModel.DataAnnotations;
using EPiServer.Personalization.VisitorGroups;

namespace EPiServerVisitorGroups.Business.Personalization
{
    public class CountryCriterionSettings : CriterionModelBase
    {
        [DojoWidget(WidgetType = "app.fields.CountriesSelectField")]
        public string Countries { get; set; }

        public override ICriterionModel Copy()
        {
            return ShallowCopy();
        }
    }
}