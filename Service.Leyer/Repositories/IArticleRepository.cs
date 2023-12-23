using Data.Leyer.Entites;
using Service.Leyer.Structs;
using Service.Leyer.ViewModels.ArticleVms;

namespace Service.Leyer.Repositories;

public interface IArticleRepository
{
    Task<Responses<Article>> CreateArticle(CreateArticleVm articleVm);
    Task<Responses<Article>> DeleteArticle(int articleId);
    Task<Responses<Article>> GetAllArticle();
    Task<Responses<Article>> GetArticle(int id);
    Task<Responses<Article>> UpdateArticle(UpdateArticleVm updateArticle);
}