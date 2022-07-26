
namespace DominoConfiguracion
{

    public abstract class Configuracion
    {
        //clase abstracta donde se establece las configuraciones necesarias para iniciar el juego
        
        public int numjugadores;
        public int numNPartidass;
        public int numFichas;
        public int Inicio;
        public int FinalPartida;
        public int FinalJuego;
        public int Puntaje;
        public int Pases;
        public int CantidadPartidas;
        public int MaxFicha;
        public int ver;


        public abstract void DefinicionJuego();
    }


}
