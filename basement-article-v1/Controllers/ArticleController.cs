using Data.Leyer.MyDbCont;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Leyer.Repositories;
using Service.Leyer.ViewModels.ArticleVms;

namespace basement_article_v1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleController : ControllerBase
{
    private readonly IArticleRepository _articleRepo;
    public ArticleController( IArticleRepository article )
    {
        _articleRepo = article;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllArtilce()
    {
        var responses = await _articleRepo.GetAllArticle();
        if(responses.HasError)
            return NotFound();


        return Ok(responses);
    }

    [HttpGet]
    [Route("{articleId}")]
    public async Task<IActionResult> GetArticle( int articleId)
    {
        var responses = await _articleRepo.GetArticle(articleId);
        if(responses.HasError)
            return NotFound();

        return Ok(responses);
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle( CreateArticleVm articleVm)
    {
        var responses = await _articleRepo.CreateArticle(articleVm);
        if(responses.HasError )
            return NotFound(responses);

        return Ok(responses);
    }

    [HttpDelete]
    [Route("{articleId}")]
    public async Task<IActionResult> DeleteArticle(int articleId)
    {
        var responses = await _articleRepo.DeleteArticle(articleId);
        if(responses.HasError)
            return NotFound();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateArticle(UpdateArticleVm updateArticle)
    {
        var responses = await _articleRepo.UpdateArticle(updateArticle);
        if(responses.HasError) return NotFound();

        return Ok();
    }
}
