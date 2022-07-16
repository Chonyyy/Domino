using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mesa;
using domino;
using Final_del_juego;
using Desarrollo_del_Juego;
using partidas;

namespace FinalesJuego
{
    public class PorPartidas : IFinJuego
    {
        int numeroPartidas;
        public PorPartidas(int numeroPartidas)
        {
            this.numeroPartidas = numeroPartidas;
        }
        public string Tipo()
        {
            return GetType().Name;//"PorPartidas";
        }
        public bool Final()
        {
            if ((Domino.equipos[0] == numeroPartidas / 2 + 1) || (Domino.equipos[1] == numeroPartidas / 2 + 1))
            {
                return true;
            }

            return false;
        }
        public void Accion(Juego j)
        {
            Domino.partida.Add(new Partidas(j.ganador));
            Domino.equipos[j.ganador.Equipo]++;
        }
        public int EquipoGanador()
        {
            if (Domino.equipos[0] == Domino.equipos[1])
            {
                Juego j = new Juego();
                j.jugar();
                Domino.partida.Add(new Partidas(j.ganador));
                Domino.equipos[j.ganador.Equipo]++;
            }
            return (Domino.equipos[0] > Domino.equipos[1]) ? 0 : 1;
        }
    }
    public class AcumulacionDePuntos : IFinJuego
    {
        int equipoGanador = 0;
        public string Tipo()
        {
            return GetType().Name;
        }
        public bool Final()
        {
            for (int i = 0; i < MESA.puntosPorEquipos.Length; i++)
            {
                if (MESA.puntosPorEquipos[i] >= 100)
                {
                    Console.WriteLine("El equipo {0} gano con {1} puntos.", i, MESA.puntosPorEquipos[i]);
                    equipoGanador = i;
                    return true;
                }
            }
            return false;
        }
        public void Accion(Juego j)   { SumaPuntos(); }
        private void SumaPuntos()
        {
            for (int i = 0; i < MESA.puntosPorEquipos.Length; i++)
            {
                if (i == equipoGanador)//Para no sumar los puntos de el mismo
                    continue;

                for (int j = 0; j < Domino.jugadores.Length; j++)
                {
                    if (Domino.jugadores[j].Equipo != equipoGanador)
                    {
                        //suma los puntos del equipo perdedor al ganador
                        for (int f = 0; f < Domino.jugadores[j].FichasDelJugador.Count; f++)
                        {
                            MESA.puntosPorEquipos[equipoGanador] += Domino.jugadores[j].FichasDelJugador[f].num1;
                            MESA.puntosPorEquipos[equipoGanador] += Domino.jugadores[j].FichasDelJugador[f].num2;

                        }
                    }
                }

            }
        }
        public int EquipoGanador()
        {
            return equipoGanador;
        }
    }
}

