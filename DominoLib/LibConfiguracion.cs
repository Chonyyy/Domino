
using domino;
using FinalesJuego;
using inicio;
using fin_de_partida;
using variantes;
using DominoConfiguracion;

namespace config
{
    public   class Configuracion: _Configuracion
    {
        //Establece la configuracion inicial del juego
        public override void DefinicionJuego()
        {
                switch (MaxFicha)
                {
                    case 1: Domino.NumeroMaximoFichas = 6;
                        Domino.CantidadFichasARepartir = 7;
                        Domino.reparticion = new Repartir66();
                        break;

                    case 2: Domino.NumeroMaximoFichas = 9;
                        Domino.CantidadFichasARepartir = 10;
                        Domino.reparticion = new Repartir99();
                        break;

                    default: Console.WriteLine("Seleccion incorrecta, se selecciona el 9");
                        Domino.NumeroMaximoFichas = 9;
                        Domino.CantidadFichasARepartir = 10;
                        Domino.reparticion = new Repartir99();
                        break;
                }
            
            switch (Inicio)
            {
                case 1: Domino.inicio = new SalidaAleatoria(); break;
                case 2: Domino.inicio = new FichaMasGrande(); break;
                case 3: Domino.inicio = new ParesNones(); break;
                case 4: Domino.inicio = new MayorDoble(); break;
                default: Console.WriteLine("Seleccion incorrecta, se selecciona el 1");
                    Domino.inicio = new SalidaAleatoria();
                    break;
            }
            switch (FinalPartida)
            {
                case 1: Domino.finalP = new JuegoTrancado(); break;
                case 2: Domino.finalP = new FinDoblePase(); break;
                default: Console.WriteLine("Seleccion incorrecta, se selecciona el 1");
                     Domino.finalP = new JuegoTrancado(); 
                    break;
            }
            switch (Puntaje)
            {
                case 1: Domino.pts = new PuntosDeLasFichas(); break;
                case 2: Domino.pts = new PuntosSimples(); break;
                default: Console.WriteLine("Seleccion incorrecta, se selecciona el 1");
                     Domino.pts = new PuntosDeLasFichas(); 
                    break;
            }
            switch (Pases)
            {
                case 1: Domino.pase = new PaseUsual(); break;
                case 2: Domino.pase = new AdicionarFichaSiNoLleva(); break;
                default: Console.WriteLine("Seleccion incorrecta, se selecciona el 1");
                       Domino.pase = new PaseUsual();
                    break;
            }
            switch (ver)
            {
                case 1: Domino.Verjuego = new Pausar(); break;
                case 2: Domino.Verjuego = new MirarSeguido(); break;
                default:
                    Console.WriteLine("Seleccion incorrecta, se selecciona el 2");
                    Domino.Verjuego = new MirarSeguido();
                    break;
            }
             switch (FinalJuego)
            {
                case 1: Domino.finalJ = new PorPartidas(CantidadPartidas); break;
                case 2: Domino.finalJ = new AcumulacionDePuntos(); break;
                default: Console.WriteLine("Seleccion incorrecta, se selecciona el 2");
                    Domino.finalJ = new AcumulacionDePuntos(); 
                    break;
            }
            
        }

    }
}
