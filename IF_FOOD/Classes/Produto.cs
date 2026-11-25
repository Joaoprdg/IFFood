namespace IFFood.Classes
{
    internal class Produto
    {
        //static int ult_ref_id=0;

        public int IdProduto { get; set; }

        public string Codigo { get; set; } = "";
        public string Desc { get; set; } = "";
        public int Qtde { get; set; }
        public double Preco { get; set; }

        /*static public void Gera_Id()
        {
            ++Produto.ult_ref_id;
        }*/

        /*static public int Get_Id()
        {
            return Produto.ult_ref_id;
        }*/

        public Produto()
        {
            //Produto.Gera_Id();
            //this.id_Produto = Produto.Get_Id();
            //this.Codigo += this.id_Produto.ToString();
        }

        public Produto(int Id, string Codigo, string Desc, int Qtde, double Preco) : this()
        {
            IdProduto = Id;
            this.Codigo = Codigo;
            this.Desc = Desc;
            this.Qtde = Qtde;
            this.Preco = Preco;
        }
    }
}
