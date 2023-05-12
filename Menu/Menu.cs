using DesafioProjetoHospedagem.Models;
using DesafioProjetoHospedagem.Exceptions;

namespace DesafioProjetoHospedagem.Menu
{
    public class Menu
    {
        private Reserva Reserva;
        public void run()
        {
            int option = 0;

            do{
                
                try
                {
                    cadastrarReserva();
                    cadastrarSuite();
                    cadastrarHospedes();
                    calcularReserva();
                }catch(LimiteDeHospedesAtingidoException e){
                    Console.WriteLine(e.Message);
                }
            
                option = inputInt("\nDigite 0 para sair ou 1 para nova reserva");

            }while(option != 0);
        }

        private void cadastrarReserva()
        {
            int quantidade = inputInt("Informe quantos dias da reserva: ");
            
            Reserva = new Reserva(quantidade);
        }

        private void cadastrarSuite()
        {
            string tipo = inputString("Informe o tipo da Suite: ");

            int capacidade = inputInt("Informe a capacidade da Suite: ");

            decimal valor = inputDecimal("Informe o valor da Diária da Suite: ");

            Suite suite = new Suite(tipoSuite: tipo, capacidade: capacidade, valorDiaria: valor);

            Reserva.CadastrarSuite(suite);
        }

        private void cadastrarHospedes(){
            List<Pessoa> hospedes = new List<Pessoa>();
            string nome = "";
            do
            {
                nome = inputString($"Informe o nome do {hospedes.Count+1}º Hospede: ");

                if(nome != ""){
                    hospedes.Add(new Pessoa(nome));
                }
                
            }
            while(nome != "");

            Reserva.CadastrarHospedes(hospedes);
        }

        private void calcularReserva(){
            Console.WriteLine($"\nHóspedes: {Reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {Reserva.CalcularValorDiaria()}\n");
        }

        private string inputString(string query){
            Console.WriteLine(query);
            return Console.ReadLine();
        }

        private int inputInt(string query){
            
            int i = 0;
            do
            {
                Console.WriteLine(query);
                if (int.TryParse(Console.ReadLine(), out i))
                {
                    return i;
                }
                Console.WriteLine("Valor inválido.");
            }while(true);
        }

        private decimal inputDecimal(string query){
            
            decimal i = 0;
            do
            {
                Console.WriteLine(query);
                if (decimal.TryParse(Console.ReadLine(), out i))
                {
                    return i;
                }
                Console.WriteLine("Valor inválido.");
            }while(true);
        }
    }
}