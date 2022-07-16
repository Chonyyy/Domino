using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using partidas;
using domino;
using Desarrollo_del_Juego;
using mesa;

namespace Final_del_juego
{
    public interface IFinJuego
    {
        public bool Final();
        public int EquipoGanador();
        public string Tipo();
        public void Accion(Juego j);
    }
}
   
