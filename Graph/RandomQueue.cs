using System;
using System.Collections;
using System.Collections.Generic;


public class RandomQueue<E>
{

    private List<E> queue;
    Random r = new Random();

    public RandomQueue()
    {
        queue = new List<E>();
    }

    public void Enqueue(E e)
    {
        queue.Add(e);
    }

    public E Dequeue()
    {
        //随机索引randIndex 
        int randIndex = (int)(r.NextDouble() * queue.Count);

        //取出随机索引元素e
        E e = queue[randIndex];

        //最后一个元素,覆盖代替元素e
        queue[randIndex] = queue[queue.Count - 1];

        //删掉最后一个元素
        queue.RemoveAt(queue.Count - 1);

        //返回元素e
        return e;
    }

    public int Count { get { return queue.Count; } }
    public bool IsEmpty { get { return queue.Count == 0; } }
}
