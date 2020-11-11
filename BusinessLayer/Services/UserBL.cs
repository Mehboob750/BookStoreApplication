using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        /// <summary>
        /// Created the Reference of IUserRepository
        /// </summary>
        private readonly IUserRL userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserBL"/> class.
        /// </summary>
        /// <param name="userRepository">It contains the object IUserRepository</param>
        public UserBL(IUserRL userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// This Method is used to User Registration
        /// </summary>
        /// <param name="registrationModel">It contains the Object of Registration Request Model</param>
        /// <returns>If User Registered Successfully it returns Registration response Model</returns>
        public RegisterationResponseModel UserRegistration(RegisterationModel registerationModel)
        {
            try
            {
                // Call the User Register Method of User Repository Class
                var response = this.userRepository.UserRegistration(registerationModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// This Method is used to User Login
        /// </summary>
        /// <param name="loginModel">It contains the Object of login Model</param>
        /// <returns>If User login Successfully it returns login response Model</returns>
        public LoginResponseModel UserLogin(LoginModel loginModel)
        {
            try
            {
                // Call the User Register Method of User Repository Class
                var response = this.userRepository.UserLogin(loginModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
