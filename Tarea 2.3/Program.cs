using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RecursividadProfundidad
{
    class Program
    {
        // Método recursivo para resolver las Torres de Hanói
        // Profundidad de llamada determinada por 'n' (número de discos)
        static void ResolverHanoi(int n, char origen, char auxiliar, char destino, ref long contadorMovimientos)
        {
            // CASO BASE: Si no hay discos, terminamos
            if (n == 0)
            {
                return;
            }

            // CASO RECURSIVO 1: Mover n-1 discos del origen al auxiliar
            ResolverHanoi(n - 1, origen, destino, auxiliar, ref contadorMovimientos);

            // Acción principal del nivel actual: mover el disco restante
            contadorMovimientos++;

            // CASO RECURSIVO 2: Mover n-1 discos del auxiliar al destino
            ResolverHanoi(n - 1, auxiliar, origen, destino, ref contadorMovimientos);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(" Tarea 2.3: Implementación y Análisis de Recursividad");
            Console.WriteLine("==================================================\n");

            // Probamos diferentes profundidades (tamaños de entrada / n discos)
            int[] profundidadesPrueba = { 3, 4, 5, 10, 15, 20 };

            foreach (int n in profundidadesPrueba)
            {
                long movimientos = 0;

                // Cronómetro para medir el tiempo de ejecución según la profundidad
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Ejecución del algoritmo recursivo
                ResolverHanoi(n, 'A', 'B', 'C', ref movimientos);

                stopwatch.Stop();

                // Análisis de resultados por cada profundidad
                Console.WriteLine($"[Profundidad n = {n}]");
                Console.WriteLine($"  - Total de llamadas / movimientos: {movimientos:N0}");
                Console.WriteLine($"  - Tiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms");
                Console.WriteLine($"  - Fórmula teórica (2^n - 1): {(Math.Pow(2, n) - 1):N0}\n");
            }

            Console.WriteLine("==================================================");
            Console.WriteLine(" Análisis completado con éxito.");
            Console.WriteLine("==================================================");
        }
    }
}