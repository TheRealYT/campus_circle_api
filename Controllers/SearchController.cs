using campus_circle_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace campus_circle_api.Controllers;

[ApiController]
[Route("search")]
public class SearchController : ControllerBase
{
    [HttpPost(Name = "search")]
    public ActionResult<IEnumerable<SearchResult>> Search(string q)
    {
        return new[] { new SearchResult("/home", "Home", "Info", "/channel") };
    }
}