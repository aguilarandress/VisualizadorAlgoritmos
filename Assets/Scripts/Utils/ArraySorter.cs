using System;
using System.Diagnostics;

namespace Utils
{
    class ArraySorter
    {
        private static Stopwatch stopwatch = new Stopwatch();

        public static int MedirInsertionSort(int numeroDeElementos)
        {
            // Crear arreglo con la cantidad de elementos
            int[] arregloAleatorio = GenerarRandomArray(numeroDeElementos);
            // Empezar a medir el tiempo
            stopwatch.Start();
            InsertionSort(arregloAleatorio);
            stopwatch.Stop();
            return stopwatch.Elapsed.Milliseconds;
        }

        public static void MedirStupidSort(int numeroDeElemento)
        {
            // TODO: CARLOS
        }

        // Generar arreglo de numeros enteros aleatorios
        public static int[] GenerarRandomArray(int numeroDeElementos)
        {
            int[] randomArr = new int[numeroDeElementos];
            Random randonNum = new Random();
            // Rellenar arreglo con numeros aleatorios
            for (int i = 0; i < randomArr.Length; i++)
            {
                randomArr[i] = randonNum.Next(numeroDeElementos);
            }
            return randomArr;
        }
        // Algoritmo de ordenamiento Insertion Sort
        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                // Almacenar valor actual
                int valorActual = arr[i];
                // Crear puntero
                int pointer = i - 1;
                while (pointer >= 0 && arr[pointer] > valorActual)
                {
                    arr[pointer + 1] = arr[pointer];
                    pointer -= 1;
                }
                arr[pointer + 1] = valorActual;
            }
        }
    }
}