using IFFood.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
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
        //a
        public bool VerificaLogin(string username, string senha)
        {
            const string sql = @"SELECT COUNT(*) 
                         FROM G8_USUARIO 
                         WHERE USUARIO = :usuario AND SENHA = :senha";

            using OracleConnection conn = ConexaoOracle.ObterConexao();
            using OracleCommand cmd = new(sql, conn);

            cmd.BindByName = true;
            cmd.Parameters.Add("usuario", OracleDbType.Varchar2).Value = username;
            cmd.Parameters.Add("senha", OracleDbType.Varchar2).Value = senha;

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

            private string BuscaCampo(string coluna, string username)
            {
                string sql = "SELECT " + coluna + " FROM G8_USUARIO WHERE USUARIO = :usuario";

                using OracleConnection conn = ConexaoOracle.ObterConexao();
                using OracleCommand cmd = new(sql, conn);

                cmd.BindByName = true;
                cmd.Parameters.Add("usuario", OracleDbType.Varchar2).Value = username;

                object resultado = cmd.ExecuteScalar();

                if (resultado == null || resultado == DBNull.Value)
                    return null;

                return resultado.ToString();
            }

            public Usuario PegaDados(Usuario U, string username)
            {
                U ??= new Usuario();  

                U.Nome_Usuario = BuscaCampo("USUARIO", username);
                U.Nome = BuscaCampo("NOME", username);
                U.Data_Nasc = BuscaCampo("DATA_NASC", username);
                U.Email = BuscaCampo("EMAIL", username);
                U.Genero = BuscaCampo("GENERO", username);
                U.Adm = Convert.ToInt32(BuscaCampo("ADM", username));

                return U;
            }
    }
}

