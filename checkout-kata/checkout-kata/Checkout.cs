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

        var distinctItems = _scannedItems.Distinct().ToDictionary(item => item, 
            item => _scannedItems.Count(i => i == item));

        foreach (var item in distinctItems)
        {
            totalPrice += DistinctTotalPrice(item.Key, item.Value);
        }
        
        return totalPrice;
    }

    private static int DistinctTotalPrice(string name, int quantity)
    {
        var totalPrice = 0;
        
        if (OfferApplies(name, quantity))
        {
            totalPrice += ApplyOffer(name, ref quantity);
        }
        if(quantity > 0)
        {
            totalPrice += PricePerItem(name) * quantity;
        }
        
        return totalPrice;
    }

    private static int ApplyOffer(string item, ref int quantity)
    {
        var offer = 0;
        switch (item)
        {
            case "A":
                offer = (quantity / 3) * 130;
                quantity %= 3;
                break;
            case "B":
                offer = (quantity / 2) * 45;
                quantity %= 2;
                break;
        }
        return offer;
    }    
    
    private static bool OfferApplies(string item, int quantity)
    {
        if (item == "A" && quantity >= 3)
            return true;
        if (item == "B" && quantity >= 2)
            return true;
        return false;
    }

    private static int PricePerItem(string item)
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