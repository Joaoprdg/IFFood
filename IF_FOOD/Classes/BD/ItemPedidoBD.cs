using IFFood.Classes.BD.Interfaces;

namespace IFFood.Classes.BD
{
    internal class ItemPedidoBD : IBD<ItemPedido>
    {
        // Exigido pela IBD<T>: todos os itens de todos os pedidos
        public List<ItemPedido> ListarTodos()
        {
            return Carregar("SELECT * FROM ITEM_PEDIDO ORDER BY ROWID", null);
        }

        // O seu método original, com nome que não confunde com o da interface
        public List<ItemPedido> ListarPorPedido(int IdPedido)
        {
            return Carregar("SELECT * FROM ITEM_PEDIDO WHERE ID_PEDIDO = :ID_PEDIDO ORDER BY ROWID", IdPedido);
        }

        // Exigido pela IBD<T>. Os itens são gravados pelo PedidoBD.Atualizar,
        // dentro da mesma transação do pedido.
        public void Atualizar(ItemPedido item)
        {
            throw new NotSupportedException("Os itens são gravados pelo PedidoBD.Atualizar.");
        }

        // Lógica de leitura que antes estava dentro do ListarTodos(int)
        private static List<ItemPedido> Carregar(string sql, int? idPedido)
        {
            List<ItemPedido> lista = [];

            // O 'using' garante que a conexão será fechada automaticamente ao terminar
            using (OracleConnection conn = ConexaoOracle.ObterConexao()) //Já abre a conexão!!
            using (OracleCommand cmd = new(sql, conn))
            {
                if (idPedido.HasValue)
                {
                    cmd.Parameters.Add("ID_PEDIDO", OracleDbType.Int32).Value = idPedido.Value;
                }

                using (OracleDataReader reader = cmd.ExecuteReader())

                    while (reader != null && reader.Read()) //Carrega os itens
                    {
                        int IdProduto = reader.GetInt32(1); //1 - ID_PRODUTO

                        //Carrega os dados do produto no item
                        using (OracleCommand cmdProd = new("SELECT * FROM PRODUTO WHERE ID_PRODUTO = :ID_PRODUTO", conn))
                        {
                            cmdProd.Parameters.Add("ID_PRODUTO", OracleDbType.Int32).Value = IdProduto;
                            using (OracleDataReader readerProd = cmdProd.ExecuteReader())

                                if (readerProd != null && readerProd.Read())
                                {
                                    Produto Prod = new(readerProd.GetInt32(0), readerProd.GetString(1),
                                        readerProd.GetString(2), readerProd.GetInt32(3), readerProd.GetDouble(4));

                                    lista.Add(new ItemPedido(reader.GetInt32(0), Prod,
                                                        reader.GetInt32(2), reader.GetDouble(3)));
                                }
                        }
                    }
            }

            return lista;
        }
    }
}
