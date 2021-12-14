using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoPropriedades
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //arranje
            var valorNegativo = -100;
            
            //assert
            Assert.Throws<System.ArgumentException>(
                //act
                () => new Lance(null, valorNegativo)
                );
        }
    }
}
