using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackWithTwoQueues<T> : MonoBehaviour
{
    private Queue<T> queue1 = new Queue<T>();
    private Queue<T> queue2 = new Queue<T>();

    // ������ Push ������ �����մϴ�.
    public void Push(T value)
    {
        // queue2�� ��Ҹ� ��� �̵���ŵ�ϴ�.
        while (queue1.Count > 0)
        {
            queue2.Enqueue(queue1.Dequeue());
        }

        // ���ο� ��Ҹ� queue1�� �����մϴ�.
        queue1.Enqueue(value);

        // queue2�� ��� ��Ҹ� �ٽ� queue1�� �̵���ŵ�ϴ�.
        while (queue2.Count > 0)
        {
            queue1.Enqueue(queue2.Dequeue());
        }
    }

    // ������ Pop ������ �����մϴ�.
    public T Pop()
    {
        // queue1���� ���� �տ� �ִ� ��Ҹ� ��ȯ�մϴ�.
        return queue1.Dequeue();
    }

    // ������ Peek ������ �����մϴ�.
    public T Peek()
    {
        // queue1���� ���� �տ� �ִ� ��Ҹ� ��ȯ�մϴ�.
        return queue1.Peek();
    }

    // ������ ����ִ��� Ȯ���ϴ� ������ �����մϴ�.
    public bool IsEmpty()
    {
        return queue1.Count == 0;
    }
}