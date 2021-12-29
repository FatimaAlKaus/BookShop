using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class BookDto : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get { return GetValidationError(columnName); }
        }
        public bool IsNew { get; set; }
        private static readonly string[] ValidatedProperties = { "Title", "Price", "Authors" };

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                {
                    if (GetValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Title":
                    if (Title.Length < 2)
                    {
                        error = "Название должно быть больше 1 символа!";
                    }
                    break;
                case "Price":
                    if (Price <= 0)
                    {
                        error = "Недопустимая цена товара!";
                    }
                    break;
                case "Authors":
                    if (Authors.Length < 2)
                    {
                        error = "Имя автора должно быть больше 1 символа!";
                    }
                    break;
            }
            return error;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Authors { get; set; }
        public string Genres { get; set; }
        public List<GenreDto> GenresDto { get; set; }
        public string ImagePath { get; set; }

        public string Error => throw new NotImplementedException();
    }
}
