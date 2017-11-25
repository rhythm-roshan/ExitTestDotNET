using Nagarro.CasinoPortal.Api.Models;
using Nagarro.CasinoPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Nagarro.CasinoPortal.Api.Controllers
{
    public class GameController : ApiController
    {

        public IHttpActionResult Put(int id, [FromBody]UserDTO item)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            userDTO.UserID = id;
            userDTO.UserName = item.UserName;
            userDTO.AccountBalance = item.AccountBalance;
            userDTO.BlockedAmount = item.BlockedAmount;
            userDTO.Contact = item.Contact;
            userDTO.DOB = item.DOB;
            userDTO.Email = item.Email;
            userDTO.UniqueUserId = item.UniqueUserId;
            userDTO.image = item.image;
            OperationResult<IUserDTO> retVal = userBDC.Update(userDTO);
            if (retVal.IsValid())
            {
                return Ok(retVal.Data);
            }

            return NotFound();
        }



        public IHttpActionResult Get(int id, string UniqueID)
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
    }
}