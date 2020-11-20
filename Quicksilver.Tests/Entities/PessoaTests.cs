using Quicksilver.Domain.Entities;
using Quicksilver.Domain.Exceptions.Pessoa;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Quicksilver.Tests.Entities
{
    public class PessoaTests
    {
        [Fact(DisplayName = "Pessoa sem squad deve lançar exceção ao sair")]
        public void Pessoa_Sem_Squad_Deve_Lancar_Excecao_Ao_Sair()
        {
            var dev = new PessoaDev("José");
            Assert.Throws<PessoaNaoTemSquadException>(() => dev.SairDaSquad());
        }

        [Fact(DisplayName = "Pessoa pode ser associada a uma Squad")]
        public void Pessoa_pode_ser_associada_a_uma_Squad()
        {
            var dev = new PessoaDev("José");
            var squad = new Squad("Franquia", true);

            dev.AssociarSquad(squad);
            Assert.Equal(dev.Squad.Id, squad.Id);
        }

        [Fact]
        public void Pessoa_Nao_Pode_Estar_Em_Duas_Squads()
        {
            var qa = new PessoaQA("Enzo");
            var squadFranquia = new Squad("Franquia", true);
            var squadEstrategico = new Squad("Estratégico", true);

            qa.AssociarSquad(squadFranquia);
            Assert.Throws<PessoaJaTemSquadException>(() => qa.AssociarSquad(squadEstrategico));
        }
    }
}
