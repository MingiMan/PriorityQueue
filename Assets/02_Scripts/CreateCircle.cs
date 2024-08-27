using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CreateCircle : MonoBehaviour
{
    const int maxCount = 5;
    static int currentCount;
    GameObject circle;
    GameObject parent;
    HashSet<int> numbers = new HashSet<int>();

    private void Awake()
    {
        parent = GameObject.Find("CreateCircle");
        circle = Resources.Load<GameObject>("Number");
    }


    private void Update()
    {
        Cricle();    
    }

    private void Cricle()
    {
        if (currentCount < maxCount && SlotLocation.Instance.Heap.Count <= 7)
        {
            GameObject obj = Instantiate(circle);
            obj.name = $"Circle_{currentCount}";
            obj.transform.SetParent(parent.transform);

            int randomNum = GetUniqueRandomNumber();

            obj.GetComponent<CircleNumber>().AssignNumber(randomNum);
            currentCount++;
        }
    }

    public static void DecreaseCount()
    {
        currentCount--;
    }

    int GetUniqueRandomNumber()
    {
        int randomNum;
        do
            randomNum = Random.Range(0, 71);
        while 
            (numbers.Contains(randomNum));
        numbers.Add(randomNum);
        return randomNum;
    }
}
