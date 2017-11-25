using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.CasinoPortal.Shared
{
    public interface IUserDTO : IDTO
    {
        int UserID { get; set; }
        string UserName { get; set; }
        DateTime DOB { get; set; }
        long Contact { get; set; }
        string Email { get; set; }
        int AccountBalance { get; set; }
        int BlockedAmount { get; set; }
        string UniqueUserId { get; set; }
        byte[] image { get; set; }
    }
}
