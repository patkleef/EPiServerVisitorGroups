using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiServerVisitorGroups.Models.Blocks;

namespace EPiServerVisitorGroups.Controllers.Blocks
{
    public class ContentBlockController : BlockController<ContentBlock>
    {
        public override ActionResult Index(ContentBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
