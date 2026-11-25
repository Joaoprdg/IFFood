using IFFood.Classes.BD.Interfaces;

namespace IFFood.Classes.BD
{
    internal class ProdutoBD : IBD<Produto>
    {

        public List<Produto> ListarTodos()
        {
            List<Produto> lista = [];

            // O 'using' garante que a conexão será fechada automaticamente ao terminar
            using (OracleConnection conn = ConexaoOracle.ObterConexao()) //Já abre a conexão!!
            using (OracleCommand cmd = new("SELECT * FROM PRODUTO ORDER BY CODIGO", conn))
            using (OracleDataReader reader = cmd.ExecuteReader())

                while (reader != null && reader.Read())
                {
                    /*lista.Add(new Produto(Convert.ToInt32(reader["ID_PRODUTO"]),
                                            Convert.ToString(reader["CODIGO"]),
                                            reader["DESCRICAO"].ToString(),
                                            Convert.ToInt32(reader["QTDE"]),
                                            Convert.ToDouble(reader["PRECO"])));*/

                    lista.Add(new Produto(reader.GetInt32(0), reader.GetString(1),
                                            reader.GetString(2), reader.GetInt32(3),
                                           reader.GetDouble(4)));
                }

            return lista;
        }


        public void Inserir(Produto produto)
        {
            const string sql = @"INSERT INTO PRODUTO (DESCRICAO, QTDE, PRECO) VALUES (:DESCR, :QTDE, :PRECO)";

            using OracleConnection conn = ConexaoOracle.ObterConexao();
            using OracleCommand cmd = new(sql, conn);

            // Garante que o Oracle vincule pelo nome (:nome) e não pela ordem
            cmd.BindByName = true;

            cmd.Parameters.Add("DESCR", OracleDbType.Varchar2).Value = produto.Desc;
            cmd.Parameters.Add("QTDE", OracleDbType.Int32).Value = produto.Qtde;
            cmd.Parameters.Add("PRECO", OracleDbType.Decimal).Value = produto.Preco;

            cmd.ExecuteNonQuery();
        }

        // Método para ATUALIZAR um produto existente
        public void Atualizar(Produto produto)
        {
            const string sql = @"
            UPDATE PRODUTO 
               SET DESCRICAO = :DESCR, 
                   QTDE = :QTDE
                   PRECO = :PRECO
             WHERE ID = :ID_PRODUTO";

            using var conn = ConexaoOracle.ObterConexao();
            using var cmd = new OracleCommand(sql, conn);

            cmd.BindByName = true;

            cmd.Parameters.Add("DESCR", OracleDbType.Varchar2).Value = produto.Desc;
            cmd.Parameters.Add("QTDE", OracleDbType.Int32).Value = produto.Qtde;
            cmd.Parameters.Add("PRECO", OracleDbType.Decimal).Value = produto.Preco;
            cmd.Parameters.Add("ID_PRODUTO", OracleDbType.Int32).Value = produto.IdProduto;

            cmd.ExecuteNonQuery();
        }

    }
}
