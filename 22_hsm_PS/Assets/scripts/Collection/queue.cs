using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queue : MonoBehaviour
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedListQueue<T>
    {
        private Node<T> front; // 큐의 맨 앞
        private Node<T> rear; // 큐의 맨 뒤

        public LinkedListQueue()
        {
            front = null;
            rear = null;
        }

        public void Enqueue(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (rear == null)
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
        }

        public T Dequeue()
        {
            if (front == null)
            {
                Debug.LogWarning("Queue is empty. Unable to dequeue.");
                return default(T);
            }
            T data = front.Data;
            front = front.Next;
            if (front == null)
            {
                rear = null;
            }
            return data;
        }

        public T Peek()
        {
            if (front == null)
            {
                Debug.LogWarning("Queue is empty. Unable to peek.");
                return default(T);
            }
            return front.Data;
        }

        public bool IsEmpty()
        {
            return front == null;
        }
    }
}
