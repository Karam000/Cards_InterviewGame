public interface IObserver<T>
{
    void OnNotify(T type);
}

public interface IParamObserver<T,T1>
{
    void OnNotify(T type, T1 param);
}
