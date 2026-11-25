namespace IFFood
{
    internal partial class WImpLista : Form
    {
        //List<Produto> l_Prod;
        List<string> Lista;


        public WImpLista()
        {
            InitializeComponent();
        }

        public WImpLista(List<string> L, string Tipo) : this()
        {
            Lista = L;
            Text += Tipo;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Imp_Lista_Load(object sender, EventArgs e)
        {
            //foreach (Produto P in this.l_Prod)
            foreach (string S in Lista)
            {
                //lb_Lista.Items.Add("Cód: "+P.Codigo + " Descr.:"+ P.Desc + " Qtde.:"+P.Qtde + " Preço: " +P.Preco);
                lb_Lista.Items.Add(S);
            }

        }
    }
}
