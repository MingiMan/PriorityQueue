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

    public void AssignNumber(int randomNum)
    {
        number = randomNum;
        numText.text = number.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SlotLocation.Instance.Push(this.gameObject,number);
    }
}
