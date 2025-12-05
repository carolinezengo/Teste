using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoTarget
{
    public class MovimentacaoEstoque
    {
        public  Guid IdMovimentacao { get; set; }
        public int CodigoProduto { get; set; }
        public string? Descricao { get; set; }
        
        public int Quantidade { get; set; }
    }
}