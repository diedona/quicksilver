using System;
using System.Collections.Generic;
using System.Text;

namespace Quicksilver.Domain.Entities
{
    public class Tarefa
    {
        public Guid Id { get; private set; }
        public Pessoa Autor { get; private set; }
        public Squad Squad { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public bool Concluida { get; private set; }
    }
}
