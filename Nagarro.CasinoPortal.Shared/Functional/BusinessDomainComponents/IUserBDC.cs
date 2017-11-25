using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.CasinoPortal.Shared
{
    public interface IUserBDC : IBusinessDomainComponent
    {
        OperationResult<IUserDTO> CreateUser(IUserDTO userDTO);
        OperationResult<IList<IUserDTO>> GetAll();
        OperationResult<IUserDTO> GetAllByID(string uniqueId);
        OperationResult<IUserDTO> UpdateUser(IUserDTO userDTO);
        OperationResult<IUserDTO> Update(IUserDTO userDTO);
        OperationResult<bool> DeleteUser(int userId);
    }
}
