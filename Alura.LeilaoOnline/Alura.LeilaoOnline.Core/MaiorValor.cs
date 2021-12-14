using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class MaiorValor : IModalidadeLeilao
    {
        public Lance ModalidadeLeilao(Leilao leilao)
        {
            return leilao.Lances
                       .DefaultIfEmpty(new Lance(null, 0))
                       .OrderBy(v => v.Valor)
                       .Last();
        }
    }
}
