using ResturantAPI.Models.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models
{
    public interface I_Users<TEntity>
    {
        List<dynamic> Gets();
        Dictionary<string, object> Login(LoginDTO loginDTO);
        Dictionary<string, object> Register(RegisterDTO registerDTO);

    }
}
