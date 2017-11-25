using Nagarro.CasinoPortal.Shared;
using Nagarro.CasinoPortal.EntityData;
using Nagarro.EntityData.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EntityData.EntityData;
using System.Security.Cryptography;

namespace Nagarro.CasinoPortal.Data
{
    public class UserDAC : DACBase, IUserDAC
    {
        public UserDAC()
            : base(DACType.UserDAC)
        {

        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public IList<IUserDTO> GetAll()
        {
            IList<IUserDTO> tempUserList = new List<IUserDTO>();
            try
            {
                CasinoPortalEntities context = new CasinoPortalEntities();
                using (context)
                {
                    var items = context.Users.ToList();
                    
                    foreach (var eachItem in items)
                    {
                        IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityConverter.FillDTOFromEntity(eachItem, userDTO);
                        tempUserList.Add(userDTO);

                    }

                }

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return tempUserList;
        }

        public IUserDTO GetAllByID(string uniqueId)
        {
            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            try
            {
                CasinoPortalEntities context = new CasinoPortalEntities();
                using (context)
                {
                   var foundItem = context.Users.ToList().Where(data => data.UniqueUserId == uniqueId).SingleOrDefault();
                   if (foundItem != null)
                   {
                       EntityConverter.FillDTOFromEntity(foundItem, userDTO);
                   }

                }

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return userDTO;
        }

        public IUserDTO UpdateUser(IUserDTO userDTO)
        {
            try
            {
                CasinoPortalEntities context = new CasinoPortalEntities();
                using (context)
                {
                    var amount = userDTO.AccountBalance;
                    var foundItem = context.Users.ToList().Where(item => item.UserID == userDTO.UserID).FirstOrDefault();
                    if (foundItem != null)
                    {
                        EntityConverter.FillDTOFromEntity(foundItem,userDTO);
                        foundItem.AccountBalance += amount;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return userDTO;
        }

        public IUserDTO CreateUser(IUserDTO userDTO)
        {
            IUserDTO retVal = null;
            try
            {
                using (CasinoPortalEntities context = new CasinoPortalEntities())
                {
                    userDTO.BlockedAmount = 0;
                    userDTO.AccountBalance = 500;
                    userDTO.UniqueUserId = RandomString(8);
                    User user = new User();
                    EntityConverter.FillEntityFromDTO(userDTO, user);
                    context.Users.Add(user);
                    context.SaveChanges();
                    userDTO.UserID = user.UserID;
                    retVal = userDTO;
                }
            }

            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retVal;
        }


        public bool DeleteUser(int userId)
        {
            bool tempRV = false;
            try
            {
                using (CasinoPortalEntities context = new CasinoPortalEntities())
                {

                    var foundItem = context.Users.ToList().Where(eachItem => eachItem.UserID == userId).FirstOrDefault();
                    if (foundItem != null)
                    {
                        context.Users.Remove(foundItem);
                        context.SaveChanges();
                        tempRV = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return tempRV;
        }


        public IUserDTO Update(IUserDTO userDTO)
        {
            try
            {
                CasinoPortalEntities context = new CasinoPortalEntities();
                using (context)
                {                
                    var foundItem = context.Users.ToList().Where(item => item.UserID == userDTO.UserID).FirstOrDefault();
                    if (foundItem != null)
                    {
                        EntityConverter.FillEntityFromDTO(userDTO,foundItem);              
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return userDTO;
        }
    }
}
