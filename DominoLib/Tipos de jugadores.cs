using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ficha;
using jugador;
using mesa;
using domino;

namespace TiposdeJugadores
{
    public class BotaGorda : JUGADOR
    {
        public override FICHA Escoger(List<FICHA> FichasPosibles)
        {
            FICHA f = new FICHA(FichasDelJugador[0].num1, FichasDelJugador[0].num2);

            if (MESA.Mesa.Count == 0)//caso en que la mesa esta vacia
            {
                //buscar la ficha mas grande entre todas las fichas q tiene el jugador
                f = FichasDelJugador.OrderByDescending(a => a.num1 + a.num2).First();
            }
            else
            {
               //Busca la ficha mas grande entre las que el lleva(FICHAS POSIBLES)
                f = FichasPosibles.OrderByDescending(a => a.num1 + a.num2).First();
            }
            return f;
        }
    }
    public class Aleatorio : JUGADOR
    {
        public override FICHA Escoger(List<FICHA> Fichas_posibles)
        {
            FICHA ficha = new FICHA(FichasDelJugador[0].num1, FichasDelJugador[0].num2);

            Random r = new Random();

            if (MESA.Mesa.Count == 0)//caso en que la mesa esta vacia
            {
                int i = r.Next(0, FichasDelJugador.Count);//elige entre todas sus fichas
                ficha = FichasDelJugador[i];
            }
            else
            {
                List<FICHA> aux = FichasQueLlevaElJugador(MESA.Extremos());
                if (aux.Count == 0) { return null!; }
                int j = r.Next(0, aux.Count);//elige entre las fichas que lleva
                ficha = FichasQueLlevaElJugador(MESA.Extremos())[j];

            }
            return ficha;
        }

    }
    public class Tramposo : JUGADOR
    {

        public override FICHA Escoger(List<FICHA> Fichas_posibles)
        {
            FICHA f = new FICHA(Fichas_posibles[0].num1, Fichas_posibles[0].num2);

            //Mira las fichas del jugador de al lado
            bool[] mask = new bool[Domino.NumeroMaximoFichas + 1];
            bool[] mask_extremos = new bool[2];

            /******* evitar que se pase */
            int Siguiente_jugador = MESA.ProximoJugador();

            for (int i = 0; i < Domino.jugadores[Siguiente_jugador].FichasDelJugador.Count; i++)
            {
                //Agrega a la mask los numeros q tiene el jugador siguiente
                mask[Domino.jugadores[Siguiente_jugador].FichasDelJugador[i].num1] = true;
                mask[Domino.jugadores[Siguiente_jugador].FichasDelJugador[i].num2] = true;

                //agrega a mask_extremos si el prox jugador lleva alguna ficha para jugar
                //compara el 1er extremo
                if (MESA.Mesa.Count != 0 && (MESA.Extremos().num1 == Domino.jugadores[Siguiente_jugador].FichasDelJugador[i].num1
                 || MESA.Extremos().num1 == Domino.jugadores[Siguiente_jugador].FichasDelJugador[i].num2))
                    mask_extremos[0] = true;

                //compara el 2do extremo
                if (MESA.Mesa.Count != 0 && (MESA.Extremos().num2 == Domino.jugadores[Siguiente_jugador].FichasDelJugador[i].num1
                || MESA.Extremos().num2 == Domino.jugadores[Siguiente_jugador].FichasDelJugador[i].num2))
                    mask_extremos[1] = true;
            }

            //Luego comparo con las del jugador actual

            //reviso los extremos
            for (int e = 0; e < mask_extremos.Length; e++)
            {
                if (!mask_extremos[e])//si no lleva en 1 extremo jugar por el otro
                    continue;
                else//si lleva por un extremo tratar de buscar una ficha que le de el pase al prox jugador
                {
                    for (int i = 0; i < Fichas_posibles.Count; i++)
                    {
                        if (!mask[i])
                        {
                            for (int j = 0; j < Fichas_posibles.Count; j++)
                            {
                                //Buscar una ficha que lleve el jugador actual y que no lleve el proximo
                                if (Fichas_posibles[j].num1 == i)
                                {
                                    FICHA ficha;
                                    if (mask_extremos[0])
                                    {
                                        ficha = new FICHA(i, MESA.Extremos().num1);
                                    }
                                    else
                                    {
                                        ficha = new FICHA(i, MESA.Extremos().num2);
                                    }

                                    f = ficha;
                                }
                            }
                        }
                    }
                }
            }

            return f;
            //ver los extremos
            //si no lleva en 1 jugar x otro lado(Tirar una q lo tranque)
            //si no lleva en 2 jugar cualquiera(mejor si juego una q no lleve)

        }
    }
    

    public class JugadorHumano : JUGADOR
    {
        public override FICHA Escoger(List<FICHA> Fichas_posibles)
        {
            FICHA ficha = new FICHA(Fichas_posibles[0].num1, Fichas_posibles[0].num2);

            Console.WriteLine("Eres el jugador {0} ", MESA.jugadorActual + 1);
            int num = int.Parse(Console.ReadLine());

            if (MESA.Extremos() == null)
                ficha = Domino.jugadores[MESA.jugadorActual].FichasDelJugador[num];
            else
            {
                do
                {
                    Console.WriteLine("Elige una ficha: ");
                    num = int.Parse(Console.ReadLine());
                    ficha = Domino.jugadores[MESA.jugadorActual].FichasDelJugador[num];

                } while (Domino.jugadores[MESA.jugadorActual].FichasDelJugador[num].num1 != MESA.Extremos().num1 &&
                   Domino.jugadores[MESA.jugadorActual].FichasDelJugador[num].num1 != MESA.Extremos().num2 &&
                   Domino.jugadores[MESA.jugadorActual].FichasDelJugador[num].num2 != MESA.Extremos().num1 &&
                   Domino.jugadores[MESA.jugadorActual].FichasDelJugador[num].num1 != MESA.Extremos().num2);

            }

            return ficha;
        }
    }
}

