using Quicksilver.Domain.Entities;
using Quicksilver.Domain.Exceptions.Pessoa;
using Quicksilver.Domain.Exceptions.Squad;
using Quicksilver.Domain.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Quicksilver.Tests.DomainServices
{
    public class VincularPessoaSquadServiceTests
    {
        [Fact(DisplayName = "Deve deixar adicionar novos membros")]
        public void Deve_Deixar_Adicionar_Novos_Membros()
        {
            var squadFranquia = new Squad("Franquia", true);
            var programador = new PessoaDev("Josiscleide");
            var qualidade = new PessoaQA("Micaleide");
            var squadServices = new VincularPessoaSquadService();

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
            var squadFranquia = new Squad("Franquia", true);
            var programador = new PessoaDev("Joãlacano");
            var outroProgramador = new PessoaDev("Vercisleide");
            var squadServices = new VincularPessoaSquadService();

            squadServices.VincularSquad(new List<Pessoa>() { programador, outroProgramador }, squadFranquia);
            Assert.Throws<PessoaJaTemSquadException>(() => squadServices.VincularSquad(programador, squadFranquia));
        }
    }
}
