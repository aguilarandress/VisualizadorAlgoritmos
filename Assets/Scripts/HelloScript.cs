using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils;

public class HelloScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var result = ArraySorter.MedirInsertionSort(1000);
        Debug.Log($"El algoritmo duro {result} milisegundos");
        result = ArraySorter.MedirMergeSort(1000);
        Debug.Log($"El algoritmo duro {result} milisegundos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
