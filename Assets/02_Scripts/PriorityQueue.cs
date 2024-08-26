using UnityEngine;
using System.Collections.Generic;
using System;

public class PriorityQueue
{
    List<int>heap = new List<int>();

    public void Push(int data)
    {
        heap.Add(data);

        int now = heap.Count - 1;

        while(now > 0)
        {
            int parent = (now - 1) / 2;

            if (heap[now] <= heap[parent])
                break;

            int temp = heap[now];
            heap[now] = heap[parent];
            heap[parent] = temp;
            
            now = parent;
        }
    }

    public int Pop()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("아무것도 없다.");

        int result = heap[0];
        int lastIndex = heap.Count - 1;

        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);
        lastIndex--;
        int now = 0;

        while (true)
        {
            int left = (now * 2) + 1;
            int right = (now * 2) + 2;

            int next = now;

            if (left <= lastIndex && heap[next] < heap[left])
                next = left;

            if (right <= lastIndex && heap[next] < heap[right])
                next = right;

            if (next == now)
                break;

            int temp = heap[now];
            heap[now] = heap[next];
            heap[next] = temp;

            now = next;
        }

        return result;
    }

    public int Count()
    {
        return heap.Count;
    }
}
