using IFFood.Classes;
using System.Globalization;

namespace IFFood
{
    internal partial class WDetItemPedido : Form
    {
        List<ItemPedido> Lista_Itens = [];
        Produto Prod = new();

        public WDetItemPedido()
        {
            InitializeComponent();
        }
        public WDetItemPedido(List<ItemPedido> Lista, Produto P) : this()
        {
            Lista_Itens = Lista;
            Prod = P;
        }


        private void w_Det_Item_Pedido_Load(object sender, EventArgs e)
        {
            tb_Codigo.Text = Prod.Codigo;
            tb_Descricao.Text = Prod.Desc;
            tb_Qtde.Text = "0";
            tb_Valor.Text = "0";
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (int.Parse(tb_Qtde.Text, null) <= Prod.Qtde)
            {
                Lista_Itens.Add(new ItemPedido());
                Lista_Itens[Lista_Itens.Count - 1].Prod = Prod;
                Lista_Itens[Lista_Itens.Count - 1].Qtde = int.Parse(tb_Qtde.Text, CultureInfo.CurrentCulture);
                Lista_Itens[Lista_Itens.Count - 1].Preco_Unitario = int.Parse(tb_Valor.Text, CultureInfo.CurrentCulture);
                Prod.Qtde -= Lista_Itens[Lista_Itens.Count - 1].Qtde;

                Close();
            }
            else
            {
                MessageBox.Show("Quantidade insuficiente no estoque!!");
            }

        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_Qtde_TextChanged(object sender, EventArgs e)
        {
            if (tb_Qtde.Text != "0" && !string.IsNullOrEmpty(tb_Qtde.Text.Trim()))
            {
                tb_Valor.Text = (Prod.Preco * int.Parse(tb_Qtde.Text, null)).ToString(CultureInfo.CurrentCulture);
            }
        }
    }
}
