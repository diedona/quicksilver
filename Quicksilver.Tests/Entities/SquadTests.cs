using Quicksilver.Domain.Entities;
using Quicksilver.Domain.Exceptions.Squad;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Quicksilver.Tests.Entities
{
    public class SquadTests
    {
        [Fact(DisplayName = "Deve deixar adicionar novos membros")]
        public void Deve_Deixar_Adicionar_Novos_Membros()
        {
            Squad squadFranquia = new Squad("Franquia", true);
            Pessoa programador = new PessoaDev("Josiscleide");
            Pessoa qualidade = new PessoaQA("Micaleide");

            squadFranquia.AdicionarMembros(new List<Pessoa>() { programador, qualidade });
            Assert.True(true);
        }

        [Fact(DisplayName = "Deve lançar exceção ao adicionar membro repetido")]
        public void Deve_Lancar_Excecao_Ao_Adicionar_Membro_Repetido()
        {
            Squad squadFranquia = new Squad("Franquia", true);
            Pessoa programador = new PessoaDev("Joãlacano");
            Pessoa outroProgramador = new PessoaDev("Vercisleide");

            squadFranquia.AdicionarMembro(programador);
            squadFranquia.AdicionarMembro(outroProgramador);
            Assert.Throws<MembroJaAdicionadoException>(() => squadFranquia.AdicionarMembro(programador));
        }
    }
}
