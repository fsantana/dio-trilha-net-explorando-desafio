using DesafioProjetoHospedagem.Exceptions;
namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {

            if(!(Suite is Suite)){
                throw new SuiteNaoCadastradaException("Suite não cadastrada");
            }

            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new LimiteDeHospedesAtingidoException("Limite de Suite Atingido");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return this.Hospedes.Count();
        }

        public decimal CalcularValorDiaria()
        {

            if(!(Suite is Suite)){
                throw new SuiteNaoCadastradaException("Suite não cadastrada");
            }

            decimal valor = this.DiasReservados * this.Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor = valor * 0.9m;
            }

            return valor;
        }
    }
}