using Data.Leyer.Entites;
using Data.Leyer.MyDbCont;
using Microsoft.EntityFrameworkCore;
using Service.Leyer.Structs;
using Service.Leyer.ViewModels.ArticleVms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Leyer.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly MyDb _db;
    public ArticleRepository(MyDb db)
    {
        _db = db;
    }

    public async Task<Responses<Article>> GetAllArticle()
    {
        var articles = await _db.Articles.ToListAsync();
        if (articles.Count <= 0)
            return new Responses<Article>()
            {
                HasError = true,
                ErrorMessage = ErrorHandle.NoDataExist
            };

        return new Responses<Article>()
        {
            Data = articles,
        };
    }
    public async Task<Responses<Article>> GetArticle(int id)
    {
        var article = await _db.Articles.FirstOrDefaultAsync(x => x.ArticleId == id);
        if (article == null)
            return new Responses<Article>()
            {
                HasError = true,
                ErrorMessage = ErrorHandle.NoDataExist
            };

        return new Responses<Article>() { Data = (IEnumerable<Article>)article };
    }
    public async Task<Responses<Article>> DeleteArticle(int articleId)
    {
        _db.Articles.Remove(
            await _db.Articles.FirstOrDefaultAsync(x => x.ArticleId == articleId)
            );
        Save();

        if (await _db.Articles.AnyAsync(x => x.ArticleId == articleId))
        {
            return new Responses<Article>()
            {
                HasError = true,
                ErrorMessage = ErrorHandle.NotNow
            };
        }

        return new Responses<Article>();
    }
    public async Task<Responses<Article>> CreateArticle(CreateArticleVm articleVm)
    {
        if (await _db.Articles.AnyAsync(x => x.Title == articleVm.Title.ToUpper()))
            return new Responses<Article>()
            {
                HasError = true,
                ErrorMessage = ErrorHandle.DuplicateData
            };

        var artilce = new Article()
        {
            Title = articleVm.Title.ToUpper(),
            BodyText = articleVm.BodyText,
            Description = articleVm.Description,
        };

        var result = _db.Articles.Add(artilce);
        Save();

        return new Responses<Article>();
    }
    public async Task<Responses<Article>> UpdateArticle(UpdateArticleVm updateArticle)
    {
        var oldArticle = await _db.Articles.FirstOrDefaultAsync(x => x.ArticleId == updateArticle.ArticleId);
        if (oldArticle == null)
            return new Responses<Article>()
            {
                HasError = true,
                ErrorMessage = ErrorHandle.NoDataExist
            };

        oldArticle.Title = updateArticle.Title.ToUpper();
        oldArticle.BodyText = updateArticle.BodyText;
        oldArticle.Description = updateArticle.Description;

        _db.Articles.Update(oldArticle);
        Save();

        return new Responses<Article>();
    }

    private void Save()
    {
        _db.SaveChanges();
    }
}
