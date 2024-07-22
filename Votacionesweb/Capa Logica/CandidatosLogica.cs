using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Votacionesweb.Capa_Logica
{
    public class CandidatosLogica
    {
        public int AgregarUser(string nombre, string apellido, string numtelf, string plataforma, string idpartido)
        {
            int retorno = 0;
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            try
            {
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Candidatos] WHERE IDPartido = @IDPartido", conexion);
                    checkCmd.Parameters.Add(new SqlParameter("@IDPartido", idpartido));
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        return -2;
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Candidatos] (NombreCandidato, ApellidoCandidato, NumeroTelefono, Plataforma, IDPartido)" +
                        " VALUES (@NombreCandidato, @ApellidoCandidato, @NumeroTelefono, @Plataforma, @IDPartido);", conexion)
                    {
                        CommandType = CommandType.Text
                    };
                    cmd.Parameters.Add(new SqlParameter("@NombreCandidato", nombre));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoCandidato", apellido));
                    cmd.Parameters.Add(new SqlParameter("@NumeroTelefono", numtelf));
                    cmd.Parameters.Add(new SqlParameter("@Plataforma", plataforma));
                    cmd.Parameters.Add(new SqlParameter("@IDPartido", idpartido));
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            return retorno;
        }
    }
}