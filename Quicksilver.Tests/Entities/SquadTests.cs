using Quicksilver.Domain.Entities;
using Quicksilver.Domain.Exceptions.Pessoa;
using Quicksilver.Domain.Exceptions.Squad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Quicksilver.Tests.Entities
{
    public class SquadTests
    {
        [Fact(DisplayName = "Deve adicionar membro novo")]
        public void Deve_Adicionar_Membro_Novo()
        {
            Squad squad = new Squad("Franquia", true);
            var dev = new PessoaDev("José");

            squad.AdicionarMembro(dev);
            Assert.Equal(1, squad.Membros.Count);
        }

        [Fact(DisplayName = "Deve lançar exceção ao adicionar um membro repetido")]
        public void Deve_Lancar_Excecao_Ao_Adicionar_Membro_Repetido()
        {
            Squad squad = new Squad("Franquia", true);
            var dev = new PessoaDev("José");

            squad.AdicionarMembro(dev);
            Assert.Throws<MembroJaAdicionadoException>(() => squad.AdicionarMembro(dev));
        }
    }
}
