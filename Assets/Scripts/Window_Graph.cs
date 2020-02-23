using UnityEngine.UI;
using UnityEngine;

using Utils;

public class Window_Graph : MonoBehaviour
{
    [SerializeField] private Sprite circuloSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    public Button algorithmButton;

    private int[] numeroDeElementosArr = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000 };
    private int[] resultadosInsertionSort = new int[9];
    private int[] resultadosMergeSort = new int[9];

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        // Set btn event listeners
        algorithmButton = GameObject.Find("algorithmBtn").GetComponent<Button>();
        algorithmButton.onClick.AddListener(CambiarAlgoritmo);
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        // Generar resultados iniciales
        GenerarResuladosAlgoritmos();
        ShowGraph(resultadosInsertionSort);
    }

    private void CambiarAlgoritmo()
    {
        // Set title
        Text algorithmTitle = transform.Find("algorithmTitle").GetComponent<Text>();
        algorithmTitle.text = algorithmTitle.text == "Grafica Insertion Sort" ? "Grafica Merge Sort" : "Grafica Insertion Sort";
        // Cambiar coordenadas
        /*
        for ()
        {
            // TODO: Cambiar coordenadas
        }
        */
    }

    private void GenerarResuladosAlgoritmos()
    {
        for (int i = 0; i < numeroDeElementosArr.Length; i++)
        {
            resultadosInsertionSort[i] = ArraySorter.MedirInsertionSort(numeroDeElementosArr[i]);
            resultadosMergeSort[i] = ArraySorter.MedirMergeSort(numeroDeElementosArr[i]);
        }
    }

    // Crear un circulo con el sprite
    private void CreateCircle(Vector2 position)
    {
        // Crear game object
        GameObject circleObject = new GameObject("circle", typeof(Image));
        circleObject.transform.SetParent(graphContainer, false);
        circleObject.tag = "circleObject";
        // Set sprite
        circleObject.GetComponent<Image>().overrideSprite = circuloSprite;
        // Posicionar el circulo y asignar tamaño
        RectTransform rectTransform = circleObject.GetComponent<RectTransform>();
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
        float yMaximun = 216f;
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
        // Crear separadoers en el eje Y
        int separatorCount = 9;
        for (int i = 0; i < separatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer.transform, false);
            labelY.gameObject.SetActive(true);
            // Crear valor normalizado
            float normalizedValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-10f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue * yMaximun).ToString();
        }
    }
}
