using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;
using TMPro;
using UnityEditor;

public class SlotLocation : MonoBehaviour
{
    public static SlotLocation Instance;
    List<Transform> arrayPos = new List<Transform>();
    List<int> heap = new List<int>();
    public List<int> Heap { get { return heap; }set { heap = value;}}

    Dictionary<int,GameObject> node = new Dictionary<int,GameObject>();

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

        int now = heap.Count - 1;

        if (now > arrayPos.Count - 1)
            return;

        Vector2 targetPosition = arrayPos[now].transform.position;
        StartCoroutine(SmoothMove(circleObj, targetPosition));
        circleObj.transform.SetParent(arrayPos[now].transform);
        node.Add(now, circleObj);

        while (now > 0)
        {
            int parent = (now - 1) / 2;

            if (heap[now] <= heap[parent])
                break;

            int temp = heap[parent];
            heap[parent] = heap[now];
            heap[now] = temp;
            CircleBlink(node[parent], circleObj);
            StartCoroutine(SwapMove(node[parent], circleObj,parent,now));
            SwapNodeValues(parent, now);
            now = parent;
        }
    }


    IEnumerator SmoothMove(GameObject obj, Vector2 targetPosition)
    {
        Vector2 initialPosition = obj.transform.position;
        float elapsedTime = 0;
        float duration = 0.5f;

        while (elapsedTime < duration)
        {
            obj.transform.position = Vector2.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = targetPosition;
    }

    void CircleBlink(GameObject parent,GameObject now)
    {
        parent.GetComponent<Animator>().SetTrigger("Warning");
        now.GetComponent<Animator>().SetTrigger("Warning");
    }

    IEnumerator SwapMove(GameObject parent, GameObject now,int up, int down)
    {
        float elapsedTime = 0f;
        float duration = 0.5f;

        while (elapsedTime < duration)
        {
            parent.transform.position = Vector2.Lerp(parent.transform.position, arrayPos[down].transform.position, elapsedTime / duration);
            now.transform.position = Vector2.Lerp(now.transform.position, arrayPos[up].transform.position, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        parent.transform.position = arrayPos[down].transform.position;
        now.transform.position = arrayPos[up].transform.position;
        now.transform.SetParent(arrayPos[up].transform);
        parent.transform.SetParent(arrayPos[down].transform);
    }

    private void SwapNodeValues(int index1, int index2)
    {
        GameObject tempObj = node[index1];
        node[index1] = node[index2];
        node[index2] = tempObj;
    }
}

