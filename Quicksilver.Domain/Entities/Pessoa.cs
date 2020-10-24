using System;
using System.Collections.Generic;
using System.Text;

namespace Quicksilver.Domain.Entities
{
    public abstract class Pessoa
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        protected Pessoa(string nome, Guid id)
        {
            Id = id;
            Nome = nome;
        }

        protected Pessoa(string nome) : this(nome, Guid.NewGuid())
        {
        }

        public abstract string ExibirTipoPessoa();
    }
}
