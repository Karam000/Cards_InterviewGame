using System.Collections.Generic;

public abstract class ICommand<T>
{
    protected List<IObserver<T>> Observers = new();

    public void AddObserver(IObserver<T> observer)
    {
        Observers.Add(observer);
    }

    public virtual void Execute(T t)
    {
        foreach (var observer in Observers)
        {
            observer.OnNotify(t);
        }
    }
}