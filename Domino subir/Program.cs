using domino;
using jugador;
using Tipos_de_Jugadores;
using config;

Console.BackgroundColor=ConsoleColor.Blue;
Console.Clear();
Console.ForegroundColor=ConsoleColor.Black;

Domino domino = new Domino();
  

Console.WriteLine("MENU");
//-----------------------------------------------------------------
Console.WriteLine("\nTipo de juego");
Console.WriteLine("1-Doble 6\n2-Doble 9");
int n = int.Parse(Console.ReadLine());
Configuracion.MaxFicha = n;
Domino.DefinicionJuego();

//-------------------------------------------------------------------
Console.WriteLine("Cantidad de jugadores");
Domino.CantidadJugadores = int.Parse(Console.ReadLine());
Domino.jugadores = new JUGADOR[Domino.CantidadJugadores];

while (Domino.CantidadJugadores == 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("No puede jugar solo!!");
    Console.ForegroundColor = ConsoleColor.Black;
    Domino.CantidadJugadores = int.Parse(Console.ReadLine());
}
//-------------------------------------------------------------------
Console.WriteLine("Tipos de jugadores: ");
Console.WriteLine("1-Bota Gorda\n2-Aleatorio\n3-Tramposo");
for (int i = 0; i < Domino.CantidadJugadores; i++)
{
    Console.WriteLine("Jugador {0}",i+1);
    int TiposJugadores = int.Parse(Console.ReadLine());

    switch (TiposJugadores)
    { 
        case 1: Domino.jugadores[i] = new BotaGorda(); break;
        case 2: Domino.jugadores[i] = new Aleatorio();break;
        case 3: Domino.jugadores[i] = new Tramposo();break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Seleccion incorrecta, se selecciona el Bota Gorda");
            Console.ForegroundColor = ConsoleColor.Black;
            Domino.jugadores[i] = new BotaGorda();
            break;
    }

    Domino.jugadores[i].Equipo = i % 2;
    Domino.jugadores[i].numeroJugador = i;

}
//--------------------------------------------------------------------------------
Console.WriteLine("\nInicio del juego");
Console.WriteLine("1-Salida Aleatoria\n2-Mayor Ficha\n3-Pares o nones");

if ((Domino.CantidadJugadores == 4 && Configuracion.MaxFicha==1)||
    (Domino.CantidadJugadores >5 && Domino.NumeroMaximoFichas == 9))
{
    //no quedarian fichas para decidir
    Configuracion.Inicio = 4;
    Console.WriteLine("Se inicia con el Mayor Doble!! No tiene mas opciones");
}
else if (Domino.CantidadJugadores > 4 && Domino.NumeroMaximoFichas == 9)
{
    Configuracion.Inicio = 1;
    Console.WriteLine("Salida aleatoria");
}
else
{ 
    Configuracion.Inicio = int.Parse(Console.ReadLine());

    //---------------------------------------------------------------------
    //solo variar el pase si sobran varias fichas
    Console.WriteLine("\nPases");
    Console.WriteLine("1-Pase usual\n2-Robar ficha si no lleva");
    Configuracion.Pases = int.Parse(Console.ReadLine());
}
//------------------------------------------------------------------------------
Console.WriteLine("\nFinal de partida");
Console.WriteLine("1-Fin usual\n2-Fin doble pase");
Configuracion.FinalPartida = int.Parse(Console.ReadLine());

//-----------------------------------------------------------------------------
Console.WriteLine("\nFinal del juego");
Console.WriteLine("1-Por partidas\n2-Acumulacion de puntos");
Configuracion.FinalJuego = int.Parse(Console.ReadLine());

if(Configuracion.FinalJuego==1)
{
    Console.WriteLine("Cuantas partidas desea jugar:");
    Configuracion.CantidadPartidas = int.Parse(Console.ReadLine());
}
//-----------------------------------------------------------------------------
if (Configuracion.FinalJuego == 1)
{
    Console.WriteLine("\nSistema de puntaje");
    Console.WriteLine("1-Fichas por puntos(se cuentan los puntos que tien cada ficha)\n2-Cantidad de fichas(cada ficha cuenta como 1 punto, los dobles cuentan como 2 pts)");
    Configuracion.Puntaje = int.Parse(Console.ReadLine());
}
else
{//Si el juego es por puntos se toman los puntos clasicos
    Configuracion.Puntaje = 1;
}

//--------------------------------------------------------------------------
Console.WriteLine("\nComo desea observar el juego?");
Console.WriteLine("1-Pausandolo\n2-Seguido");
Configuracion.ver = int.Parse(Console.ReadLine());

//--------------------------------------------------------------------------------
Console.WriteLine("\nHa terminado de elegir sus configuraciones ;)");
Thread.Sleep(2000);

Console.BackgroundColor = ConsoleColor.DarkCyan;
Console.Clear();
Domino.Play();



