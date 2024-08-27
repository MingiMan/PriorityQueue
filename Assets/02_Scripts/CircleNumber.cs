using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CircleNumber : MonoBehaviour, IPointerDownHandler
{
    TextMeshProUGUI numText;
    int number;
    bool IsLock;

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
        if(!IsLock)
        {
            SlotLocation.Instance.Push(this.gameObject,number);
            CreateCircle.DecreaseCount();
            IsLock = true;
        }
    }
}
