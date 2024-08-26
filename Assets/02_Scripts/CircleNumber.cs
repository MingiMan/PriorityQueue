using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CircleNumber : MonoBehaviour, IPointerDownHandler
{
    TextMeshProUGUI numText;
    int number;

    void Awake()
    {
        numText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        number = Random.Range(0, 71);
        numText.text = number.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
