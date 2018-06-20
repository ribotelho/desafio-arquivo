using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioArquivo.Dados
{
    public static class Transacoes
    {
        public static List<desafioArquivo.Negocios.Entidades.Transacoes> BuscaDados(DateTime data)
        {
            List<desafioArquivo.Negocios.Entidades.Transacoes> retorno = new List<Negocios.Entidades.Transacoes> ();
            using  (SqlConnection conn = new SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI"))
            {
                conn.Open();
                SqlCommand cmd  = new SqlCommand("prc_BuscaTransacoes", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Data", data));

                using (SqlDataReader rdr = cmd.ExecuteReader()) 
                {
                    while (rdr.Read())
                    {
                        retorno.Add(new Negocios.Entidades.Transacoes(Int32.Parse(rdr["cartao"].ToString()), Double.Parse(rdr["valor"].ToString()), DateTime.Parse(rdr["data"].ToString())));
                    }                
                }
            }
            return retorno;
        }
    }
}
