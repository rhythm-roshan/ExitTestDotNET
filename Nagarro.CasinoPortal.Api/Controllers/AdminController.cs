using Nagarro.CasinoPortal.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Nagarro.CasinoPortal.Api.Models;

namespace Nagarro.CasinoPortal.Api.Controllers
{
    public class AdminController : ApiController
    {

        public IHttpActionResult Get()
        {

            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            OperationResult<IList<IUserDTO>> retVal = userBDC.GetAll();
            IList<UserDTO> temp = new List<UserDTO>();

            if (retVal.IsValid())
            {
                foreach (var item in retVal.Data)
                {
                    UserDTO userDTO = new UserDTO();
                    userDTO.UserID = item.UserID;
                    userDTO.UserName = item.UserName;
                    userDTO.AccountBalance = item.AccountBalance;
                    userDTO.BlockedAmount = item.BlockedAmount;
                    userDTO.Contact = item.Contact;
                    userDTO.DOB = item.DOB;
                    userDTO.Email = item.Email;
                    userDTO.UniqueUserId = item.UniqueUserId;
                    userDTO.image = item.image;
                    userDTO.file = null;
                    temp.Add(userDTO);

                }
            }


            return Ok(temp);

        }

        public IHttpActionResult Get(int id ,string UniqueID)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            OperationResult<IUserDTO> item = userBDC.GetAllByID(UniqueID);
            UserDTO userDTO = new UserDTO();
            if (item.IsValid())
            {
                
                userDTO.UserID = item.Data.UserID;
                userDTO.UserName = item.Data.UserName;
                userDTO.AccountBalance = item.Data.AccountBalance;
                userDTO.BlockedAmount = item.Data.BlockedAmount;
                userDTO.Contact = item.Data.Contact;
                userDTO.DOB = item.Data.DOB;
                userDTO.Email = item.Data.Email;
                userDTO.UniqueUserId = item.Data.UniqueUserId;
                userDTO.image = item.Data.image;

            
            }
            return Ok(userDTO);
            
        }

        public IHttpActionResult Post(UserDTO item)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);

            userDTO.UserID = item.UserID;
            userDTO.UserName = item.UserName;
            userDTO.AccountBalance = item.AccountBalance;
            userDTO.BlockedAmount = item.BlockedAmount;
            userDTO.Contact = item.Contact;
            userDTO.DOB = item.DOB;
            userDTO.Email = item.Email;
            userDTO.UniqueUserId = item.UniqueUserId;
            userDTO.image = item.image;

            OperationResult<IUserDTO> val = userBDC.CreateUser(userDTO);
            if (val.IsValid())
            {
                return Ok(val.Data);
            }

            return NotFound();
        }

        public IHttpActionResult Put(int id, [FromBody]UserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            IUserDTO userDTOs = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            userDTOs.UserID = id;
            userDTOs.AccountBalance = userDTO.AccountBalance;
            OperationResult<IUserDTO> retVal = userBDC.UpdateUser(userDTOs);
            if (retVal.IsValid())
            {
                return Ok(retVal.Data.UserID);
            }

            return NotFound();

        }
       
        public bool Delete(int id)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            OperationResult<bool> val = userBDC.DeleteUser(id);
            if (val.IsValid())
            {

            }
            return val.Data;

        }
    }
}