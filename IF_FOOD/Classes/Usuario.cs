using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFFood.Classes
{
    public class Usuario
    {

        public string Nome_Usuario { get; set; } = "";
        public string Senha { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Data_Nasc { get; set; } = "";
        public string Email { get; set; } = "";
        public int Adm { get; set; } = 0;
        public string Genero { get; set; } = "";

        public Usuario(string Nome_Usuario, string Senha, string Nome,string Data_Nasc, string Email, int Adm, string Genero)
        {
            this.Nome_Usuario = Nome_Usuario;
            this.Senha = Senha;
            this.Nome = Nome;
            this.Data_Nasc = Data_Nasc;
            this.Email = Email;
            this.Adm = Adm;
            this.Genero = Genero;
        }

    }
}
