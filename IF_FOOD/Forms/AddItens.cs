using IFFood.Classes;

namespace IFFood
{
    internal partial class WAddItens : Form
    {
        Pedido Ped;
        WDetPedido w_Det_Ped;
        List<Produto> L_Prod = [];

        public WAddItens(Pedido Ped, WDetPedido Det, List<Produto> L)
        {
            this.Ped = Ped;
            w_Det_Ped = Det;
            L_Prod = L;

            InitializeComponent();
        }

        /*public w_Add_Itens()
        {
            InitializeComponent();
        }*/

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Atualizar()
        {
            try
            {
                lb_Lista.Items.Clear();
                foreach (Produto P in L_Prod)
                {
                    lb_Lista.Items.Add("Cód: " + P.Codigo + " Descr.:" + P.Desc + " Qtde.:" + P.Qtde + " Preço: " + P.Preco);
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Não foi possível carregar os produtos do Oracle ({ex.Number}):\n{ex.Message}",
                                "Erro de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado ao listar produtos:\n{ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Add_Itens_Load(object sender, EventArgs e)
        {

            Atualizar();
        }

        private void lb_Lista_DoubleClick(object sender, EventArgs e)
        {
            WDetItemPedido wDet;

            if (lb_Lista.SelectedIndex >= 0)
            {
                wDet = new WDetItemPedido(Ped.ListaItens, L_Prod[lb_Lista.SelectedIndex]);
                wDet.ShowDialog();
                Atualizar();
                w_Det_Ped.Atualizar();
            }
        }

        private void lb_Lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
