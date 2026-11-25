using IFFood.Classes;
using IFFood.Classes.BD;

namespace IFFood
{
    internal partial class WListaPedidos : Form
    {
        /*List<Produto> l_Prod;
        List<Pedido> l_Ped;*/

        /*public w_Lista_Pedidos(List<Produto> l_Produtos, List<Pedido> l_Pedidos) : this()
        {
            this.l_Prod = l_Produtos;
            this.l_Ped = l_Pedidos;
        }*/

        public WListaPedidos()
        {
            InitializeComponent();
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            Pedido P = new();
            WDetPedido wDet = new(P/*, l_Prod*/);
            wDet.ShowDialog();

            /*if (P.Qtde_Total != 0) //Cadastrou!!!
            {
                this.l_Ped.Add(P);
            }*/
        }

        private void w_Lista_Pedidos_Load(object sender, EventArgs e)
        {

        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pedido> L_Ped = [];
                List<string> L_PedImp = [];
                PedidoBD PedBD = new();

                L_Ped = PedBD.ListarTodos();

                foreach (Pedido P in L_Ped)
                {
                    int Cont = 1;
                    L_PedImp.Add("Cód: " + P.Codigo + " Qtde. Tot.:" + P.QtdeTotal + " Valor: " + P.ValorTotal);
                    foreach (ItemPedido It in P.ListaItens)
                    {
                        L_PedImp.Add("   [" + Cont + "] -->" + It.Prod.Codigo + " (" + It.Prod.Desc + ") Qtde.:" + It.Qtde + " Preço Unit.: " + It.Preco_Unitario);
                        ++Cont;
                    }

                }

                WImpLista w_Imp = new(L_PedImp, "Pedidos");
                w_Imp.ShowDialog();
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Não foi possível carregar os pedidos do Oracle ({ex.Number}):\n{ex.Message}",
                                "Erro de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado ao listar pedidos:\n{ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
