using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace Ejercicio_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void crear_Xml(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"c:\Users\usuario123\proyects\DesApps\Práctica\Fase2\Practica9\SuperPersonalList.xml", FileMode.Create);
            XmlTextWriter w = new XmlTextWriter(fs, null);

            w.WriteStartDocument();
            w.WriteStartElement("SuperPersonalList");

            // 1er elemento
            w.WriteStartElement("Personal");
            w.WriteAttributeString("ID", "", "1");
            w.WriteAttributeString("Nombre", "", "Carlos Garcia");
            w.WriteAttributeString("Area", "", "Docencia");
            w.WriteAttributeString("Sueldo", "", "4658.00");
            w.WriteEndElement();

            // 2do elemento
            w.WriteStartElement("Personal");
            w.WriteAttributeString("ID", "", "2");
            w.WriteAttributeString("Nombre", "", "Gabriela Malaga");
            w.WriteAttributeString("Area", "", "Recursos humanos");
            w.WriteAttributeString("Sueldo", "", "3125.00");
            w.WriteEndElement();

            // 3er elemento
            w.WriteStartElement("Personal");
            w.WriteAttributeString("ID", "", "3");
            w.WriteAttributeString("Nombre", "", "Ramiro Lopez");
            w.WriteAttributeString("Area", "", "Recursos humanos");
            w.WriteAttributeString("Sueldo", "", "3125.00");
            w.WriteEndElement();

            // 4to elemento
            w.WriteStartElement("Personal");
            w.WriteAttributeString("ID", "", "4");
            w.WriteAttributeString("Nombre", "", "Sofia Delgado");
            w.WriteAttributeString("Area", "", "Investigación y desarrollo");
            w.WriteAttributeString("Sueldo", "", "6123.00");
            w.WriteEndElement();

            // 4to elemento
            w.WriteStartElement("Personal");
            w.WriteAttributeString("ID", "", "5");
            w.WriteAttributeString("Nombre", "", "Maricielo Serna");
            w.WriteAttributeString("Area", "", "Investigación y desarrollo");
            w.WriteAttributeString("Sueldo", "", "6123.00");
            w.WriteEndElement();

            w.WriteEndElement();
            w.WriteEndDocument();
            w.Close();

            sueldo_total.Text = @"File c:\Users\usuario123\proyects\DesApps\Práctica\Fase2\Practica9\SuperPersonalList.xml written successfully.";
        }
        protected void calcular_Sueldo(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"c:\Users\usuario123\proyects\DesApps\Práctica\Fase2\Practica9\SuperPersonalList.xml", FileMode.Open);
            XmlTextReader r = new XmlTextReader(fs);
            Decimal total_sueldo = 0;
            string area = DropDown_area.SelectedValue;


            while (r.Read())
            {
                if (r.NodeType == XmlNodeType.Element && r.Name == "Personal")
                {
                    Personal newPersonal = new Personal();
                    newPersonal.Sueldo = Decimal.Parse(r.GetAttribute(3));
                    newPersonal.Area = r.GetAttribute(2);

                    if (newPersonal.Area == area)
                        total_sueldo = total_sueldo + newPersonal.Sueldo;
                }
            }
            r.Close();
           
            sueldo_total.Text = total_sueldo.ToString() +  " S/.";
        }

        protected void mostrar_trabajadores_porArea(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"c:\Users\usuario123\proyects\DesApps\Práctica\Fase2\Practica9\SuperPersonalList.xml", FileMode.Open);
            XmlTextReader r = new XmlTextReader(fs);
            string area = DropDown_area.SelectedValue;

            List<Personal> personal = new List<Personal>();

            while (r.Read())
            {
                if (r.NodeType == XmlNodeType.Element && r.Name == "Personal")
                {
                    Personal newPersonal = new Personal();
                    newPersonal.ID = Int32.Parse(r.GetAttribute(0));
                    newPersonal.Nombre = r.GetAttribute(1);
                    newPersonal.Area = r.GetAttribute(2);
                    newPersonal.Sueldo = Decimal.Parse(r.GetAttribute(3));

                    if (newPersonal.Area == area)
                    {
                        personal.Add(newPersonal);
                    }
                }
            }
            r.Close();

            GridResults.DataSource = personal;
            GridResults.DataBind();
        }
    }
}