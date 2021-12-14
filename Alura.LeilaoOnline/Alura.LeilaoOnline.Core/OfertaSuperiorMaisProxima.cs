using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeLeilao
    {
        private double valorDestino;

        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            this.valorDestino = valorDestino;
        }

        public Lance ModalidadeLeilao(Leilao leilao)
        {
            return leilao.Lances
                            .DefaultIfEmpty(new Lance(null, 0))
                            .Where(l => l.Valor > valorDestino)
                            .OrderBy(l => l.Valor)
                            .FirstOrDefault();
        }
    }
}
