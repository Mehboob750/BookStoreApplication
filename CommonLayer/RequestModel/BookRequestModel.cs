﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace CommonLayer.RequestModel
{
    public class BookRequestModel
    {
        /// <summary>
        /// Gets or sets the BookName
        /// </summary>
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Book Name is not valid")]
        public string BookName { get; set; }

        /// <summary>
        /// Gets or sets the AuthorName
        /// </summary>
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Author Name is not valid")]
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        //[RegularExpression("^[A-Z][a-zA-Z]s?[a-zA-Z]*$", ErrorMessage = "Description is not valid")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Image
        /// </summary>
        public IFormFile Image { get; set; }
    }
}
