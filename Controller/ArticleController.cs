//using blazor_gestconf.Services;
//using Microsoft.AspNetCore.Mvc;

//[Route("api/[controller]")]
//[ApiController]
//public class ArticlesController : ControllerBase
//{
//    private readonly ArticleService _articleService;

//    public ArticlesController(ArticleService articleService)
//    {
//        _articleService = articleService;
//    }

//    [HttpGet("{id}/pdf")]
//    public async Task<IActionResult> GetPdf(int id)
//    {
//        var pdf = await _articleService.GetPdfByIdAsync(id);
//        if (pdf == null)
//        {
//            return NotFound();
//        }
//        return File(pdf, "application/pdf", $"article_{id}.pdf");
//    }
//}