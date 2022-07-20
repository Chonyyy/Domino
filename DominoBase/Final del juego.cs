using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desarrollo_del_Juego;

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
   
