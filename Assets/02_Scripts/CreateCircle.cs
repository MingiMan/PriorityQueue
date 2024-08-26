using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CreateCircle : MonoBehaviour
{
    const int maxCount = 5;
    int currentCount;
    GameObject circle;
    GameObject parent;
    HashSet<int> numbers = new HashSet<int>(); // 중복숫자제거

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

            int randomNum = GetUniqueRandomNumber();

            obj.GetComponent<CircleNumber>().AssignNumber(randomNum);
            currentCount++;
        }
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
