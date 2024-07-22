using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacionesweb.Capa_Logica;
using System.Configuration;

namespace Votacionesweb.CapaVistas
{
    public partial class RegistroCandidatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarPartido();
            }

        }
        protected void LlenarPartido()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Select IDPartido, NombrePartido from Partidos", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);


                            DataTable dtModified = new DataTable();
                            dtModified.Columns.Add("IDPartido");
                            dtModified.Columns.Add("TipoYDescripcion", typeof(string));
                            dtModified.Rows.Add("", "Seleccione un partido");


                            foreach (DataRow row in dt.Rows)
                            {
                                string idpartido = row["IDPartido"].ToString();
                                string Nombre = row["NombrePartido"].ToString();
                                string tipoYDescripcion = $"ID: {idpartido} - Nombre: {Nombre}";
                                dtModified.Rows.Add(idpartido, tipoYDescripcion);
                            }
                            ddlPartido.DataSource = dtModified;
                            ddlPartido.DataTextField = "TipoYDescripcion";
                            ddlPartido.DataValueField = "IDPartido";
                            ddlPartido.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CandidatosLogica candidatosLogica = new CandidatosLogica();
            int resultado = candidatosLogica.AgregarUser(txtNombre.Text, txtApellido.Text, txtNumTelf.Text, txtPlataforma.Text, ddlPartido.SelectedValue);

            if (resultado > 0)
            {
                Alertas("Candidato agregado exitosamente.");
                LimpiarCampos();
            }
            else if (resultado == -2)
            {
                Alertas("Ya existe un candidato con el mismo ID de partido. Por favor, seleccione otro.");
            }
            else
            {
                Alertas("Ocurrió un error al agregar el candidato.");
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNumTelf.Text = string.Empty;
            txtPlataforma.Text = string.Empty;
            ddlPartido.SelectedValue = string.Empty;
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
    }
}