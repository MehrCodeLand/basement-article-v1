using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Leyer.ViewModels.ArticleVms;

public class UpdateArticleVm
{
    public int ArticleId{ get; set; }
    public string BodyText { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
