using System.Collections.Generic;

namespace Assignment6.ContactFiles
{
    /// <summary>
    /// A class used to manage the contact. It keeps them stored in a list and has the ability to add, edit and delete contacts.
    /// Written by Sebastian Aspegren
    /// </summary>
    public class ContactManager
    {
        private List<Contact> contactRegistry;

        /// <summary>
        /// Constructor that initiates the list of contacts.
        /// </summary>
        public ContactManager()
        {
            contactRegistry = new List<Contact>();
        }

        /// <summary>
        /// Methos used to fetch a contact using a specific index
        /// </summary>
        /// <param name="index">the position of the contact in the list</param>
        /// <returns>null if index is out of bounds, otherwise returns a new contact object with the same values as the one in the list</returns>
        public Contact GetContact(int index)
        {
            if (index < 0 || index >= contactRegistry.Count)
                return null;

            // return contactRegistry[index];


            return new Contact(contactRegistry[index]);
        }

        /// <summary>
        /// A method used to add contacts
        /// </summary>
        /// <param name="firstName">firstname of the contact</param>
        /// <param name="lastName">last name of the contact</param>
        /// <param name="address"> address of the contact</param>
        /// <returns>true if successfully added, otherwise false</returns>
        public bool AddContact(string firstName, string lastName, Address address)
        {
            Contact newContact = new Contact(firstName, lastName, address);
            if (newContact.validate())
            {
                contactRegistry.Add(newContact);
                return true;
            }
            return false;

        }

        /// <summary>
        /// Add contact method with a contact object as parameter
        /// </summary>
        /// <param name="contact">the contact object we wish to add to the list</param>
        /// <returns>true upon success, otherwise false</returns>
        public bool AddContact(Contact contact)
        {
            Contact newContact = new Contact(contact);
            if (newContact.validate())
            {
                contactRegistry.Add(newContact);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method used to edit a contact.
        /// </summary>
        /// <param name="contact">How we want the contact in the list to look like</param>
        /// <param name="index">where it is located in the list</param>
        /// <returns>true upon success, otherwise false</returns>
        public bool EditContact(Contact contact, int index)
        {
            if (contact.validate())
            {
                contactRegistry.RemoveAt(index);
                contactRegistry.Insert(index, contact);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method used to delete contacts from the list
        /// </summary>
        /// <param name="index">where the contact is located in the list</param>
        /// <returns>true upon success, otherwise false</returns>
        public bool DeleteContact(int index)
        {
            if (contactRegistry[index] != null)
            {
                contactRegistry.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method used to fetch information about all contacts.
        /// </summary>
        /// <returns>an array of strings where each string contains information about a contact</returns>
        public string[] GetContactsInfo()
        {
            string[] strInfoStrings = new string[contactRegistry.Count];

            int i = 0;
            foreach (Contact contact in contactRegistry)
            {
                strInfoStrings[i++] = contact.ToString();
            }
            return strInfoStrings;
        }

    }
}
