using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domino;
using ficha;
using mesa;
using inicio;

namespace inicios_variantes
{
   
    public class SalidaAleatoria : IInicioDelJuego
    {
        public void Inicio()
        {
            Random r = new Random();
            int salida = r.Next(0, Domino.CantidadJugadores);

            FICHA f = Domino.jugadores[salida].TirarFichaEscogida();

            MESA.jugadorActual = salida;
            Console.WriteLine("Salida : [{0},{1}]", f.num1, f.num2);

        }
    }
    public class MayorDoble : IInicioDelJuego
    {
        public void Inicio()
        {
            FICHA mayor_Doble = new FICHA(Domino.NumeroMaximoFichas, Domino.NumeroMaximoFichas);

            for (int i = 0; i < Domino.CantidadJugadores; i++)
            {
                if (Domino.jugadores[i].FichasDelJugador.Exists(a => a.num1 == Domino.NumeroMaximoFichas && a.num2 == Domino.NumeroMaximoFichas))
                {
                    Domino.jugadores[i].TirarFicha(mayor_Doble);
                    MESA.jugadorActual = i;
                    
                    Console.WriteLine("Salida : [{0},{1}]", mayor_Doble.num1, mayor_Doble.num2); 
                    break; // ya se encontró el jugador

                }
            }

        }
    }
    public class FichaMasGrande : IInicioDelJuego
    {
        public void Inicio()
        {
            Random r = new Random();

            //cada jugador elige una ficha de las restatntes,la suma se almacena en un array y el mayor sale

            int SumaMax = 0;
            int primero = 0;
            
            int[] suma = new int[Domino.CantidadJugadores];

            for (int i = 0; i < Domino.CantidadJugadores; i++)
            {
                int n = r.Next(0, Domino.fichas.Count);
                suma[i] = Domino.fichas[n].num1 + Domino.fichas[n].num2;
                if (suma[i] > SumaMax)
                {
                    SumaMax = suma[i];
                    primero = i;
                }
                Domino.fichas.RemoveAt(n);

            }
            MESA.jugadorActual = primero;
  
            FICHA F = Domino.jugadores[MESA.jugadorActual].TirarFichaEscogida();

            Console.WriteLine("\n Comenzó el jugador {0} ", MESA.jugadorActual + 1);
            
            Console.WriteLine("\n Salida :[{0}|{1}]", F.num1, F.num2);
        }
    }
    public class ParesNones : IInicioDelJuego
    {
        public void Inicio()
        {
            //Se escoge una ficha random entre las sobrantes
            Random r1 = new Random();
            int num = r1.Next(0, Domino.fichas.Count);
            FICHA seleccionada = Domino.fichas[num];

            //Los equipos eligen quien sera el par e impar

            Random r2 = new Random();
            int Equipo_par = r2.Next(0, 2);  // son solo 2 equipos
            int Equipo_impar = (Equipo_par == 1) ? 0 : 1;

            MESA.jugadorActual = ((seleccionada.num1 + seleccionada.num2) % 2 == 0) ? QuienSaleDelEquipo(Equipo_par) : QuienSaleDelEquipo(Equipo_impar);

            FICHA F = Domino.jugadores[MESA.jugadorActual].TirarFichaEscogida();

            Console.WriteLine("\n Comenzó el jugador {0} ", MESA.jugadorActual + 1);

            Console.WriteLine("\n Salida :[{0}|{1}]", F.num1, F.num2);
        }
        private int QuienSaleDelEquipo(int equipo)
        {
            List<int> JugadoresdelEquipo = new List<int>();
            for (int i = 0; i < Domino.CantidadJugadores; i++)
            {
                if (Domino.jugadores[i].Equipo == equipo)
                    JugadoresdelEquipo.Add(i);
            }
            Random r2 = new Random();
            int quien = r2.Next(0, JugadoresdelEquipo.Count);
            return JugadoresdelEquipo[quien];
        }
    }

}
