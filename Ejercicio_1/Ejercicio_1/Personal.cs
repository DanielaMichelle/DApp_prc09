using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio_1
{
    public class Personal
    {
        private int id;
        private string nombre;
        private string area;
        private decimal sueldo;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Area
        {
            get { return area; }
            set { area = value; }
        }
        public decimal Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }
    }
}