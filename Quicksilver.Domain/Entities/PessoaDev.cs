using System;
using System.Collections.Generic;
using System.Text;

namespace Quicksilver.Domain.Entities
{
    public class PessoaDev : Pessoa
    {
        public PessoaDev(string nome) : base(nome)
        {
        }

        public PessoaDev(string nome, Guid id, Squad squad) : base(nome, id, squad)
        {
        }

        public override string ExibirTipoPessoa()
        {
            return "DEV";
        }
    }
}
