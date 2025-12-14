namespace checkout_kata.tests;

public class CheckoutShould
{
    public class TestCase
    {
        public TestCase(string[] input, int expectedOutput)
        {
            Input = input;
            ExpectedOutput = expectedOutput;
        }

        public string[] Input { get; set; }
        public int ExpectedOutput { get; set; }
    }  
    
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
    
    public static List<TestCase> MultipleItemCases()
    {
        var cases = new List<TestCase>();
        cases.Add(new TestCase(["A", "A", "A"], 130));
        cases.Add(new TestCase(["B", "B"], 45));
        cases.Add(new TestCase(["C", "C"], 40));
        cases.Add(new TestCase(["D", "D"], 30));
        cases.Add(new TestCase(["A", "A", "A", "B", "B","C", "D"], 210));
        cases.Add(new TestCase(["A", "B", "C", "D", "B","A", "A"], 210));
        return cases;
    }      
    
    [TestCaseSource(nameof(MultipleItemCases))]
    public void Give_The_Total_Price_Of_Multiple_Scanned_Items(TestCase testCase)
    {
        //Arrange
        ICheckout checkout = new Checkout();

        //Act
        foreach (var item in testCase.Input)
        {
            checkout.Scan(item);
        }
        
        //Assert
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(testCase.ExpectedOutput));
    }
}