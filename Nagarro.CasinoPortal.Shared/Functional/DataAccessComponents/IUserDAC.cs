using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.CasinoPortal.Shared
{
    public interface IUserDAC : IDataAccessComponent
    {
        IUserDTO CreateUser(IUserDTO userDTO);
        IList<IUserDTO> GetAll();
        IUserDTO GetAllByID(string uniqueId);
        IUserDTO UpdateUser(IUserDTO userDTO);
        IUserDTO Update(IUserDTO userDTO);
        bool DeleteUser(int userId);

    }
}
