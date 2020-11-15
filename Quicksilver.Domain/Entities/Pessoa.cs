using Quicksilver.Domain.Exceptions.Pessoa;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quicksilver.Domain.Entities
{
    public abstract class Pessoa
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Squad Squad { get; private set; }

        protected Pessoa(string nome, Guid id, Squad squad)
        {
            Id = id;
            Nome = nome;
            Squad = squad;
        }

        protected Pessoa(string nome) : this(nome, Guid.NewGuid(), null)
        {
        }

        public void SairDaSquad()
        {
            if (!TemSquad())
                throw new PessoaNaoTemSquadException();

            Squad.RemoverMembro(this);
        }

        public void AssociarSquad(Squad squad)
        {
            if (TemSquad())
                throw new PessoaJaTemSquadException();

            Squad = squad;
        }

        private bool TemSquad()
        {
            return (Squad != null);
        }

        public abstract string ExibirTipoPessoa();

        public override string ToString()
        {
            return $"Id: {Id} Nome: {Nome} Squad: {Squad?.Nome}";
        }
    }
}
