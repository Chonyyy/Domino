
using jugador;
using domino;
using mesa;
using ficha;

namespace Desarrollo_del_Juego
{
    public class Juego
    {
        public static bool Pase = false;//Controla el pase de un jugador en cada ronda
        public JUGADOR ganador=null!;//Guarda el ganador por partidas

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

            while (true)
            {   
                //El juego se podra observar de la forma establecida en configuraciones
                Domino.Verjuego.Mirar();
                //Se establece el siguiente
                Siguiente();

                //Comprueba si el jugador  tiene fichas, si tiene juega
                // primero se tienen las fichas que pudirea tirar según los extremos del domino

                List<FICHA> Fichas_posibles = Domino.jugadores[MESA.jugadorActual].fichas_que_Lleva_Jugador(MESA.Extremos());

                //Comprueba si el jugador lleva fichas
                if (Fichas_posibles.Count != 0)
                {
                    //Tira una ficha entre la lista de fichas posibles
                    Domino.jugadores[MESA.jugadorActual].TirarFicha(Domino.jugadores[MESA.jugadorActual].Escoger(Fichas_posibles));

                    //Comprueba si el jugador se quedo sin fichas para ver si gano
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

                    //si llego a la condicion de final
                    if (Domino.finalP.Fin())
                    { 
                        ganador=Domino.finalP.Ganador();//se establece el ganador
                        break;
                    }
                }

                if (Pase)
                {  
                    Domino.pase.Adicionar();//Tiene la opcion de adicionar ficha o no mediante la interface IPase
                    Pase = false;//Desmarca el pase para el proximo jugador
                }
                else
                {
                    Console.Clear();
                    Domino.MostrarFichas();
                    Console.WriteLine("Jugador: {0}", MESA.jugadorActual + 1);//Muestra en pantalla el jugador actual, se le suma uno porque se inicializa en 0
                    Console.Write("Jugadas " + (++jugadas).ToString() + " :");//Muestra el numero de jugada
                    MESA.Mostrar();//Muestra el desarrollo de la mesa

                    // al haber un tiro se rompe el número de pases 
                    MESA.NumeroPasesSeguidos = 0;

                }
            }
        }
    }
}
