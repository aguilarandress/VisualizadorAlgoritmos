using UnityEngine.UI;
using UnityEngine;

using Utils;

public class Window_Graph : MonoBehaviour
{
    [SerializeField] private Sprite circuloSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        // Crear insertion sort
        CrearGraficaInsertionSort();
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
    // Mostrar grafico
    private void ShowGraph(int[] valueArr)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        // Valor maximo ingresado por Y
        float yMaximun = 220f;
        // Distancia entre cada valor de X 
        float xSize = 90f;
        for (int i = 0; i < valueArr.Length; i++)
        {
            // Spawnear circulo del resultado
            float xPosition = i * xSize;
            float yPosition = (valueArr[i] / yMaximun) * graphHeight;
            CreateCircle(new Vector2(xPosition + 20f, yPosition));
            // Crear label en el eje X
            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer.transform, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition + 20f, -10f);
            labelX.GetComponent<Text>().text = ((i + 1) * 1000).ToString();
        }
    }

    private void CrearGraficaInsertionSort()
    {
        int[] resultadosDeTiempo = new int[9];
        int cantidadDeElementosActual = 1000;
        // Agregar valores de tiempo al arreglo
        while (cantidadDeElementosActual < 10000)
        {
            // Medir tiempo segun cantidad de elementos
            var resultadoTiempo = ArraySorter.MedirInsertionSort(cantidadDeElementosActual);
            resultadosDeTiempo[cantidadDeElementosActual / 1000 - 1] = resultadoTiempo;
            cantidadDeElementosActual += 1000;
        }
        // Mostrar grafico
        ShowGraph(resultadosDeTiempo);
    }

    private void CrearGraficaMergeSort()
    {
        int[] resultadosDeTiempo = new int[9];
        int cantidadDeElementosActual = 1000;
        // Agregar valores de tiempo al arreglo
        while (cantidadDeElementosActual < 10000)
        {
            // Medir tiempo segun cantidad de elementos
            var resultadoTiempo = ArraySorter.MedirMergeSort(cantidadDeElementosActual);
            resultadosDeTiempo[cantidadDeElementosActual / 1000 - 1] = resultadoTiempo;
            cantidadDeElementosActual += 1000;
        }
        // Mostrar grafico
        ShowGraph(resultadosDeTiempo);
    }
}
