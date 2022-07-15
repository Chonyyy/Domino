using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ficha;
using domino;
using Desarrollo_del_Juego;
using mesa;
using interfaces;

namespace variantes
{
    //Diferentes variantes
    public class AdicionarFichaSiNoLleva : IPases
    {
        public void Adicionar()
        {
            Random r = new Random();
            int f = r.Next(0, Domino.fichas.Count);

            if (Juego.Pase)
            {
                Domino.jugadores[MESA.jugadorActual].RecogerFicha(Domino.fichas[f]);
            }
            MESA.MostrarEstado(string.Format("Pasó el jugador : {0} y recogió ficha", MESA.jugadorActual + 1));

        }
    }
    public class PaseUsual : IPases
    {
        public void Adicionar()
        {
            //No adiciona nada
            MESA.MostrarEstado(string.Format("Pasó el jugador : {0}", MESA.jugadorActual + 1));

        }
    }

    //Para contar las fichas
    public class PuntosSimples : ISistemaDePuntaje
    {
        public int DevolverPuntos(int jugador)
        {
            int cant = 0;

            for (int i = 0; i < Domino.jugadores[jugador].FichasDelJugador.Count; i++)
            {

                //las fichas normales tienen puntaje 1
                if (Domino.jugadores[jugador].FichasDelJugador[i].num1 != Domino.jugadores[jugador].FichasDelJugador[i].num2)
                    cant += 1;
                else
                    //los dobles tienen puntaje 2
                    cant += 2;

            }
            return cant;
        }
    }
    public class PuntosDeLasFichas : ISistemaDePuntaje
    {
        public int DevolverPuntos(int jugador)
        {
            int cant = 0;

            for (int i = 0; i < Domino.jugadores[jugador].FichasDelJugador.Count; i++)
            {
                cant += Domino.jugadores[jugador].FichasDelJugador[i].num1 + Domino.jugadores[jugador].FichasDelJugador[i].num2;
            }

            return cant;
        }
    }

    //Repartir fichas segun numero de huecos
    public class Repartir99 : IReparticion
    {
        public void RepartirFichas()
        {

            Random r = new Random();

            if (Domino.CantidadJugadores <= 4 )
                for (int i = 0; i < Domino.CantidadJugadores; i++)
                {
                    if (Domino.jugadores[i].FichasDelJugador.Count > 0)//en caso de que el jugador se haya quedado con fichas , las devuelve y reparte de nuevo
                        Domino.jugadores[i].FichasDelJugador.Clear();

                  
                    for (int j = 0; j < Domino.CantidadFichasARepartir; j++)
                    {
                        int fichaARepartir = r.Next(0, Domino.fichas.Count);
                        Domino.jugadores[i].RecogerFicha(Domino.fichas[fichaARepartir]);//El jugador coge su ficha
                        Domino.EliminarFichaDeLaMesa(Domino.fichas[fichaARepartir]);//se elimina d la mesa
                    }
                }
            else
            {
                while (true)
                {
                    if (Domino.fichas.Count < Domino.CantidadJugadores)//comprueba si quedan menos fichas a repartir que jugadores
                        break;

                    for (int j = 0; j < Domino.CantidadJugadores; j++)
                    {
                        int ficha_A_Repartir = r.Next(0, Domino.fichas.Count);
                        Domino.jugadores[j].RecogerFicha(Domino.fichas[ficha_A_Repartir]);//El jugador coge su ficha
                        Domino.EliminarFichaDeLaMesa(Domino.fichas[ficha_A_Repartir]);//se elimina d la mesa
                    }
                }
            }
        }
    }
    public class Repartir66 : IReparticion
    {
        public void RepartirFichas()
        {
            Random r = new Random();

            for (int i = 0; i < Domino.CantidadJugadores; i++)
            {
                if (Domino.jugadores[i].FichasDelJugador.Count > 0)//en caso de que el jugador se haya quedado con fichas , las devuelve y reparte de nuevo
                    Domino.jugadores[i].FichasDelJugador.Clear();

                for (int j = 0; j < Domino.CantidadFichasARepartir; j++)
                {
                    int ficha_A_Repartir = r.Next(0, Domino.fichas.Count);
                    Domino.jugadores[i].RecogerFicha(Domino.fichas[ficha_A_Repartir]);//El jugador coge su ficha
                    Domino.EliminarFichaDeLaMesa(Domino.fichas[ficha_A_Repartir]);//se elimina d la mesa
                }
            }

        }
    }

    //Comtrola como ver el juego
    public class Pausar : IMirar
    {
        public void Mirar()
        {
            Console.ReadKey(); //toca boton y juega
        }
    }
    public class MirarSeguido : IMirar
    {
        public void Mirar()
        {
            Thread.Sleep(2000);  // espera 2 segundos para jugar
        }
    }
}
