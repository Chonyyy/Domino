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
        public List<FICHA> FichasTiradas;
        public List<int> Pases;
        public int numeroJugador;
        public int Equipo { get; set; }
        //public string Nombre { get; set; }
        public int Numero { get; set; }
        public JUGADOR()
        {
            FichasDelJugador = new List<FICHA>();
            FichasTiradas = new List<FICHA>();
            Pases = new List<int>();
        }
        public void RecogerFicha(FICHA ficha)
        {
            //el jugador coge una ficha de la mesa y la guarda 
            FichasDelJugador.Add(ficha);
        }
        public void TirarFicha(FICHA ficha)
        {
            //Seleccion de las fichas de acuerdo a los numeros 
            FichasDelJugador.Remove(FichasDelJugador.Find(x => x.num1 == ficha.num1 && x.num2 == ficha.num2));
            MESA.ColocarFicha(ficha);
            FichasTiradas.Add(ficha);

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

           //crea una lista con las fichas que lleva el jugador de acuerdo a los extremos
            return FichasDelJugador.Where(a => a.num1 == extremos.num1
                                         || a.num1 == extremos.num2
                                         || a.num2 == extremos.num1
                                         || a.num2 == extremos.num2
                                          ).ToList();

        }
        public abstract FICHA Escoger(List<FICHA> Fichas_posibles);
        //metodo abstracto para que cada jugador elija de forma independiente
    }

}
