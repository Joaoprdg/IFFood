using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFFood.Classes;
namespace IFFood.Classes.BD
{
    internal class UsuarioBD
    {
        public void Inserir(Usuario U)
        {
            const string sql = @"INSERT INTO G8_USUARIO (USUARIO, SENHA, NOME, DATA_NASC, EMAIL, ADM, GENERO) VALUES (:USUARIO, :SENHA, :NOME, :DATA_NASC, :EMAIL, :ADM, :GENERO)";

            using OracleConnection conn = ConexaoOracle.ObterConexao();
            using OracleCommand cmd = new OracleCommand(sql, conn);

            cmd.BindByName = true;

            cmd.Parameters.Add("USUARIO", OracleDbType.Varchar2).Value = U.Nome_Usuario;
            cmd.Parameters.Add("SENHA", OracleDbType.Varchar2).Value = U.Senha;
            cmd.Parameters.Add("NOME", OracleDbType.Varchar2).Value = U.Nome;
            cmd.Parameters.Add("DATA_NASC", OracleDbType.Varchar2).Value = U.Data_Nasc;
            cmd.Parameters.Add("EMAIL", OracleDbType.Varchar2).Value = U.Email;
            cmd.Parameters.Add("ADM", OracleDbType.Int32).Value = U.Adm;
            
            if (U.Genero == "prefiro não dizer" || U.Genero == null )
            {
                cmd.Parameters.Add("GENERO", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("GENERO", OracleDbType.Varchar2).Value = U.Genero;
            }
            //cmd.Parameters.Add("GENERO", OracleDbType.Varchar2).Value = U.Genero;

            cmd.ExecuteNonQuery();
        }
    }
}
