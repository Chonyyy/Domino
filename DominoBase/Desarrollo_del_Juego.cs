
using jugador;
using domino;
using mesa;
using ficha;

namespace Desarrollo_del_Juego
{
    public class Juego
    {
        public static bool Pase = false;

        public JUGADOR ganador=null!;
        private void Siguiente()
        {
            MESA.jugadorActual++;
            if (MESA.jugadorActual == Domino.CantidadJugadores)
                MESA.jugadorActual = 0;
        }
        public void jugar()
        {
            MESA.Mesa.Clear();//se limpia la mesa para comenzar un juego nuevo
            Domino.CrearFichas();
            Domino.reparticion.RepartirFichas();
            Domino.MostrarFichas();

            Domino.inicio.Inicio();

            int jugadas = 1;

            /******* controlar pase para no dibujar la mesa */
            while (true)
            {   
                Domino.Verjuego.Mirar();
                Siguiente();

                //Comprueba si el jugador  tiene fichas, si tiene juega
                // primero se tienen las fichas que pudirea tirar según los extremos del domino

                List<FICHA> Fichas_posibles = Domino.jugadores[MESA.jugadorActual].fichas_que_Lleva_Jugador(MESA.Extremos());

                if (Fichas_posibles.Count != 0)
                {
                    Domino.jugadores[MESA.jugadorActual].TirarFicha(Domino.jugadores[MESA.jugadorActual].Escoger(Fichas_posibles));

                    //Comprueba si el jugador se quedo sin fichas
                    if ((Domino.jugadores[MESA.jugadorActual].FichasDelJugador.Count) == 0)
                    {
                        MESA.MostrarEstado(string.Format(" Ganador Dominador : {0} \nEquipo {1}", Domino.jugadores[MESA.jugadorActual].numeroJugador + 1, Domino.jugadores[MESA.jugadorActual].Equipo+1));
                        ganador = Domino.jugadores[MESA.jugadorActual];
                        break;
                    }
                }
                else// Si no tiene fichas que pasa ??? 
                {
                    //suma un pase al jugador actual
                    MESA.CantidadPasesSeguidosPorJugador[MESA.jugadorActual]++;
                    ++MESA.NumeroPasesSeguidos;

                    //anota los numeros que no lleva el jugador actual
                    Domino.jugadores[MESA.jugadorActual].Pases.Add(MESA.Extremos().num1);
                    Domino.jugadores[MESA.jugadorActual].Pases.Add(MESA.Extremos().num2);
                    Pase = true;

                    if (Domino.finalP.Fin())
                    { 
                        ganador=Domino.finalP.Ganador();
                        break;
                    }
                }

                if (Pase)
                {  
                    Domino.pase.Adicionar();
                    Pase = false;
                }
                else
                {
                    Console.Clear();
                    Domino.MostrarFichas();
                    Console.WriteLine("Jugador: {0}", MESA.jugadorActual + 1);
                    Console.Write("Jugadas " + (++jugadas).ToString() + " :"); MESA.Mostrar();

                    // al haber un tiro se rompe el número de pases 
                    MESA.NumeroPasesSeguidos = 0;

                }
            }
        }
    }
}
