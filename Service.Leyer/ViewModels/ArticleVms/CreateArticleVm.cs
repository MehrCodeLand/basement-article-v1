using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Leyer.ViewModels.ArticleVms;

public class CreateArticleVm
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string BodyText { get; set; }
    public string Description { get; set; } = string.Empty;
}
