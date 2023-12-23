using Data.Leyer.Entites;
using Data.Leyer.MyDbCont;
using Microsoft.EntityFrameworkCore;
using Service.Leyer.Repositories.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Leyer.Repositories;

public class ArticleRepository 
{
    private readonly MyDb _db;
    public ArticleRepository( MyDb db )
    {
        _db = db;
    }


    public async Task<Responses<Article>> GetAllArticle()
    {
        return new Responses<Article>();
    }
}
