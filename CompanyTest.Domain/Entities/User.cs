using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTest.Domain.Entities;
public class User : EntityBase
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
}
