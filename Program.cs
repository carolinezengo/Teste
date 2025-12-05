


using System.Globalization;
using NovoTarget;
 Console.WriteLine("Digite qual operação deseja realizar");
 Console.WriteLine("1 - Comissão de funcionario ");
 Console.WriteLine("2 - Movimentar o  Estoque ");
 Console.WriteLine("3- Calcular juros ");


  
   int opcao = int.Parse(Console.ReadLine());

switch (opcao)
{
    case 1:

        var comissao = new Vendas();
        comissao.ComissaoDeCadaVendedor();
        break;

    case 2:
        Console.WriteLine("Digite qual opção desejada ");
        Console.WriteLine("1- Entrada de mercadoria ");
        Console.WriteLine("2- Saida de mercadoria ");

        
            var estoque = new Estoque();

        int opcaoMovimentacao = int.Parse(Console.ReadLine());

        switch (opcaoMovimentacao)
        {
            case 1:
                estoque.RetornarResultadoLIsta();
             Console.WriteLine("Digite o codigo do produto ");
                int codigoProdutoEntraada = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite a quantidade da entrada");
            int quantidadeDeEntrada = int.Parse(Console.ReadLine());

                var movimentação = new MovimentacaoEstoque
                {
                    IdMovimentacao = Guid.NewGuid(),
                    CodigoProduto = codigoProdutoEntraada,
                    Descricao = "Entrada",
                    Quantidade = quantidadeDeEntrada

                };
                
                estoque.MovimentacaoDeEstoque(movimentação);

                break;

            case 2:
             estoque.RetornarResultadoLIsta();

              Console.WriteLine("Digite o codigo do produto");
                int codigoProdutoSaida = int.Parse(Console.ReadLine());
            
               Console.WriteLine("Digite a quantidade da entrada");
              int quantidadedeSaida = int.Parse(Console.ReadLine());

                var movimentação2 = new MovimentacaoEstoque
                {
                    IdMovimentacao = Guid.NewGuid(),
                    CodigoProduto = codigoProdutoSaida,
                    Descricao = "Saida",
                    Quantidade = quantidadedeSaida



                };
               estoque.MovimentacaoDeEstoque(movimentação2);
                break;

        }
        break;
    case 3:
        var juros = new CalculoDeJuro();
          
          
              Console.WriteLine("Digite o valor da prestação");
                double valorPrestacao = Double.Parse(Console.ReadLine());
            
               Console.WriteLine("Digite a data de Vencimento");
             string dataString = Console.ReadLine();
        

               

            DateTime dataVencimento = new DateTime();
          dataVencimento = DateTime.ParseExact(dataString ,"dd/MM/yyyy", CultureInfo.InvariantCulture);

            juros.JurosPorDataDeVencimento(2000, dataVencimento);
        break;
}
            









                                
                   



