public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);

    private void Notify(){}
}