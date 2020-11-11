using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Exceptions;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllBooks()
        {
            try
            {
                List<BookResponse> response = null;
                // Call the User GetAllBooks Method of BookBL classs
                response = this.bookBuiseness.GetAllBooks();
                // check if response is not equal to null
                if (!response.Count.Equals(0))
                {
                    bool status = true;
                    var message = "Books Read Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed to Read";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBook([FromRoute] int Id)
        {
            try
            {
                // Call the User Delete Book Method of BookBL classs
                var response = this.bookBuiseness.DeleteBook(Id);

                // check if Id is not equal to zero
                if (!response.BookId.Equals(0))
                {
                    bool status = true;
                    var message = "Book Deleted Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Book Not Found";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }
    }
}

