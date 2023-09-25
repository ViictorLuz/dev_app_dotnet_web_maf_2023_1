using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Enums
{
    [Flags]
    public enum Habilidade
    {
        Desenvolvimento,
        Infraestrutura,
        BancoDeDados,
        SoftSkills
    }
}
