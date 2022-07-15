using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jugador;

namespace partidas
{
    public class Partidas
    {
        public JUGADOR ganador { set; get; }
        public int puntosObtenidos { set; get; }
        public int juegoActual=0;

        public Partidas(JUGADOR g)
        {
            ganador = g;
        }

    }
}
