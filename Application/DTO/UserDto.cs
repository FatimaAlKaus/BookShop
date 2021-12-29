using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserDto : IDataErrorInfo
    {
        public string this[string columnName] => GetValidationError(columnName);

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public decimal Balance { get; set; }
        public string Error => throw new NotImplementedException();
        private static readonly string[] ValidatedProperties = { "UserName" };
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
                case "UserName":
                    if (UserName.Length < 2)
                    {
                        error = "Имя должно быть больше 1 символа!";
                    }
                    break;
            }
            return error;
        }
    }
}
