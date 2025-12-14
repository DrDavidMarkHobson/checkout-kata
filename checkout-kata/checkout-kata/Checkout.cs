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
        switch (_scannedItems)
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