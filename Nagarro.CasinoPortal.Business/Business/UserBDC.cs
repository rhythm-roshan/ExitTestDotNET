using Nagarro.CasinoPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.CasinoPortal.Business
{
    public class UserBDC : BDCBase, IUserBDC
    {
        public UserBDC()
            : base(BDCType.UserBDC)
        {

        }




        public OperationResult<IList<IUserDTO>> GetAll()
        {

            OperationResult<IList<IUserDTO>> retVal = null;

            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IList<IUserDTO> userDTO = userDAC.GetAll();
                retVal = OperationResult<IList<IUserDTO>>.CreateSuccessResult(userDTO);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IList<IUserDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IList<IUserDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;

        }

        public OperationResult<IUserDTO> GetAllByID(string uniqueId)
        {
            OperationResult<IUserDTO> retVal = null;

            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO userDTO = userDAC.GetAllByID(uniqueId);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(userDTO);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }

        public OperationResult<IUserDTO> UpdateUser(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> retVal = null;

            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO userDTOs = userDAC.UpdateUser(userDTO);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(userDTOs);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }

        public OperationResult<IUserDTO> CreateUser(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> retVal = null;

            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO userDTOs = userDAC.CreateUser(userDTO);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(userDTOs);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }


        public OperationResult<bool> DeleteUser(int userId)
        {
            OperationResult<bool> retVal = null;

            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                bool userDTOs = userDAC.DeleteUser(userId);
                retVal = OperationResult<bool>.CreateSuccessResult(userDTOs);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<bool>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }


        public OperationResult<IUserDTO> Update(IUserDTO userDTO)
        {

            OperationResult<IUserDTO> retVal = null;

            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO userDTOs = userDAC.Update(userDTO);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(userDTOs);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }
    }
}
