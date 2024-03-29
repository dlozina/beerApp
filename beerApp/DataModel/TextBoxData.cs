﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace beerApp.DataModel
{
    class TextBoxData
    {
        private string _year;
        public string Year
        {
            get { return _year; }
            set
            {
                _year = value;
                //if (String.IsNullOrEmpty(value))
                //{
                //    throw new ApplicationException("Enter year in format: 10-2007");
                //}
            }
        }
    }

    public class StringRangeValidationRule : ValidationRule
    {
        private int _minimumLength = -1;
        private int _maximumLength = -1;
        private string _errorMessage;

        public int MinimumLength
        {
            get { return _minimumLength; }
            set { _minimumLength = value; }
        }

        public int MaximumLength
        {
            get { return _maximumLength; }
            set { _maximumLength = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            string inputString = (value ?? string.Empty).ToString();
            if (inputString.Length < this.MinimumLength || (this.MaximumLength > 0 &&inputString.Length > this.MaximumLength) || inputString.Any(char.IsLetter)) 
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }
            return result;
        }
    }
}
