using System;
using System.Collections.Generic;
using System.Text;

namespace Quicksilver.Domain.Entities
{
    public class PessoaQA : Pessoa
    {
        public PessoaQA(string nome) : base(nome)
        {
        }

        public PessoaQA(string nome, Guid id) : base(nome, id)
        {
        }

        public override string ExibirTipoPessoa()
        {
            return "QA";
        }
    }
}
