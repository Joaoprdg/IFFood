namespace IFFood.Classes
{
    internal class Pedido
    {
        //static int ult_ref_id = 0;

        public int IdPedido { get; set; }

        public string Codigo { get; set; } = "";
        public int QtdeTotal { get; set; }
        public double ValorTotal { get; set; }

        public List<ItemPedido> ListaItens { get; set; }

        public Pedido()
        {
            //Pedido.Gera_Id();
            //this.id_Pedido = Pedido.Get_Id();
            //this.Codigo += this.id_Pedido.ToString();
            ListaItens = [];
        }

        public Pedido(int Id, string Codigo, int QtdeTot, double Valor) : this()
        {
            IdPedido = Id;
            this.Codigo = Codigo;
            QtdeTotal = QtdeTot;
            ValorTotal = Valor;
        }


        /*static public void Gera_Id()
        {
            ++Pedido.ult_ref_id;
        }

        static public int Get_Id()
        {
            return Pedido.ult_ref_id;
        }*/
    }
}
