using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        public static int MedirMergeSort(int numeroDeElemento)
        {      

           
            
            List<int> unsorted = new List<int>();
            List<int> sorted;
            //Genera una lista aleatoria
            Random random = new Random();
            for (int i = 0; i < numeroDeElemento; i++)
            {
                unsorted.Add(random.Next(numeroDeElemento));

            }
            // Empezar a medir el tiempo
            stopwatch.Start();
            sorted = MergeSort(unsorted);
            stopwatch.Stop();
            return stopwatch.Elapsed.Milliseconds;
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
        //Algoritmo de ordenamiento Merge Sort
        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }


        }
}
