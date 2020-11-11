using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        BookResponse AddBook(BookRequestModel bookRequestModel);

        List<BookResponse> GetAllBooks();
    }
}
