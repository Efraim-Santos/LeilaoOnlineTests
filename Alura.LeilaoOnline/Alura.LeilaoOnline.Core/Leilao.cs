using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        private IList<Lance> _lances;
        private Interessada _ultimoCliente;
        public IEnumerable<Lance> Lances => _lances;
        private IModalidadeLeilao _validarGanhador;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoDoLeilao EstadoLeilao { get; private set; }

        public Leilao(string peca, IModalidadeLeilao validarGanhador)
        {
            Peca = peca;
            _lances = new List<Lance>();
            _validarGanhador = validarGanhador;
        }

        private bool NovoLanceEhAceito(Interessada cliente, double valor)
        {
            return (EstadoLeilao == EstadoDoLeilao.LeilaoEmAndamento)
                && (cliente != _ultimoCliente);
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (NovoLanceEhAceito(cliente, valor))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }
        }

        public void IniciaPregao()
        {
            EstadoLeilao = EstadoDoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if(EstadoLeilao != EstadoDoLeilao.LeilaoEmAndamento)
            {
                throw new System.InvalidOperationException();
            }
            Ganhador = _validarGanhador.ModalidadeLeilao(this);
            
            EstadoLeilao = EstadoDoLeilao.LeilaoFinalizado;
        }
    }
}