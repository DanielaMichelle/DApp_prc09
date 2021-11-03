using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace LinqObjects
{
    public class LastNameComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var director1LastName = x.Substring(x.LastIndexOf(' '));
            var director2LastName = y.Substring(y.LastIndexOf(' '));
            return director1LastName.CompareTo(director2LastName);
        }
    }
}