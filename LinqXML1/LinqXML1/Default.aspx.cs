using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// agregar
//using System.Linq;
using System.Xml.Linq;

namespace LinqXML1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            //USANDO DATOS XML
            var query = from m in XElement.Load(MapPath("Movies.xml")).Elements("Movie")
                        join g in XElement.Load(MapPath("Genres.xml")).Elements("Genre")
                        on (int)m.Element("Genre") equals (int)g.Element("ID")
                        select new
                        {
                            Title = (string)m.Element("Title"),
                            Director = (string)m.Element("Director"),
                            Genre = (string)g.Element("Name"),
                            //ReleaseDate = (DateTime)m.Element("ReleaseDate"),
                            RunTime = (int)m.Element("RunTime")
                        };

            this.GridView1.DataSource = query;
            this.GridView1.DataBind();
            

            // ===========================================================================

            /*  LINK HACIA XML
          
            var query = from m in XElement.Load(MapPath("Movies.xml")).Elements("Movie")
                        select new Movie
                        {
                            Title = (string)m.Element("Title"),
                            Director = (string)m.Element("Director"),
                            Genre = (int)m.Element("Genre"),
                            //ReleaseDate = (DateTime)m.Element("ReleaseDate"),
                            RunTime = (int)m.Element("RunTime")
                        };
            this.GridView1.DataSource = query;
            this.GridView1.DataBind();
            */
        }
    }
}