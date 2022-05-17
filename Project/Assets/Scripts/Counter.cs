using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] int max;
    public UnityEvent actionWhenCounterToMax;
    public UnityEvent actionWhenCounterIncrement;
    public UnityEvent actionWhenCounterDecrement;

    private int count = 0;

    static public Counter operator ++(Counter c)
    {
        c.increment();
        return c;
    }

    static public Counter operator --(Counter c)
    {
        c.decrement();
        return c;
    }

    // Increment and execute action on increment if possible
    public void increment()
    {
        if (this.count >= this.max) return;
        this.count++;
        if (actionWhenCounterIncrement != null)
        {
            this.actionWhenCounterIncrement.Invoke();
        }
        if(this.count == max && actionWhenCounterToMax != null)
        {
            this.actionWhenCounterToMax.Invoke();
        }
    }
    
    // Decrement and execute action on decrement if possible
    public void decrement()
    {
        if (this.count <= 0) return;
        this.count--;
        if (actionWhenCounterDecrement != null)
        {
            this.actionWhenCounterDecrement.Invoke();
        }
    }

    public void addToCount(int toAdd)
    {
        if (toAdd == 0) return;
        if(toAdd > 0)
        {
            for(int i=0; i < toAdd ; i++)
            {
                if (this.count >= this.max) return;
                this.increment();
            }
        } else
        {
            for (int i = 0; i < -toAdd; i++)
            {
                if (this.count <= 0) return;
                this.decrement();
            }
        }
    }

    public void Reset()
    {
        count = 0;
    }
}
