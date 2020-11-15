using Quicksilver.Domain.Entities;
using Quicksilver.Domain.Exceptions.Pessoa;
using Quicksilver.Domain.Exceptions.Squad;
using Quicksilver.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            SquadServices squadServices = new SquadServices();

            var novasPessoasDaSquad = new List<Pessoa>() { programador, qualidade };
            squadServices.VincularSquad(novasPessoasDaSquad, squadFranquia);

            foreach (var pessoa in novasPessoasDaSquad)
            {
                if (pessoa.Squad.Id != squadFranquia.Id)
                    throw new Exception("Pessoa não está na squad certa");
            }

            Assert.True(squadFranquia.Membros.Count == novasPessoasDaSquad.Count);
        }

        [Fact(DisplayName = "Deve lançar exceção ao adicionar membro repetido")]
        public void Deve_Lancar_Excecao_Ao_Adicionar_Membro_Repetido()
        {
            Squad squadFranquia = new Squad("Franquia", true);
            Pessoa programador = new PessoaDev("Joãlacano");
            Pessoa outroProgramador = new PessoaDev("Vercisleide");
            SquadServices squadServices = new SquadServices();

            squadServices.VincularSquad(new List<Pessoa>() { programador, outroProgramador }, squadFranquia);
            Assert.Throws<PessoaJaTemSquadException>(() => squadServices.VincularSquad(programador, squadFranquia));
        }
    }
}
