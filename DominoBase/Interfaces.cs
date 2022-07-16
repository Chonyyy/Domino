using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces
{
    public interface IPases
    {
        public void Adicionar();
    }
    public interface ISistemaDePuntaje
    {
        public int DevolverPuntos(int jugador);
    }
   
    public interface IMirar
    {
        public void Mirar();
    }
}
