using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog20190528.Models
{
    public class LookUp
    {
        [Key]
        public int lookupId { get; set; }
        [ForeignKey("Category")]
        public int catRef { get; set; }
        [ForeignKey("Post")]
        public int postRef { get; set; }

        public virtual Category Category { get; set; }
        public virtual Post Post { get; set; }
    }
}