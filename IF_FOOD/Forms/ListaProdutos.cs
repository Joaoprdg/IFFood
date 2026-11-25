using IFFood.Classes;
using IFFood.Classes.BD;

namespace IFFood
{
    internal partial class WListaProdutos : Form
    {
        public WListaProdutos()
        {
            InitializeComponent();
        }

        private void w_Lista_Produtos_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            Produto P = new();
            WDetProduto w_Det = new(P);
            w_Det.ShowDialog();

            /*if (P.Desc != "") //Cadastrou!!!
            {
                //this.l_Prod.Add(P); 
                //Grava o objeto na BD
            }*/
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                List<Produto> L_Prod = [];
                List<string> L_ProdImp = [];
                ProdutoBD ProdBD = new();

                L_Prod = ProdBD.ListarTodos();

                foreach (Produto P in L_Prod)
                {
                    L_ProdImp.Add("Cód: " + P.Codigo + " Descr.:" + P.Desc + " Qtde.:" + P.Qtde + " Preço: " + P.Preco);
                }

                WImpLista w_Imp = new(L_ProdImp, "Produtos");
                w_Imp.ShowDialog();
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



    }
}
