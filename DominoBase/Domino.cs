
using jugador;
using mesa;
using ficha;
using partidas;
using DesarrolloDelJuego;
using FinalJuego;
using interfaces;
using inicio;
using finalPartida;

namespace domino
{
    public sealed class Domino
    {
        
        public static int CantidadJugadores;
        public static int NumeroMaximoFichas;
        public static int CantidadFichasARepartir;
        public static List<FICHA> fichas = new List<FICHA>();
        public static JUGADOR[] jugadores = null!;
        public static int[] equipos =  new int[2];//designa los equipos a cada jugador
        public static List<Partidas> partida =  new List<Partidas>();
        public static int Apuntos = 0;
        public static IInicioDelJuego inicio =null!;
        public static FinalPartida finalP = null!; 
        public static IPases pase = null!;
        public static ISistemaDePuntaje pts =null!;
        public static IFinJuego finalJ = null!;
        public static IReparticion reparticion = null!;
        public static IMirar Verjuego = null!;

        public static void CrearFichas()
        { 
            if (fichas.Count > 0)
     //cuando comienza una partida nueva se devuelven las fichas(fichas.Clear) para volver a repartir
                fichas.Clear();

            //Crea las fichas desde 0 hasta el numero maximo establecido
            for (int i = 0; i <= NumeroMaximoFichas; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    FICHA FICHA = new FICHA(i, j);
                    fichas.Add(FICHA);
                }
            }
        }
        public static void EliminarFichaDeLaMesa(FICHA ficha)
        {
            fichas.Remove(ficha);
        }
        public static void MostrarFichas()
        {//muestra lasa fichas de jugador una vez esten repartidas
            
            for (int i = 0; i < jugadores.Length; i++)
            {
                Console.Write("Jugador  {0} :", i + 1);

                for (int j = 0; j < jugadores[i].FichasDelJugador.Count; j++)
                {
                    Console.Write("[{0},{1}] ", jugadores[i].FichasDelJugador[j].num1, jugadores[i].FichasDelJugador[j].num2);

                }
                Console.WriteLine();
            }
            Console.WriteLine("Fichas restantes: ");

            for (int i = 0; i < fichas.Count; i++)
            {
                Console.Write("[{0}|{1}] ", fichas[i].num1, fichas[i].num2);
            }
            Console.WriteLine(); Console.WriteLine();
        }

        public static void Play()
        {
            int nPartida = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("PARTIDA {0}", ++nPartida );
                Thread.Sleep(1000);

                //Comienza el juego
                Juego j = new Juego(); 
               
                j.jugar();//Desarrollo del juego

                finalJ.Accion(j);//Establece el fin del juego

                //Si el final es por acumulacion de puntos muetra en pantalla la actualizacion de los puntos al finalizar cada partida
                if (finalJ.Tipo()=="AcumulacionDePuntos")    
                    Console.WriteLine("Equipo 1: {0} pts\nEquipo 2: {1} pts",MESA.puntosPorEquipos[0],MESA.puntosPorEquipos[1]);

                //Cuando se cumple la condicion de final del juego se rompe el ciclo
                if (finalJ.Final())
                    break;


                Console.WriteLine("Fin...teclee cualquier tecla para salir");
                Console.ReadKey();
                Console.WriteLine("otra vez..por último");
                Console.ReadKey();
                
            } while (true);

            Console.WriteLine("\nEquipo ganador: {0} \n", finalJ.EquipoGanador() + 1);

            //MostrarDesarrollo();
            Console.WriteLine("FIN DEL JUEGO !!!!!!!...teclee cualquier tecla para salir");
            Console.ReadKey();
        }


    }

}
