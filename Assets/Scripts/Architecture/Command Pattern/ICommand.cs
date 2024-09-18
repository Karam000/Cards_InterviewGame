using System.Collections.Generic;

/// <summary>
/// Base class for Commands. Has a list of IObservers that need to subscribe to the command being excuted
/// </summary>
/// <typeparam name="T">command type</typeparam>
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

/// <summary>
/// Parameterized command
/// </summary>
/// <typeparam name="T">command type</typeparam>
/// <typeparam name="T1">parameter type</typeparam>
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
