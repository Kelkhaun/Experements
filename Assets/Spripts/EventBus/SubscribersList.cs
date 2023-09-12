using System.Collections.Generic;

public class SubscribersList<TSubscriber> where TSubscriber : class
{
    private readonly List<TSubscriber> _subscribers = new();
    
    private bool _isNeedCleanUp = false;

    public IReadOnlyList<TSubscriber> Subscribers => _subscribers;
    public bool IsExecuting { get; private set; }

    public void SwitchExecuting(bool state)
    {
        IsExecuting = state;
    }
    
    public void Add(TSubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Remove(TSubscriber subscriber)
    {
        if (IsExecuting)
        {
            int i = _subscribers.IndexOf(subscriber);
            
            if (i >= 0)
            {
                _isNeedCleanUp = true;
                _subscribers[i] = null;
            }
        }
        else
        {
            _subscribers.Remove(subscriber);
        }
    }

    public void Cleanup()
    {
        if (!_isNeedCleanUp)
            return;

        _subscribers.RemoveAll(s => s == null);
        _isNeedCleanUp = false;
    }
}