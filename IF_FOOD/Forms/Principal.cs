namespace IFFood
{
    internal partial class WPrincipal : Form
    {
        /*List<Produto> l_Prod = new List<Produto>();
        List<Pedido> l_Ped = new List<Pedido>();*/

        public WPrincipal()
        {
            InitializeComponent();
        }

        private void w_Principal_Load(object sender, EventArgs e)
        {

        }

        private void btn_Admin_Click(object sender, EventArgs e)
        {
            WListaProdutos w_L_Prod = new(/*l_Prod*/);

            w_L_Prod.ShowDialog();
        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            WListaPedidos w_L_Ped = new(/*l_Prod, l_Ped*/);

            w_L_Ped.ShowDialog();

        }
    }
}
