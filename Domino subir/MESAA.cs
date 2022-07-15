using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ficha;
using domino;
using jugador;

namespace mesa
{
    public sealed class MESA
    {
        public static int[] CantidadPasesSeguidosPorJugador = new int[Domino.CantidadJugadores];//Para el FinDoblePase
        public static List<FICHA> Mesa = new List<FICHA>();
        public static int jugadorActual = 0;
        public static int NumeroPasesSeguidos = 0;
        public static int[] puntosPorEquipos = new int[2];//Para el juego por anotacion de puntos
        public static List<int>participantes = new List<int>();

        public static int JugadorSiguiente()
        {
            int prox = jugadorActual + 1;
            if (prox == Domino.CantidadJugadores)
                prox = 0;
            return prox;
        }
        
        static public FICHA Extremos()//Numeros de los extremos del juego
        {
            if (Mesa.Count == 0)
                return null!;

            return new FICHA(Mesa[0].num1, Mesa[Mesa.Count - 1].num2);
        }
        static public void Colocar_Ficha(FICHA f)
        {
            if (Mesa.Count == 0)
            {
                Mesa.Add(f);
            }
            else
            {
                FICHA extremos = Extremos();

                if (f.num2 == extremos.num1)//se coloca la ficha al inicio
                    Mesa.Insert(0, f);

                else if (f.num1 == extremos.num2)//se coloca la ficha al final
                    Mesa.Add(f);

                else if (f.num1 == extremos.num1)//si lleva la ficha del inicio ,al comtrario se rota y se agrega
                {
                    Rotar(f);
                    Mesa.Insert(0, f);
                }
                else if (f.num2 == extremos.num2)//si lleva la ficha del final ,al comtrario se rota y se agrega
                {
                    Rotar(f);
                    Mesa.Add(f);
                }
            }
        }
        public static void Rotar(FICHA ficha)
        {
            int temp = 0;
            temp = ficha.num1;
            ficha.num1 = ficha.num2;
            ficha.num2 = temp;
        }
        public static void Mostrar()
        {
            for (int i = 0; i < Mesa.Count; i++)
            {
                Console.Write(string.Format("[{0}|{1}] ", Mesa[i].num1, Mesa[i].num2));
            }
            Console.WriteLine();
        }
        public static void MostrarEstado(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
