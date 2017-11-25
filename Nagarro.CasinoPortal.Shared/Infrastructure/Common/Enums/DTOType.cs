namespace Nagarro.CasinoPortal.Shared
{
    /// <summary>
    /// Data Transfer Objects
    /// </summary>
    public enum DTOType
    {

        /// <summary>
        /// Undefined DTO (Default)
        /// </summary>
        Undefined = 0,


        [QualifiedTypeName("Nagarro.CasinoPortal.DTOModel.dll", "Nagarro.CasinoPortal.DTOModel.UserDTO")]
        UserDTO = 1,

      

    }
}
