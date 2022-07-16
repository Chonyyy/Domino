
using jugador;
using mesa;

using domino;




namespace fin_de_partida
{
    public abstract class FinalPartida
    {
        public abstract bool Fin();
        public JUGADOR Ganador()//que pasa si hay empate??
        {
           // ISistemaDePuntaje ContarFichasDelJugador = new PuntosSimples();

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
    public class JuegoTrancado :FinalPartida
    {        
        public override bool Fin()//Nadie lleva
        {
            bool nadie = false;
            
           if (MESA.NumeroPasesSeguidos == Domino.CantidadJugadores)
           {
               nadie = true;
                MESA.MostrarEstado(string.Format("Se trancó el juego!!\nGanador: Jugador {0} \nEquipo ganador: {1} ", Ganador().numeroJugador + 1,Ganador().Equipo+1));

           }
            return nadie;
        }
        
    }
    public class  FinDoblePase : FinalPartida
    {
        public override bool Fin()
        {
            if (MESA.CantidadPasesSeguidosPorJugador[MESA.jugadorActual] == 2)
            {
                MESA.MostrarEstado(string.Format("Final con doble pase, el jugador {0} se paso 2 veces seguidas!!\nGanador: Jugador {1} del equipo: {2}",
                    MESA.jugadorActual, Ganador().numeroJugador + 1, Ganador().Numero+1));
                return true;
            }
            

            return false;
        }
    }
}
