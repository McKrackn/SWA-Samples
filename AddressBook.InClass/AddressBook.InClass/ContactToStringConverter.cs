using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using AddressBook.InClass.Model;

namespace AddressBook.InClass
{
    public class ContactToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Contact)
            {
                Contact c = value as Contact;
                return $"{c.Lastname}, {c.Firstname.Substring(0,1)}.";
            }

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // don't touch because not needed
            throw new NotImplementedException();
        }
    }
}
