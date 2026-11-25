using IFFood.Classes;
using IFFood.Classes.BD;

namespace IFFood
{
    internal partial class WDetProduto : Form
    {
        Produto Prod;

        /*public w_Det_Produto()
        {
            InitializeComponent();
        }*/
        public WDetProduto(Produto P)
        {
            Prod = P;
            InitializeComponent();
        }


        private void w_Det_Produto_Load(object sender, EventArgs e)
        {
            tb_Codigo.Text = Prod.Codigo;
            tb_Descricao.Text = Prod.Desc;
            tb_Qtde.Text = Prod.Qtde.ToString();
            tb_Preco.Text = Prod.Preco.ToString();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

            try
            {
                ProdutoBD ProdBD = new();
                Prod.Desc = tb_Descricao.Text;
                Prod.Qtde = int.Parse(tb_Qtde.Text, null);
                Prod.Preco = double.Parse(tb_Preco.Text, null);

                if (Prod.IdProduto == 0)
                    ProdBD.Inserir(Prod);
                else
                    ProdBD.Atualizar(Prod);

                MessageBox.Show("Produto gravado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
