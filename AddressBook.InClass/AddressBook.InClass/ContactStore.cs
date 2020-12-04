using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AddressBook.InClass.Model;

namespace AddressBook.InClass
{
    public class ContactStore
    {
        public ObservableCollection<Contact> Contacts { get; }
        public ContactStore()
        {
            Contacts = new ObservableCollection<Contact>();

            Contacts.Add(new Contact()
            {
                Firstname = "Andy",
                Lastname = "Samberg",
                DateOfBirth = new DateTime(1978, 8, 18),

                InfoList = { new ContactInfo() {
                    Type = "Address",
                    Value = "First-Street 1; 11212 New York City - Brooklyn"
                }, new ContactInfo() {
                    Type = "Mail",
                    Value = "as@gmail.com",
                    Validated = true
                }, new ContactInfo() {
                    Type="PhoneNumber",
                    Value=  "001/2345 67 89 - 1"
                }}
            });

            Contacts.Add(new Contact()
            {
                Firstname = "Melissa",
                Lastname = "Fumero",
                DateOfBirth = new DateTime(1982, 8, 19),

                InfoList = { new ContactInfo() {
                        Type = "Address",
                        Value = "Second-Street 2; 11212 New York City - Brooklyn"
                    }, new ContactInfo() {
                        Type = "Mail",
                        Value = "mf@gmail.com"
                    }, new ContactInfo() {
                        Type="PhoneNumber",
                        Value=  "001/2345 67 89 - 2"
                    }
                }
            });

            Contacts.Add(new Contact()
            {
                Firstname = "Andre",
                Lastname = "Baugher",
                DateOfBirth = new DateTime(1962, 7, 1),

                InfoList = { new ContactInfo() {
                        Type = "Address",
                        Value = "Third-Street 3; 11212 New York City - Brooklyn"
                    }, new ContactInfo() {
                        Type = "Mail",
                        Value = "ab@gmail.com"
                    }, new ContactInfo() {
                        Type="PhoneNumber",
                        Value=  "001/2345 67 89 - 3"
                    }
                }
            });
        }
    }
}
