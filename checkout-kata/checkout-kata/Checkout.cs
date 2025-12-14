namespace checkout_kata;

public interface ICheckout
{
    void Scan(string item);
    int GetTotalPrice();
}

public class Checkout : ICheckout
{
    private List<string> _scannedItems = new();
    public void Scan(string item)
    {
        _scannedItems.Add(item);
    }

    public int GetTotalPrice()
    {
        var totalPrice = 0;
        
        foreach (var item in _scannedItems)
        {
            totalPrice += TotalPricePerItem(item);
        }
        
        return totalPrice;
    }

    private int TotalPricePerItem(string item)
    {
        switch (item)
        {
            case "A":
                return 50;
            case "B":
                return 30;
            case "C":
                return 20;
            case "D":
                return 15;
            default:
                return 15;
        }
    }
}