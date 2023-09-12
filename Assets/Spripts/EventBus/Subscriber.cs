public class Subscriber<TSubscriber> where TSubscriber : class
{
    private TSubscriber _t;
    
    public TSubscriber T => _t;
    public int Priority { get; private set; }

    public Subscriber(TSubscriber subscriber, int priority)
    {
        _t = subscriber;
        Priority = priority;
    }
}