using IFFood.Classes;
using IFFood.Classes.BD;

namespace IFFood
{
    internal partial class WDetPedido : Form
    {
        Pedido Ped;
        List<Produto> L_Prod;

        public WDetPedido(Pedido P/*, List<Produto> l_Produtos*/)
        {
            Ped = P;
            //this.l_Prod = l_Produtos;
            ProdutoBD ProdBD = new();
            L_Prod = ProdBD.ListarTodos();

            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {


            try
            {
                PedidoBD PedBD = new();
                Ped.QtdeTotal = int.Parse(tb_Qtde.Text, null);
                Ped.ValorTotal = double.Parse(tb_Valor.Text, null);

                PedBD.Atualizar(Ped);

                MessageBox.Show("Pedido gravado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Erro no banco Oracle ({ex.Number}): {ex.Message}", "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Det_Pedido_Load(object sender, EventArgs e)
        {
            tb_Codigo.Text = Ped.Codigo;
            tb_Qtde.Text = Ped.QtdeTotal.ToString();
            tb_Valor.Text = Ped.ValorTotal.ToString();
        }

        public void Atualizar()
        {
            int Qtde_Total = 0;
            double Valor_Total = 0;

            lb_Itens.Items.Clear();
            foreach (ItemPedido Item in Ped.ListaItens)
            {
                Qtde_Total += Item.Qtde;
                Valor_Total += Item.Valor();
                lb_Itens.Items.Add("Cód.: " + Item.Prod.Codigo + " Qtde: " + Item.Qtde + " Valor: " + Item.Valor());
            }
            tb_Qtde.Text = Qtde_Total.ToString();
            tb_Valor.Text = Valor_Total.ToString();
        }

        private void btn_Itens_Click(object sender, EventArgs e)
        {
            WAddItens w_Itens = new(Ped, this, L_Prod);
            w_Itens.ShowDialog();

        }
    }
}
