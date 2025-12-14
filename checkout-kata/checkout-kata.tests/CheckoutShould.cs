namespace checkout_kata.tests;

public class CheckoutShould
{
    [Test]
    public void Give_The_Total_Price_Of_A_Single_Scanned_Item()
    {
        //Arrange
        ICheckout checkout = new Checkout();

        //Act
        checkout.Scan("D");
        
        //Assert
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(15));
    }
}