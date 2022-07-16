
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
