using System;
using System.Collections.Generic;
using System.Text;

namespace Quicksilver.Domain.Entities
{
    public class DiaDeTrabalho
    {
        private readonly List<Squad> _Squads;

        public Guid Id { get; private set; }
        public DateTime Data { get; private set; }
        public IReadOnlyCollection<Squad> Squads => _Squads.AsReadOnly();

        public DiaDeTrabalho(DateTime data)
        {
            Data = data;
        }
    }
}
