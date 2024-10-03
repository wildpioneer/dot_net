namespace ObserverPattern;

public class Subject
{
    private int _quantity = 0;

    public void UpdateQuantity(int value)
    {
        _quantity += value;
        
        // оповещение наблюдателей
        OnQuantityUpdated?.Invoke(_quantity);
    }
    
    public delegate void QuantityUpdated(int quantity);
    
    public event QuantityUpdated OnQuantityUpdated;
}