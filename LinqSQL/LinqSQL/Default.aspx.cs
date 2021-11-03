using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


// LINQ hacia SQL es una gran herramienta para usar cuando necesitamos construcciones
// rápidas de código de acceso a datos. 

namespace LinqSQL
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MoviesDataContext dc = new MoviesDataContext();
            // Remover peliculas de accion
            var query = from m in dc.Movie
                        where m.Genre == 2
                        select m;
            dc.Movie.DeleteAllOnSubmit(query);

            // Remover la pelicula fletch
            var movie = dc.Movie.Single(m => m.Title == "Fletch");
            dc.Movie.DeleteOnSubmit(movie);
            dc.SubmitChanges();

            var query2 = from m2 in dc.Movie
                         select m2;
            this.GridView1.DataSource = query2; 
            this.GridView1.DataBind();



            /* MODIFICANDO UN REEGISTRO
            MoviesDataContext dc = new MoviesDataContext();
            var movie = dc.Movie.Single(m => m.Title == "Fletch"); // Genre = 0
            movie.Genre = 1; // cambiamos Genre a 1
            dc.SubmitChanges();
            var query = from m2 in dc.Movie select m2;
            this.GridView1.DataSource = query;
            this.GridView1.DataBind();
            */



            /* INSERTANDO UN REGISTRO
            Movie m = new Movie
            {
                Title = "The Princess Bride",
                Director = "Rob Reiner",
                Genre = 0,
                ReleaseDate = DateTime.Parse("25/9/1987"),
                RunTime = 98
            };

            // Agrega un nuevo registro a la tabla
            dc.Movie.InsertOnSubmit(m);
            dc.SubmitChanges();

            // mostramos la tabla
            var query = from m2 in dc.Movie select m2;
            this.GridView1.DataSource = query;
            this.GridView1.DataBind();
            */


            /*
            Usando procedimientos Almacenados
            PA = GetGenero
            this.GridView1.DataSource = dc.GetGenero(1);
            this.GridView1.DataBind();
            */



            /*
            var query = from m in dc.Movie
                        group m by m.Genre into g
                        select new
                        {
                            Genre = g.Key,
                            Count = g.Count()
                        };
            System.Diagnostics.Debug.WriteLine(query);
            this.GridView1.DataSource = query;
            this.GridView1.DataBind();
            */
            // var query = from m in dc.Movie select m;


        }
    }
}