using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;

namespace BusinessLayer.Interface
{
    public interface IBookBL
    {
        BookResponse AddBook(BookRequestModel bookRequestModel);

        List<BookResponse> GetAllBooks();

        BookResponse DeleteBook(int Id);
    }
}
