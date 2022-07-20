
using jugador;

namespace partidas
{
    public class Partidas
    {
        public JUGADOR ganador { set; get; }//Para el fin por partidas
        public int puntosObtenidos { set; get; }//Para el fin por acumulacion de puntos
        public int juegoActual=0;

        public Partidas(JUGADOR g)
        {
            ganador = g;
        }

    }
}
