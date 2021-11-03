using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinqObjects
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Genre { get; set; }
        public int RunTime { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

