using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace programa17_Cola_Numeros_Flotantes
{
    internal class Program
    {
        class Colas
        {
            //campos de la clase
            int Max, Frente, Final, Apuntador;
            float[] cola;
            //constructor de la clase
            public Colas(int tamaño)
            {
                Max = tamaño;
                Frente = -1;
                Final = -1;
                cola = new float[tamaño];
               
                Console.WriteLine("\nLa cola ha sido creada con éxito.");
            }
            //métodos de la clase
            public void Encolar(float Elemento)
            {
                if (Frente == 0 && Final == Max - 1)
                {
                    Console.WriteLine("\nLa Cola está llena.");
                }
                else
                {
                    if (Frente == -1)
                    {
                        Frente = 0;
                        Final = 0;
                    }
                    else
                    {
                        Final = Final + 1;
                    }
                    cola[Final] = Elemento;
                }
            }

            public void Deseconcolar()
            {
                if (Frente != -1)
                {
                    Console.WriteLine("\nEliminando Dato: | " + cola[Frente] + " |");
                    
                    cola[Frente] = 0;
                    
                    if (Frente == Final)
                    {
                        Frente = -1;
                        Final = -1;
                    }
                    else
                    {
                        Frente = Frente + 1;
                    }
                }
                else
                {
                    Console.WriteLine("\nLa Cola está vacía.");
                }
            }
            public void Recorrido()
            {
                if (Frente != -1)
                {
                    Apuntador = Frente;
                    while (Apuntador <= Final)
                    {
                        Console.WriteLine("\nElemento: | " + cola[Apuntador] + " | en Posicion: | " + Apuntador + " |");
                        Apuntador = Apuntador + 1;
                    }
                }
                else
                {
                    Console.WriteLine("\nLa Cola está vacía.");
                }
            }
            public void Busqueda(float elemento)
            {
                if (Frente != -1)
                {
                    Apuntador = Frente;
                    while (Apuntador <= Final)
                    {
                        if (elemento == cola[Apuntador])
                        {
                            Console.WriteLine("\nDato: | " + elemento + " | encontrado en la posicion: | " + Apuntador + " |");
                            return;
                        }
                        Apuntador = Apuntador + 1;
                    }
                    Console.WriteLine("\nDato: | " + elemento + " | NO encontrado en la Cola.");
                }
                else
                {
                    Console.WriteLine("\nLa Cola está vacía.");
                }
            }
            //destructor de la clase
            ~Colas()
            {
                Console.WriteLine("\nMemoria Liberada Objeto Clase Colas");
            }
            static void Main(string[] args)
            {
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();

                long TotalInicio = GC.GetTotalMemory(true);
                char op = 'x';

                Colas n = null;

                do
                {
                    Console.Clear();
                    Console.WriteLine("\tCOLA Numeros Flotantes");
                    Console.WriteLine("\na) Crear la Cola.");
                    Console.WriteLine("b) Insertar un Elemento al Final.");
                    Console.WriteLine("c) Eliminar el Dato del Frente.");
                    Console.WriteLine("d) Recorrer la Cola.");
                    Console.WriteLine("e) Buscar un Elemento.");
                    Console.WriteLine("f) Salir del Programa.");
                    Console.Write("\nOpcion: ");

                    try
                    {
                        op = char.Parse(Console.ReadLine());

                        switch (op)
                        {
                            case 'a':

                                Console.Clear();
                                Console.Write("Ingrese el Tamaño de la Cola: ");
                                int tamaño = int.Parse(Console.ReadLine());

                                n = new Colas(tamaño);

                                break;
                            case 'b':

                                    Console.Clear();
                                    Console.Write("Ingrese Elemnto: ");
                                    float elemento = float.Parse(Console.ReadLine());

                                    n.Encolar(elemento);


                                break;

                            case 'c':

                                Console.Clear();
                                n.Deseconcolar();

                                break;

                            case 'd':

                                n.Recorrido();

                                break;

                            case 'e':

                                Console.Clear();
                                Console.Write("Elemento a Buscar: ");
                                float numero = float.Parse(Console.ReadLine());

                                n.Busqueda(numero);

                                break;

                            case 'f':

                                sw.Stop();
                                
                                TimeSpan ts = sw.Elapsed;

                                string tiempo = string.Format("{0:00}:{1:00}:{2:00}:{3:00}",ts.Hours,ts.Minutes,ts.Seconds,ts.Milliseconds);

                                Console.WriteLine("\nTIEMPO: " + tiempo);

                                long TotalFinal =System.GC.GetTotalMemory(false);

                                Console.WriteLine("MEMORIA EN BYTES: {0}",TotalFinal - TotalInicio);

                                sw.Restart();

                                break;

                            default:
                                Console.WriteLine("\nOpcion Invalida");
                                break;
                        }
                    }
                    catch (FormatException a)
                    {
                        Console.WriteLine("\n{0}", a.Message);
                    }
                    finally
                    {
                        Console.WriteLine("\nPresione <ENTER> Para Salir.");
                        Console.ReadKey();
                    }
                } while (op != 'f');
            }
        }
    }
}
