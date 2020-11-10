using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        RegisterationResponseModel UserRegistration(RegisterationModel registerationModel);
    }
}
