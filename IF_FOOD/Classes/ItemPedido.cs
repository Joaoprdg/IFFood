namespace IFFood.Classes
{
    internal class ItemPedido
    {
        public int IdPedido { get; set; }
        public Produto Prod { get; set; }

        public int Qtde;
        public double Preco_Unitario;

        public ItemPedido()
        {
            Prod = new Produto();
        }

        public ItemPedido(int Id, Produto P, int Qtde, double PrecoUnit) : this()
        {
            IdPedido = Id;
            Prod = P;
            this.Qtde = Qtde;
            Preco_Unitario = PrecoUnit;
            Preco_Unitario = PrecoUnit;
        }

        public double Valor()
        {
            return Preco_Unitario * Qtde;
        }


    }
}
