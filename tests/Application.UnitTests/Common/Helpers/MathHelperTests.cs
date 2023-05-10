using Application.Common.Helpers;

namespace Application.UnitTests.Common.Helpers;

public class MathHelperTests
{
    [Fact]
    public void IsEven_Returns_True()
    {
        //Arrange ---> İşlemleri ayarladığımız kısım

        var mathHelper = new MathHelper();

        int evenNumber = 6;


        //Act ---> İşlemi gerçekleştirdiğimiz kısım 

        var result = mathHelper.IsEven(evenNumber);


        //Assert ---> İşlemi test ettiğimiz kısım
        
         Assert.True(result);
        
    }
    
    [Fact]
    public void Add_Returns_True()
    {
        //Arrange ---> İşlemleri ayarladığımız kısım

        var mathHelper = new MathHelper();

        int firstNumber = 6;

        int secondNumber = 15;


        //Act ---> İşlemi gerçekleştirdiğimiz kısım 

        var result = mathHelper.Add(firstNumber,secondNumber);


        //Assert ---> İşlemi test ettiğimiz kısım
        
        Assert.Equal(21,result);

    }
}