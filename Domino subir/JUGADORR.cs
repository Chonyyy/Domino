using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mesa;
using ficha;

namespace jugador
{
    public abstract class JUGADOR 
    {
        public List<FICHA> FichasDelJugador;
        public List<FICHA> Fichas_Tiradas;
        public List<int> Pases;
        public int numeroJugador;
        public int Equipo { get; set; }
        //public string Nombre { get; set; }
        public int Numero { get; set; }
        public JUGADOR()
        {
            FichasDelJugador = new List<FICHA>();
            Fichas_Tiradas = new List<FICHA>();
            Pases = new List<int>();
        }
        public void RecogerFicha(FICHA ficha)
        {
            FichasDelJugador.Add(ficha);
        }
        public void TirarFicha(FICHA ficha)
        {
            //Seleccion de las fichas de acuerdo a los numeros 
            FichasDelJugador.Remove(FichasDelJugador.Find(x => x.num1 == ficha.num1 && x.num2 == ficha.num2));
            MESA.Colocar_Ficha(ficha);
            Fichas_Tiradas.Add(ficha);

        }
        public FICHA TirarFichaEscogida()
        {            
           
            FICHA ficha = Escoger(FichasDelJugador); 
            TirarFicha(ficha);
            return ficha;

        }
        public  List<FICHA> fichas_que_Lleva_Jugador(FICHA extremos)
        {
            if (extremos == null)
                return null!;
           
            return FichasDelJugador.Where(a => a.num1 == extremos.num1
                                         || a.num1 == extremos.num2
                                         || a.num2 == extremos.num1
                                         || a.num2 == extremos.num2
                                          ).ToList();

            //var c =Fichas_del_Jugador.OrderBy(a=>a.num1).ToList();

            //var b = Fichas_del_Jugador.OrderByDescending(a => a.num1).ToList();

        }
        public abstract FICHA Escoger(List<FICHA> Fichas_posibles);
    }

}
