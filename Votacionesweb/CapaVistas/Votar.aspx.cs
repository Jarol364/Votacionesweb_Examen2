using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Votacionesweb.CapaDatos;

namespace Votacionesweb.CapaVistas
{
    public partial class Votar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCandidatos();
            }
        }
        private void CargarCandidatos()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT c.IDCandidato, 
                                        c.NombreCandidato + ' ' + c.ApellidoCandidato + ' - ' + p.NombrePartido AS NombreCompleto
                                 FROM Candidatos c
                                 INNER JOIN Partidos p ON c.IDPartido = p.IDPartido";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                ddlCandidatos.DataSource = reader;
                ddlCandidatos.DataTextField = "NombreCompleto";
                ddlCandidatos.DataValueField = "IDCandidato";
                ddlCandidatos.DataBind();
            }
        }
        protected void btnVotar_Click(object sender, EventArgs e)
        {
            int idCandidato = int.Parse(ddlCandidatos.SelectedValue);


            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Votos (IDCandidato, FechaVoto) VALUES (@IDCandidato, GETDATE())";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDCandidato", idCandidato);
                connection.Open();
                command.ExecuteNonQuery();
            }

            Response.Redirect("resultados.aspx");
        }
    }
}
