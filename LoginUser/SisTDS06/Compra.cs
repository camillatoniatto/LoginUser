using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisTDS06
{
    public class Compra
    {
        public int Id { get; set; }
        public string cpfCliente { get; set; }
        public decimal valorTotal { get; set; }
        public DateTime dataCompra { get; set; }
        public int idVenda { get; set; }

        public void InserirCompra(string cpfCliente, decimal valorTotal, DateTime dataCompra, int idVenda)
        {
            string totalValue = valorTotal.ToString();
            totalValue = totalValue.Replace(',', '.');

            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Compra(cpfPessoa,valorTotal,dataCompra,idVenda) VALUES ('" + cpfCliente + "','" + totalValue + "', Convert(DateTime, '"+ dataCompra + "', 103),'" + null + "')";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            ClassConecta.FecharConexao();
        }

        public void LocalizarCompra(int id)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Compra WHERE Id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cpfCliente = dr["cpfCliente"].ToString();
                valorTotal = Convert.ToDecimal(dr["valorTotal"]);
                dataCompra = Convert.ToDateTime(dr["dataCompra"]);
                idVenda = (int)dr["valorUnid"];
            }
        }

        public void ExcluirCompra(int id)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Venda WHERE Id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            ClassConecta.FecharConexao();
        }
    }
}
