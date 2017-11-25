using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.CasinoPortal.Api.Models
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime DOB { get; set; }
        public long Contact { get; set; }
        public string Email { get; set; }
        public int AccountBalance { get; set; }
        public int BlockedAmount { get; set; }
        public string UniqueUserId { get; set; }
        public byte[] image { get; set; }
        public HttpPostedFileBase file { get; set; }

    }
}