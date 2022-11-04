namespace OPP_Projektas.Shared.Models.Observer;

public interface IObserver
{
    void Update(ISubject subject);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public class Subject : ISubject
{
    public string PropertyName { get; set; }
    private List<IObserver> _observers = new List<IObserver>();
    
    public void Attach(IObserver observer)
    {
        Console.WriteLine("Subject: Attached observer");
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine("Subject: Detached observer");
    }

    public void Notify()
    {
        Console.WriteLine("Notifying all observers");
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }

    public void OnPropertyChanged(string propertyName)
    {
        Console.WriteLine($"Subject: {propertyName} changed");
        PropertyName = propertyName;
        Notify();
    }
}