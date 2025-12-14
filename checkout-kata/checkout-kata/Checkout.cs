namespace checkout_kata;

public interface ICheckout
{
    void Scan(string item);
    int GetTotalPrice();
}

public class Checkout : ICheckout
{
    private string _scannedItems = "";
    public void Scan(string item)
    {
        _scannedItems = item;
    }

    public int GetTotalPrice()
    {
        if (_scannedItems == "C")
        {
            return 20;
        }
        return 15;
    }
}