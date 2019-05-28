using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog20190528.Models
{
    public class Post
    {
        public int postId { get; set; }
        public string postTitle { get; set; }
        public string postDesc { get; set; }

        public int cateId { get; set; }

        public string cateName { get; set; }

        public List<Post> GetCateList { get; set; }

        public string[] CateList { get; set; }
    }
}