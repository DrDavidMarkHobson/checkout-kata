namespace checkout_kata.tests;

public class CheckoutShould
{
    [TestCase("A", 50)]
    [TestCase("B", 30)]
    [TestCase("C", 20)]
    [TestCase("D", 15)]
    public void Give_The_Total_Price_Of_A_Single_Scanned_Item(string item, int expected)
    {
        //Arrange
        ICheckout checkout = new Checkout();

        //Act
        checkout.Scan(item);
        
        //Assert
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expected));
    }
    
    [Test]
    public void Give_The_Total_Price_Of_Multiple_Scanned_Items()
    {
        //Arrange
        ICheckout checkout = new Checkout();

        //Act
        checkout.Scan("D");
        checkout.Scan("D");
        
        //Assert
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(30));
    }
}