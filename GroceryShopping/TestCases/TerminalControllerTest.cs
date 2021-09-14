using GroceryShopping.Controllers;
using GroceryShopping.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace GroceryShopping.TestCases
{
    public class TerminalControllerTest
    {
        private readonly Mock<ITerminalService> _terminalService = new();
        private readonly TerminalController _terminalController;
        public TerminalControllerTest()
        { 
            _terminalController = new TerminalController(_terminalService.Object);
        }
        
        [Theory]
        [InlineData("ABCDABA")]
        [InlineData("CCCCCCC")]
        public async Task CalCulateTotal_ValidInput_returnsOkResult(string request)
        {
            // Arrange
            decimal result = 0;
            if (request == "CCCCCCC")
            {
               result = 6;
            }
            else
            {
                result = 13.25M;            
            }
            var expectedType = typeof(OkObjectResult);
            // Act
            _terminalService.Setup(x => x.CalCulateTotal(It.IsAny<string>())).ReturnsAsync(result);
            var response = await _terminalController.CalCulateTotal(request);

            // Assert
            Assert.NotNull(response);
            if (request == "CCCCCCC")
            {
                Assert.Equal(result.ToString(), response.ToString());
            }
            else
            {
                Assert.Equal(result.ToString(), response.ToString());
            }
            Assert.Equal(response.GetType(), expectedType);
        }
    }
}
