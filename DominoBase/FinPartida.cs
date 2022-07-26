using jugador;
using domino;

namespace finalPartida
{
    public abstract class FinalPartida
    {
        public abstract bool Fin();
        public JUGADOR Ganador()//que pasa si hay empate??
        {
            int minPuntuacion = int.MaxValue;
            JUGADOR ganador = Domino.jugadores[0];
            int[] Puntuacion = new int[Domino.CantidadJugadores];

            for (int i = 0; i < Domino.CantidadJugadores; i++)
            {
                Puntuacion[i] = Domino.pts.DevolverPuntos(i);

                if (Puntuacion[i] < minPuntuacion)
                {
                    ganador = Domino.jugadores[i];
                    minPuntuacion = Puntuacion[i];
                }
            }
            return ganador;
        }
    }
}
