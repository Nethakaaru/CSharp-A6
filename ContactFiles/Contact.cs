namespace Assignment6.ContactFiles
{
    /// <summary>
    /// A datastructure representing a contact.
    /// Written by Sebastian Aspegren
    /// </summary>
    public class Contact
    {
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private Address address;

        /// <summary>
        /// Primary constructor with no parameters. Initiates the address variable.
        /// </summary>
        public Contact()
        {
            Address = new Address();
        }

        /// <summary>
        /// Constructor that accepts a contact object as a parameter. used to replicate contact objects.
        /// </summary>
        /// <param name="contact"> The contact that we want values from</param>
        public Contact(Contact contact)
        {
            this.FirstName = contact.FirstName;
            this.LastName = contact.LastName;
            this.Address = new Address(contact.Address);
        }

        /// <summary>
        /// 3 parameter constructor
        /// </summary>
        /// <param name="firstName">first name of the contact</param>
        /// <param name="lastName">surname of the contact</param>
        /// <param name="address">where the contact lives</param>
        public Contact(string firstName, string lastName, Address address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = new Address(address);
        }

        /// <summary>
        /// Method used to detect if anything is null or empty.
        /// </summary>
        /// <returns>false is something is wrong, else true</returns>
        public bool validate()
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || address == null)
                return false;
            if(address.Validate())
            return true;
            return false;
        }

        /// <summary>
        /// ToString method that returns a string with information regarding the contact.
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0, -20} {1}", FullName, Address.ToString());
        }

        /// <summary>
        /// Property that return the first name and the last name of the contact with a blankspace in between.
        /// </summary>
        public string FullName
        {
            get
            {
                return firstName + " " + lastName;
            }
        }

        /// <summary>
        /// Property used to get and set the first name of the contact.
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        /// <summary>
        /// Property used to get and set the last name of the contact.
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        /// <summary>
        /// Property used to get and set the address of the contact.
        /// </summary>
        public Address Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
    }
}
