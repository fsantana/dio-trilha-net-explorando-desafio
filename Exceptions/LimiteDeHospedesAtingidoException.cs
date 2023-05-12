namespace DesafioProjetoHospedagem.Exceptions
{
    public class LimiteDeHospedesAtingidoException : Exception
    {
        public LimiteDeHospedesAtingidoException()
        {
        }

        public LimiteDeHospedesAtingidoException(string message)
            : base(message)
        {
        }

        public LimiteDeHospedesAtingidoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}