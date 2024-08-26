using UnityEngine;
using TMPro;

public class CreateCircle : MonoBehaviour
{
    const int maxCount = 5;
    int currentCount;
     GameObject circle;
     GameObject parent;

    private void Awake()
    {
        parent = GameObject.Find("CreateCircle");
        circle = Resources.Load<GameObject>("Number");
    }

    private void Start()
    {
        Cricle();
    }

    private void Cricle()
    {
        while (currentCount < maxCount)
        {
            GameObject obj = Instantiate(circle);
            obj.name = $"Circle_{currentCount}";
            obj.transform.SetParent(parent.transform);
            currentCount++;
        }
    }
}
