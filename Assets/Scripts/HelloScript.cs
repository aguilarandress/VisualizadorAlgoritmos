using UnityEngine.UI;
using UnityEngine;
using Utils;

public class HelloScript : MonoBehaviour
{
    [SerializeField] private Sprite circuloSprite;
    public RectTransform graphContainer;
    // Start is called before the first frame update
    void Start()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();

        var result = ArraySorter.MedirInsertionSort(5000);
        Debug.Log($"El algoritmo duro {result} milisegundos");
        crearCirculo(new Vector2(600, result));
        result = ArraySorter.MedirMergeSort(5000);
        Debug.Log($"El algoritmo duro {result} milisegundos");
        crearCirculo(new Vector2(600, result));

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void crearCirculo(Vector2 position)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circuloSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

    }
}
