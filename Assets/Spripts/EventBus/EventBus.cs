using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EventBus
{
    private static Dictionary<Type, SubscribersList<IGlobalSubscriber>> _subscribers = new();
    private static Dictionary<Type, List<Type>> _cashedSubscriberTypes = new();
    
    public static void Subscribe(IGlobalSubscriber subscriber)
    {
        List<Type> subscriberTypes = GetSubscribersTypes(subscriber);
        
        foreach (Type subscriberType in subscriberTypes)
        {
            if (!_subscribers.ContainsKey(subscriberType))
            {
                _subscribers[subscriberType] = new SubscribersList<IGlobalSubscriber>();
                _subscribers[subscriberType].Add(subscriber);
            }
        }
    }
    
    public static void Unsubscribe(IGlobalSubscriber subscriber)
    {
        List<Type> subscriberTypes = GetSubscribersTypes(subscriber);
        
        foreach (Type subscriberType in subscriberTypes)
        {
            if (_subscribers.ContainsKey(subscriberType))
                _subscribers[subscriberType].Remove(subscriber);
        }
    }

    public static void RaiseEvent<TSubscriber>(Action<TSubscriber> action)
        where TSubscriber : class, IGlobalSubscriber
    {
        SubscribersList<IGlobalSubscriber> subscribers = _subscribers[typeof(TSubscriber)];

        subscribers.SwitchExecuting(true);
        
        foreach (IGlobalSubscriber subscriber in subscribers.Subscribers)
        {
            try
            {
                action.Invoke(subscriber as TSubscriber);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        
        subscribers.SwitchExecuting(false);
        subscribers.Cleanup();
    }

    private static List<Type> GetSubscribersTypes(IGlobalSubscriber globalSubscriber)
    {
        Type type = globalSubscriber.GetType();
        
        if (_cashedSubscriberTypes.ContainsKey(type))
            return _cashedSubscriberTypes[type];

        List<Type> subscriberTypes = type
            .GetInterfaces()
            .Where(it =>
                it != typeof(IGlobalSubscriber) &&
                typeof(IGlobalSubscriber).IsAssignableFrom(it))
            .ToList();

        _cashedSubscriberTypes[type] = subscriberTypes;

        return subscriberTypes;
    }
}