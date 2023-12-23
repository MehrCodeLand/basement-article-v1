using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Leyer.Entites;

public class Article
{
    [Key]
    public int ArticleId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;

}
