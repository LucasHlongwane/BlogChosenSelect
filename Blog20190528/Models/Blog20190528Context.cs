using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog20190528.Models
{
    public class Blog20190528Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Blog20190528Context() : base("name=Blog20190528Context")
        {
        }

        public System.Data.Entity.DbSet<Blog20190528.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Blog20190528.Models.LookUp> LookUps { get; set; }

        public System.Data.Entity.DbSet<Blog20190528.Models.Post> Posts { get; set; }
    }
}
