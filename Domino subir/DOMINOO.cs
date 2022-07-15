using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jugador;
using mesa;
using ficha;
using partidas;
using Desarrollo_del_Juego;
using Final_del_juego;
using interfaces;
using inicio;
using fin_de_partida;
using config;
using variantes;

namespace domino
{
    public class Domino
    {
        public static int CantidadJugadores;
        public static int NumeroMaximoFichas;
        public static int CantidadFichasARepartir;
        public static List<FICHA> fichas = new List<FICHA>();
        public static JUGADOR[] jugadores = null!;
        public static int[] equipos = equipos = new int[2];//designa los equipos a cada jugador
        public static  List<Partidas> partida = partida = new List<Partidas>();
        public static bool Apuntos = false;
        public static IInicioDelJuego inicio =null!;
        public static FinalPartida finalP = null!; 
        public static IPases pase = null!;
        public static ISistemaDePuntaje pts =null!;
        public static IFinJuego finalJ = null!;
        public static IReparticion reparticion = null!;
        public static IMirar Verjuego = null!;

        public static void DefinicionJuego()
        {
            if (NumeroMaximoFichas == 6)
            {
                CantidadFichasARepartir = 7;
            }
            if (NumeroMaximoFichas == 9)
            {
                CantidadFichasARepartir = 10;
            }
            switch (Configuracion.Inicio)
            {
                case 1: inicio = new SalidaAleatoria(); break;
                case 2: inicio = new MayorDoble(); break;
                case 3: inicio = new FichaMasGrande(); break;
                case 4: inicio = new ParesNones(); break;
            }
            switch (Configuracion.FinalPartida)
            {
                case 1: finalP = new JuegoTrancado(); break;
                case 2: finalP = new FinDoblePase(); break;
            }
            switch (Configuracion.Puntaje)
            {
                case 1: pts = new PuntosDeLasFichas(); break;
                case 2: pts = new PuntosSimples(); break;
            }
            switch (Configuracion.Pases)
            {
                case 1: pase = new PaseUsual(); break;
                case 2: pase = new AdicionarFichaSiNoLleva(); break;
            }
            switch (Configuracion.FinalJuego)
            {
                case 1: finalJ = new PorPartidas(Configuracion.CantidadPartidas); break;
                case 2: finalJ = new AcumulacionDePuntos(); break;
            }
        }
        public static void CrearFichas()
        {
            if (fichas.Count > 0)
                fichas.Clear();

            for (int i = 0; i <= NumeroMaximoFichas; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    FICHA FICHA = new FICHA(i, j);
                    fichas.Add(FICHA);
                }
            }
        }
        public static void RepartirFichas()
        {
            reparticion.RepartirFichas();
        }
        public static void EliminarFichaDeLaMesa(FICHA ficha)
        {
            fichas.Remove(ficha);
        }
        public static void MostrarFichas()
        {
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
            Configuracion.DefinicionJuego();
            int i = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("PARTIDA {0}", i + 1);
                Thread.Sleep(1000);
                Juego j = new Juego(); 
               
                j.jugar();

                if (finalJ.Tipo()=="PorPartidas")
                { 
                    partida.Add(new Partidas(j.ganador));
                    equipos[j.ganador.Equipo]++;
                }
                if (finalJ.Tipo()=="AcumulacionDePuntos")
                {
                    AcumulacionDePuntos.SumaPuntos();
                    Console.WriteLine("Equipo 1: {0} pts\nEquipo 2: {1} pts",MESA.puntosPorEquipos[0],MESA.puntosPorEquipos[1]);
                }

                if (finalJ.Final())
                    break;


                Console.WriteLine("Fin...teclee cualquier tecla para salir");
                Console.ReadKey();
                Console.WriteLine("otra vez..por último");
                Console.ReadKey();

            } while (true);

            Console.WriteLine("\nEquipo ganador: {0} \n", finalJ.EquipoGanador() + 1);

            //MostrarDesarrollo();
            Console.WriteLine("FIN DEL JUEGO...teclee cualquier tecla para salir");
            Console.ReadKey();
        }
        /*public static void MostrarDesarrollo()
        {
            foreach (Partidas p in partida)
            {
                Console.WriteLine("Ganador:{0} del equipo {1} ", p.ganador.numeroJugador + 1, p.ganador.Equipo + 1);
            }
        }*/


    }

}
