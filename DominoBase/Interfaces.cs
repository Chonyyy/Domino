using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces
{
    //Controla como sera el pase
    public interface IPases
    {
        public void Adicionar();
    }
    //Cambia el sistema de puntaje de las fichas
    public interface ISistemaDePuntaje
    {
        public int DevolverPuntos(int jugador);
    }
    //Establece como se podra observar el juego
    public interface IMirar
    {
        public void Mirar();
    }
    public interface IReparticion
    {
        public void RepartirFichas();
    }
}
