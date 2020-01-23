using System;
using System.Threading;

namespace ISC210_3
{
    class Program
    {
        public static Game currentGame;
        public static Thread inputThread;
        static void Main(string[] args)
        {
            currentGame = new Game();
            currentGame.GameInit();
            inputThread = new Thread(Input);
            inputThread.Start();

            while (currentGame.CurrentState != Game.eGameState.Over)
            {
                switch (currentGame.CurrentState)
                {
                    case Game.eGameState.Starting:
                        Console.WriteLine("Digite un valor entre 1 y 1000: ");
                        currentGame.CurrentState = Game.eGameState.Playing;
                        break;
                    
                    case Game.eGameState.Playing:
                        if (currentGame.lastTry == 0)
                            continue;
                        switch (currentGame.CheckIfGuessed())
                        {
                            case Game.AttemptResult.Greater:
                                Console.WriteLine("El numero secreto es menor.");
                                break;
                            case Game.AttemptResult.Lower:
                                Console.WriteLine("El numero secreto es mayor.");
                                break;

                            default:
                                Console.WriteLine("Ha adivinado!");
                                currentGame.CurrentState = Game.eGameState.Over;
                                break;
                        }
                        if (currentGame.CurrentState != Game.eGameState.Over)  
                            Console.WriteLine("Digite otro valor. ");
                        currentGame.lastTry = 0;
                        break;
                    
                    default:
                        break;
                }
            }
            //inputThread.Abort();
            //inputThread.Join();
            Console.WriteLine($"ha adivinado en {currentGame.Attempts} intentos");
            Console.WriteLine($"Ha tomado {currentGame.TimeSpent.TotalSeconds} segundos");
            Console.WriteLine("Gracias por jugar ");
            currentGame.SaveState();
        }

        static void Input()
        {
            
           int currentValue = 0;
           while (currentGame.CurrentState != Game.eGameState.Over)
           {
               currentValue = Convert.ToInt32(Console.ReadLine());
               currentGame.lastTry = currentValue;
           } 
        }
    }
}
