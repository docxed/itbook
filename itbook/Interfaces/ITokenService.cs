using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itbook.Models;

namespace itbook.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
