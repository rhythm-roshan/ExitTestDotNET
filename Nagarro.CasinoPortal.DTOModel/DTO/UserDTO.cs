using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.CasinoPortal.Shared;

namespace Nagarro.CasinoPortal.DTOModel
{
    [EntityMapping("Nagarro.EntityData.EntityModel.User", MappingType.TotalExplicit)]
    [ViewModelMapping("Nagarro.CasinoPortal.Web.Shared.UserViewModel", MappingType.TotalExplicit)]
    public class UserDTO : DTOBase, IUserDTO
    {
        public UserDTO()
            : base(DTOType.UserDTO)
        {

        }
        [EntityPropertyMapping(MappingDirectionType.Both, "UserName")]
        [ViewModelPropertyMappingAttribute(MappingDirectionType.Both, "UserName")] 
        public string UserName { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "DOB")]
        [ViewModelPropertyMappingAttribute(MappingDirectionType.Both, "DOB")] 
        public DateTime DOB { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Contact")]
        [ViewModelPropertyMappingAttribute(MappingDirectionType.Both, "Contact")] 
        public long Contact { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Email")]
        [ViewModelPropertyMappingAttribute(MappingDirectionType.Both, "Email")] 
        public string Email { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "AccountBalance")]
        [ViewModelPropertyMappingAttribute(MappingDirectionType.Both, "AccountBalance")] 
        public int AccountBalance { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "BlockedAmount")]
        [ViewModelPropertyMappingAttribute(MappingDirectionType.Both, "BlockedAmount")] 
        public int BlockedAmount { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UniqueUserId")]
        [ViewModelPropertyMappingAttribute(MappingDirectionType.Both, "UniqueUserId")] 
        public string UniqueUserId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "image")]
        [ViewModelPropertyMappingAttribute(MappingDirectionType.Both, "image")]
        public byte[] image { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserID")]
        [ViewModelPropertyMappingAttribute(MappingDirectionType.Both, "UserID")] 
        public int UserID { get; set; }
    }
}
