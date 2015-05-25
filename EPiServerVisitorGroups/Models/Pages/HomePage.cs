using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiServerVisitorGroups.Models.Pages
{
    [ContentType(DisplayName = "Home page", GUID = "2da0d990-1cc0-4dc9-9ced-ec9689958e9a", Description = "")]
    public class HomePage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Content blocks",
            Description = "Content blocks",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual ContentArea ContentBlocks { get; set; }
    }
}