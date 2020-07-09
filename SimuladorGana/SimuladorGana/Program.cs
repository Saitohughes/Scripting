using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorGana
{
    class Program
    {
        static void Main(string[] args)
        {
            //aquí defino los dos arreglos para los numeros
            int[] numeroJugado = new int[4];
            int valorJugado = 0;
           

            //aqui relleno el numero del jugador
            Console.WriteLine("Hola bienvenido a Gana");
            
            try
            {
                Console.WriteLine("ingrese el valor a jugar");
                valorJugado = int.Parse(Console.ReadLine());

                for (int i = 0; i < numeroJugado.Length; i++)
                {
                    Console.WriteLine("ingrese el numero {0} ", i+1);
                    numeroJugado[i] = int.Parse(Console.ReadLine());
                }


            }
            catch (FormatException error)
            {
                Console.WriteLine("hey ingresaste un dato que no es numero, intenta de nuevo");
                Console.WriteLine("Error: " + error.Message + "\n");

            }
            int premio  = GetGanador(numeroJugado, valorJugado);

            Console.WriteLine("Hola tu resultado en la loteria fue: ");
            Console.WriteLine("apostate: {0} , y ganaste {1}", valorJugado, premio);

           
        }

        static int GetGanador(int[] numeroJugado1, int valorJugado1)
        {
            //aqui Genero el Numero ganador
            int[] numeroGanador = new int[4];
            Random aleatorio = new Random();
            int contadorAciertos = 0;
            int premio = 0;
            int placeholder;

            for (int i = 0; i < numeroGanador.Length; i++)
            {
                numeroGanador[i] = aleatorio.Next(0, 10);
            }

            //aqui cuento los aciertos en la posicion normal
            for (int i = 0; i < numeroGanador.Length; i++)
            {
                if (numeroGanador[i] == numeroJugado1[i])
                {
                    contadorAciertos += 1;
                }
            }

            if (contadorAciertos >= 4)
            {
                premio = valorJugado1 * 45000;
            }
            else
            {
                if (numeroGanador[1] == numeroJugado1[1]
                    && numeroGanador[2] == numeroJugado1[2]
                    && numeroGanador[3] == numeroJugado1[3])
                    premio = valorJugado1 * 400;
                else
                    if (numeroGanador[2] == numeroJugado1[2] && numeroGanador[3] == numeroJugado1[3])
                {
                    premio = valorJugado1 * 50;
                }
                else
                    if (numeroGanador[3] == numeroJugado1[3])
                    premio = valorJugado1 * 5;
                else
                {

                    for (int i = 0; i < numeroGanador.Length; i++)
                    {
                        for (int j = 0; j < numeroGanador.Length - 1; j++)
                        {
                            if (numeroGanador[j] > numeroGanador[j + 1])
                            {
                                placeholder = numeroGanador[j];
                                numeroGanador[j] = numeroGanador[j + 1];
                                numeroGanador[j + 1] = placeholder;
                            }

                            if (numeroJugado1[j] > numeroJugado1[j + 1])
                            {
                                placeholder = numeroJugado1[j];
                                numeroJugado1[j] = numeroJugado1[j + 1];
                                numeroJugado1[j + 1] = placeholder;
                            }

                        }

                        if (numeroGanador[i] == numeroJugado1[i])
                        {
                            contadorAciertos += 1;
                        }

                        if (contadorAciertos <= 4)
                            premio = valorJugado1 * 200;
                    }
                }
            }

            

            return premio;
        }
    }
}
