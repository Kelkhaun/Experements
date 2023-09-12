using System.Collections.Generic;
using UnityEngine;

public class SubscribersList<TSubscriber> where TSubscriber : class
{
    public readonly List<Subscriber<TSubscriber>> Subscribers = new();

    private bool _isNeedCleanUp = false;
    private bool _isExecuting;

    public void SwitchExecuting(bool state)
    {
        _isExecuting = state;
    }

    public void Add(TSubscriber subscriber, int priority = 0)
    {
        Subscriber<TSubscriber> newSubscriber = new Subscriber<TSubscriber>(subscriber, priority);
        Subscribers.Add(newSubscriber);
        
        Subscribers.Sort((s1, s2) => s2.Priority.CompareTo(s1.Priority));
    }

    public void Remove(TSubscriber subscriber)
    {
        Subscriber<TSubscriber> subscriberToRemove = SearchSubscribe(subscriber);

        if (_isExecuting)
        {
            int i = Subscribers.IndexOf(subscriberToRemove);

            if (i >= 0)
            {
                _isNeedCleanUp = true;
                Subscribers[i] = null;
            }
        }
        else
        {
            Subscribers.Remove(subscriberToRemove);
        }
    }

    public void Cleanup()
    {
        if (!_isNeedCleanUp)
            return;

        Subscribers.RemoveAll(s => s == null);
        _isNeedCleanUp = false;
    }

    private Subscriber<TSubscriber> SearchSubscribe(TSubscriber subscriber)
    {
        for (int i = 0; i < Subscribers.Count; i++)
        {
            if (Subscribers[i].T == subscriber)
                return Subscribers[i];
        }

        Debug.Log("Not found subscriber");
        return null;
    }
}