using Quicksilver.Domain.Exceptions.Squad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quicksilver.Domain.Entities
{
    public class Squad
    {
        private readonly List<Pessoa> _Membros;

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public IReadOnlyCollection<Pessoa> Membros => _Membros.AsReadOnly();

        public Squad(string nome, bool ativo, Guid id)
        {
            Id = id;
            Nome = nome;
            Ativo = ativo;
            _Membros = new List<Pessoa>();
        }

        public Squad(string nome, bool ativo) : this(nome, ativo, Guid.NewGuid())
        {
        }

        public void AdicionarMembro(Pessoa pessoa)
        {
            AdicionarMembros(new List<Pessoa>() { pessoa });
        }

        public void AdicionarMembros(ICollection<Pessoa> pessoas)
        {
            foreach (var pessoa in pessoas)
            {
                if (MembroJaAssociado(pessoa.Id))
                    throw new MembroJaAdicionadoException();

                pessoa.VincularSquad(this);
            }

            _Membros.AddRange(pessoas);
        }

        public void RemoverMembro(Pessoa pessoa)
        {
            if (!_Membros.Remove(pessoa))
                throw new Exception("Este membro não está associado à Squad");
        }

        private bool MembroJaAssociado(Guid idPessoa)
        {
            return _Membros.Any(pessoa => pessoa.Id.Equals(idPessoa));
        }

        public override string ToString()
        {
            return $"Id: {Id} - Nome: {Nome}";
        }
    }
}
