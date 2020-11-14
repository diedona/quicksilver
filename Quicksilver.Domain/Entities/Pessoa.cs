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

        public bool TemSquad()
        {
            return (Squad != null);
        }

        public void VincularSquad(Squad squad)
        {
            if (TemSquad())
            {
                if (Squad.Id.Equals(squad.Id))
                    throw new Exception("Não é possível vincular à mesma squad que este membro já participa.");

                Squad.RemoverMembro(this);
            }

            Squad = squad;
        }

        public abstract string ExibirTipoPessoa();

        public override string ToString()
        {
            return $"Id: {Id} Nome: {Nome} Squad: {Squad?.Nome}";
        }
    }
}
