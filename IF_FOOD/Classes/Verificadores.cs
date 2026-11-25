using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFFood.Classes
{
    internal class Verificadores
    {
        public bool CamposEstaoPreenchidos(params TextBox[] Campos)
        {
            foreach (TextBox tb in Campos)
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                    return false;
            }
            return true;
        }

        
    }
}
