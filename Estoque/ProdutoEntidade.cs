using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoTarget
{
    public class ProdutoEntidade
    {
        public int CodigoProduto { get; set; }
        public string? DescricaoProduto { get; set; }
        public MovimentacaoEstoque? MovimentacaoEstoque { get; set; }

        public int Estoque { get; set; }
    }
}