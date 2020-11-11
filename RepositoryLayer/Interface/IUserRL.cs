using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        RegisterationResponseModel UserRegistration(RegisterationModel registerationModel);

        LoginResponseModel UserLogin(LoginModel loginModel);
    }
}
