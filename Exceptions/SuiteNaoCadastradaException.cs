namespace DesafioProjetoHospedagem.Exceptions
{
    public class SuiteNaoCadastradaException : Exception
    {
        public SuiteNaoCadastradaException()
        {
        }

        public SuiteNaoCadastradaException(string message)
            : base(message)
        {
        }

        public SuiteNaoCadastradaException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}