using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class BookBL : IBookBL
    {
        /// <summary>
        /// Created the Reference of IbookRepository
        /// </summary>
        private readonly IBookRL bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookBL"/> class.
        /// </summary>
        /// <param name="bookRepository">It contains the object IbookRepository</param>
        public BookBL(IBookRL bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public BookResponse AddBook(BookRequestModel bookRequestModel)
        {
            try
            {
                // Call the AddBook Method of Books Repository Class
                var response = this.bookRepository.AddBook(bookRequestModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<BookResponse> GetAllBooks()
        {
            try
            {
                // Call the GetAllBooks Method of Books Repository Class
                var response = this.bookRepository.GetAllBooks();
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
