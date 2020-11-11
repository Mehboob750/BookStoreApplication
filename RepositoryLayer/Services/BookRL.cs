using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Models;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class BookRL : IBookRL
    {
        /// <summary>
        /// Created the Reference of ApplicationdbContext
        /// </summary>
        private ApplicationDbContext dbContext;

        private readonly IConfiguration configuration;

        BookResponse bookResponse = new BookResponse();

        BookModel bookModel = new BookModel(); 

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRL"/> class.
        /// </summary>
        /// <param name="dbContext">It contains the object ApplicationDbContext</param>
        public BookRL(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public BookResponse AddBook(BookRequestModel bookRequest)
        {
            try
            {
                var response = this.dbContext.BookDetails.FirstOrDefault(value => ((value.BookName == bookRequest.BookName)) && ((value.AuthorName == bookRequest.AuthorName)));
                if (response != null)
                {
                    response.Quantity = response.Quantity+bookRequest.Quantity;
                    this.dbContext.BookDetails.Update(response);
                    this.dbContext.SaveChanges();
                    return Response(response);
                }
                else
                {
                    string image = AddImage(bookRequest);
                    bookModel.BookName = bookRequest.BookName;
                    bookModel.AuthorName = bookRequest.AuthorName;
                    bookModel.Description = bookRequest.Description;
                    bookModel.Price = bookRequest.Price;
                    bookModel.Quantity = bookRequest.Quantity;
                    bookModel.CreatedDate = DateTime.Now;
                    bookModel.Image = image;
                    bookModel.IsDeleted = "No";
                    this.dbContext.BookDetails.Add(bookModel);
                    this.dbContext.SaveChanges();
                    return Response(bookModel);
                }
              
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<BookResponse> GetAllBooks()
        {
            try
            {
                List<BookResponse> bookResponseList = new List<BookResponse>();
                var responseList = this.dbContext.BookDetails;
                foreach (var response in responseList)
                {
                    if (response.IsDeleted == "No")
                    {
                        BookResponse bookResponse = new BookResponse();
                        bookResponse.BookId = response.BookId;
                        bookResponse.BookName = response.BookName;
                        bookResponse.AuthorName = response.AuthorName;
                        bookResponse.Description = response.Description;
                        bookResponse.Price = response.Price;
                        bookResponse.Quantity = response.Quantity;
                        bookResponse.CreatedDate = response.CreatedDate;
                        bookResponse.Image = response.Image;
                        bookResponseList.Add(bookResponse);
                    }
                }
                return bookResponseList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public BookResponse DeleteBook(int Id)
        {
            try
            {
                var response = this.dbContext.BookDetails.FirstOrDefault(value => ((value.BookId == Id)) && ((value.IsDeleted == "No")));

                if (response != null)
                {
                    response.IsDeleted = "Yes";
                    this.dbContext.BookDetails.Update(response);
                    this.dbContext.SaveChanges();
                    return Response(response);
                }
                return bookResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public BookResponse Response(BookModel bookModel)
        {
            BookResponse bookResponse = new BookResponse();
            bookResponse.BookId = bookModel.BookId;
            bookResponse.BookName = bookModel.BookName;
            bookResponse.AuthorName = bookModel.AuthorName;
            bookResponse.Description = bookModel.Description;
            bookResponse.Price = bookModel.Price;
            bookResponse.Quantity = bookModel.Quantity;
            bookResponse.CreatedDate = bookModel.CreatedDate;
            bookResponse.ModificationDate = bookModel.ModificationDate;
            bookResponse.Image = bookModel.Image;
            return bookResponse;
        }

        public string AddImage(BookRequestModel requestModel)
        {
            Account account = new Account(
                                     configuration["CloudinarySettings:CloudName"],
                                     configuration["CloudinarySettings:ApiKey"],
                                     configuration["CloudinarySettings:ApiSecret"]);
            var path = requestModel.Image.OpenReadStream();
            Cloudinary cloudinary = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(requestModel.Image.FileName, path)
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.Url.ToString();
        }
    }
}
