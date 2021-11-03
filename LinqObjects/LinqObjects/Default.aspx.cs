using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Collections.Generic;


namespace LinqObjects
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var movies = GetMovies();
            var genres = GetGenres();

            // Paginando
            var query = (from m in movies
                        join g in genres on m.Genre equals g.ID
                        select new
                        {
                            m.Title,
                            g.Name
                        }).Skip(1).Take(2); // se salta uno y cuenta 2 desde el 2do
            
            this.GridView1.DataSource = query;
            this.GridView1.DataBind();
                      
            // Uso de count, max, min y average
            this.TotalMovies.Text = movies.Count.ToString();
            this.LongestRunTime.Text = movies.Max(m => m.RunTime).ToString();
            this.ShortestRunTime.Text = movies.Min(m => m.RunTime).ToString();
            this.AverageRunTime.Text = movies.Average(m => m.RunTime).ToString();



            /*
             Haciendo uniones
            var movies = GetMovies();
            var genres = GetGenres();

            // enlazando una clase con otra
            var query = from m in movies
                        join g in genres on m.Genre equals g.ID
                        select new
                        {
                            m.Title,
                            Genre = g.Name
                        };
             */


            /*
            Agrupamos datos con SQL
            var query = from m in movies
                        group m by m.Genre into g
                        select new
                        {
                            Genre = g.Key,
                            Count = g.Count()
                        };
              this.GridView1.DataSource = query;
              this.GridView1.DataBind();
             */

            /*
             Uso de la misma sintaxis que en SQL
             var query = from m in movies where m.Genre == 0 && m.RunTime > 92 select m;
             */

            /*
             Ordena los apellidos descendentemente, hacemos uso de un comparador
            var query = movies.OrderByDescending(m => m.Director, new LastNameComparer())
                .Select(m => new
                {
                    MovieDirector = m.Director,
                    MovieTitle = m.Title,
                    MovieGenre = m.Genre,
                });

             */

            /*
            var query = from m in movies where m.Genre is 0 select m;
            var query = from m in movies select new { m.Title, m.Genre };
            var query = from m in movies select new { movieTitle = m.Title, movieGenre = m.Genre };
            var query = from m in movies orderby m.Title descending select new { MovieTitle = m.Title, MovieGenre = m.Genre };
             */

            /*
            var query = new List<Movie>();

            foreach (var m in movies)
            {
                if (m.Genre == 0)
                    query.Add(m);
            }

            this.GridView1.DataSource = query;
            this.GridView1.DataBind();
            */


        }

        public List<Movie> GetMovies()
        {
            return new List<Movie> {
                new Movie { Title="Shrek", Director="Andrew Adamson", Genre=0, ReleaseDate=DateTime.Parse("16/05/2001"), RunTime=89 },
                new Movie { Title="Batman", Director="Tim Burton", Genre=1, ReleaseDate=DateTime.Parse("23/06/1989"), RunTime=126 },
                new Movie { Title="Fletch", Director="Michael Ritchie", Genre=0, ReleaseDate=DateTime.Parse("31/05/1985"), RunTime=96 },
                new Movie { Title="Casablanca", Director="Michael Curtiz", Genre=1, ReleaseDate=DateTime.Parse("1/01/1942"), RunTime=102 },
                new Movie { Title="Alicia", Director="Tim Burton", Genre=2, ReleaseDate=DateTime.Parse("22/03/2016"), RunTime=153 }
            };
        }

        public List<Genre> GetGenres()
        {
            return new List<Genre>
            {
                new Genre { ID=0, Name="Comedy" } ,
                new Genre { ID=1, Name="Drama" } ,
                new Genre { ID=2, Name="Action" }
            };
        }

    }
}