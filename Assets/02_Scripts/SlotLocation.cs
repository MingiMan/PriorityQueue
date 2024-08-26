using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class SlotLocation : MonoBehaviour
{
    public static SlotLocation Instance;
    List<Transform> arrayPos = new List<Transform>();
    List<int>heap = new List<int>();
    List<GameObject> objects = new List<GameObject>();

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Start()
    {
        foreach (Transform i in this.gameObject.GetComponentInChildren<Transform>())
            arrayPos.Add(i);
    }

    public void Push(GameObject circleObj,int number)
    {
        heap.Add(number);
        objects.Add(circleObj);

        int now = heap.Count - 1;

        if (now > arrayPos.Count - 1)
            return;

        while(now > 0)
        {
            int parent = (now - 1) / 2;

            if (heap[now] <= heap[parent])
                break;


            now = parent;
        }
        circleObj.transform.position = arrayPos[now].transform.position;
    }


}

