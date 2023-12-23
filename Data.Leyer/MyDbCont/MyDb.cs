using Data.Leyer.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Leyer.MyDbCont;

public class MyDb : DbContext
{
    public MyDb( DbContextOptions<MyDb> options ) : base( options )
    {
        
    }

    public DbSet<Article> Articles { get; set; }
}
