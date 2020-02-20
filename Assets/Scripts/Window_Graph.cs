using UnityEngine.UI;
using UnityEngine;
using Utils;

public class Window_Graph : MonoBehaviour
{
    [SerializeField] private Sprite circuloSprite;
    private RectTransform graphContainer;

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        // Prueba del Insertion sort
        var result = ArraySorter.MedirInsertionSort(9000);
        Debug.Log($"El algoritmo duro {result} milisegundos");


        // Prueba del merge sort
        result = ArraySorter.MedirMergeSort(9000);
        Debug.Log($"El algoritmo duro {result} milisegundos");
    }
    // Crear un circulo con el sprite
    public void CreateCircle(Vector2 position)
    {
        // Crear game object
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        // Set sprite
        gameObject.GetComponent<Image>().sprite = circuloSprite;
        // Posicionar el circulo y asignar tamaño
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    private void ShowGraph(int[] valueArr)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        // Valor maximo ingresado por Y
        float yMaximun = 200f;
        // Distancia entre cada valor de X 
        float xSize = 10f;
        for (int i = 0; i < valueArr.Length; i++)
        {
            float xPosition = i * xSize;
            float yPosition = (valueArr[i] / yMaximun) * graphHeight;
            CreateCircle(new Vector2(xPosition, yPosition));
        }
    }
}
