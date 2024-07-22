using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Votacionesweb.CapaVistas
{
    public partial class Resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarResultados();
            }
        }
        protected void CargarResultados()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                WITH VotosTotales AS (
                    SELECT COUNT(*) AS TotalVotos FROM Votos
                ),
                ResultadosPorCandidato AS (
                    SELECT 
                        c.IDCandidato,
                        c.NombreCandidato + ' ' + c.ApellidoCandidato AS NombreCompleto,
                        COUNT(v.IDVoto) AS VotosRecibidos,
                        CAST(COUNT(v.IDVoto) AS FLOAT) / (SELECT TotalVotos FROM VotosTotales) AS PorcentajeVotos
                    FROM 
                        Candidatos c
                        LEFT JOIN Votos v ON c.IDCandidato = v.IDCandidato
                    GROUP BY 
                        c.IDCandidato, c.NombreCandidato, c.ApellidoCandidato
                )
                SELECT 
                    NombreCompleto,
                    VotosRecibidos,
                    PorcentajeVotos,
                    CASE 
                        WHEN PorcentajeVotos = (SELECT MAX(PorcentajeVotos) FROM ResultadosPorCandidato)
                        THEN 1 ELSE 0 
                    END AS EsGanador
                FROM 
                    ResultadosPorCandidato
                ORDER BY 
                    PorcentajeVotos DESC";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtResultados = new DataTable();
                try
                {
                    connection.Open();
                    adapter.Fill(dtResultados);
                    gvResultados.DataSource = dtResultados;
                    gvResultados.DataBind();

                    DataRow[] ganadores = dtResultados.Select("EsGanador = 1");
                    if (ganadores.Length > 0)
                    {
                        litGanador.Text = ganadores[0]["NombreCompleto"].ToString();
                    }
                    else
                    {
                        litGanador.Text = "No hay resultados disponibles";
                    }
                }
                catch (Exception ex)
                {

                    System.Diagnostics.Debug.WriteLine("Error al cargar resultados: " + ex.Message);
                    litGanador.Text = "Error al cargar los resultados";
                }
            }
        }
    }
}