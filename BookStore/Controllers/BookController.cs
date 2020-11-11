using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Exceptions;
using CommonLayer.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookBL bookBuiseness;

        public BookController(IBookBL bookBuiseness)
        {
            this.bookBuiseness = bookBuiseness;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddBook([FromForm] BookRequestModel bookRequestModel)
        {
            try
            {
                if (bookRequestModel.BookName == null || bookRequestModel.AuthorName == null || bookRequestModel.Description == null || bookRequestModel.Price == null)
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.NULL_FIELD_EXCEPTION, "Null Field");
                }
                else if (bookRequestModel.BookName == "" || bookRequestModel.AuthorName == "" || bookRequestModel.Description == "" || bookRequestModel.Price == "")
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.EMPTY_FIELD_EXCEPTION, "Empty Field");
                }

                // Call the Add Book Method of Book class
                var response = this.bookBuiseness.AddBook(bookRequestModel);

                // check if Id is not equal to zero
                if (!response.BookId.Equals(0))
                {
                    bool status = true;
                    var message = "Book Added Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed to add";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }
    }
}

