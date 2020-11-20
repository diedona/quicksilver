using Quicksilver.Domain.Entities;
using Quicksilver.Domain.Exceptions.Squad;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quicksilver.Domain.DomainServices
{
    public class VincularPessoaSquadService
    {
        public void VincularSquad(Pessoa pessoa, Squad squad)
        {
            pessoa.AssociarSquad(squad);
            squad.AdicionarMembro(pessoa);
        }

        public void VincularSquad(ICollection<Pessoa> pessoas, Squad squad)
        {
            foreach (var pessoa in pessoas)
            {
                VincularSquad(pessoa, squad);
            }
        }
    }
}
