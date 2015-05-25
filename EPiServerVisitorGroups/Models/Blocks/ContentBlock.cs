using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiServerVisitorGroups.Models.Blocks
{
    [ContentType(DisplayName = "Content block", GUID = "60f2bf4e-b227-40ea-88fb-8fdfa21ffb65", Description = "")]
    public class ContentBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Content",
            Description = "Content",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual XhtmlString Content { get; set; }
    }
}