using System.Collections.Generic;

public abstract class ICommand<T>
{
    protected List<IObserver<T>> Observers = new();

    public void AddObserver(IObserver<T> observer)
    {
        Observers.Add(observer);
    }

    public virtual void Execute(T type)
    {
        foreach (var observer in Observers)
        {
            observer.OnNotify(type);
        }
    }
}
public abstract class IParamCommand<T,T1>
{
    protected List<IParamObserver<T,T1>> Observers = new();

    public void AddObserver(IParamObserver<T,T1> observer)
    {
        Observers.Add(observer);
    }

    public virtual void Execute(T type,T1 param)
    {
        foreach (var observer in Observers)
        {
            observer.OnNotify(type, param);
        }
    }
}
