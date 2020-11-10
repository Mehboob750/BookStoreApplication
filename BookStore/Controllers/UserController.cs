using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Exceptions;
using CommonLayer.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IConfiguration configuration;

        private IUserBL userBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userBusiness">It is an object of IUser Business</param>
        public UserController(IUserBL userBuiseness, IConfiguration configuration)
        {
            this.userBusiness = userBuiseness;
            this.configuration = configuration;
        }

        /// <summary>
        /// This Method is used for User Registration
        /// </summary>
        /// <param name="registerationModel">It is an object of Registeration Model</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpPost]
        [Route("Registration")]
        [AllowAnonymous]
        public IActionResult UserRegistration(RegisterationModel registerationModel)
        {
            try
            {
                if (registerationModel.FirstName == null || registerationModel.LastName == null || registerationModel.Role == null || registerationModel.EmailId == null || registerationModel.PhoneNumber == null || registerationModel.Password == null)
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.NULL_FIELD_EXCEPTION, "Null Field");
                }
                else if (registerationModel.FirstName == "" || registerationModel.LastName == "" || registerationModel.Role == "" || registerationModel.EmailId == "" || registerationModel.PhoneNumber == "" || registerationModel.Password == "")
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.EMPTY_FIELD_EXCEPTION, "Empty Field");
                }

                // Call the User Registration Method of User Business classs
                var response = userBusiness.UserRegistration(registerationModel);

                // check if Id is not equal to zero
                if (response.Id.Equals(0))
                {
                    bool status = false;
                    var message = "User already Present";
                    return this.Conflict(new { status, message });
                }
                else
                {
                    bool status = true;
                    var message = "User Registered Successfully";
                    return this.Ok(new { status, message, data = response });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }
    }
}
