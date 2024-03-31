using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackWithTwoQueues<T> : MonoBehaviour
{
    private Queue<T> queue1 = new Queue<T>();
    private Queue<T> queue2 = new Queue<T>();

    // 스택의 Push 연산을 구현합니다.
    public void Push(T value)
    {
        // queue2에 요소를 모두 이동시킵니다.
        while (queue1.Count > 0)
        {
            queue2.Enqueue(queue1.Dequeue());
        }

        // 새로운 요소를 queue1에 삽입합니다.
        queue1.Enqueue(value);

        // queue2의 모든 요소를 다시 queue1로 이동시킵니다.
        while (queue2.Count > 0)
        {
            queue1.Enqueue(queue2.Dequeue());
        }
    }

    // 스택의 Pop 연산을 구현합니다.
    public T Pop()
    {
        // queue1에서 가장 앞에 있는 요소를 반환합니다.
        return queue1.Dequeue();
    }

    // 스택의 Peek 연산을 구현합니다.
    public T Peek()
    {
        // queue1에서 가장 앞에 있는 요소를 반환합니다.
        return queue1.Peek();
    }

    // 스택이 비어있는지 확인하는 연산을 구현합니다.
    public bool IsEmpty()
    {
        return queue1.Count == 0;
    }
}