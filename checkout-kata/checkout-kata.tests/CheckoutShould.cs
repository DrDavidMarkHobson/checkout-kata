namespace checkout_kata.tests;

public class CheckoutShould
{
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
}