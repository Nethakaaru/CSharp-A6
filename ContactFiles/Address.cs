namespace Assignment6.ContactFiles
{
    /// <summary>
    /// A class representing an address. Each address is located on a street, has a zip code, is located in a city and a country.
    /// Written by Sebastian Aspegren
    /// </summary>
    public class Address
    {
        private string street;
        private string zipCode;
        private string city;
        private Countries country;

        /// <summary>
        /// If no parameters are given when an address is created the next consructor is called with these 3 parameters
        /// </summary>
        public Address() :
            this(string.Empty, string.Empty, "Malmö")
        {

        }

        /// <summary>
        /// Constructor for creating an address object using an existing one.
        /// </summary>
        /// <param name="address">The address object that we want to imitate.</param>
        public Address(Address address)
        {
            this.Street = address.street;
            this.ZipCode = address.zipCode;
            this.City = address.city;
            this.Country = address.country;
        }

        /// <summary>
        /// A constructor for address with 3 parameters. It passes all parameters to the 4 parameter constructor so the country field gets a value.
        /// </summary>
        /// <param name="street">the street the address is on</param>
        /// <param name="zip">the zip code of the address</param>
        /// <param name="city">The city the address is in</param>
        public Address(string street, string zip, string city) :
            this(street, zip, city, Countries.Sverige)
        {

        }

        /// <summary>
        /// A 4 paramter constructor used to create address objects.
        /// </summary>
        /// <param name="street">the street the address is on</param>
        /// <param name="zip">the zip code of the address</param>
        /// <param name="city">The city the address is in</param>
        /// <param name="country">The country the address is in</param>
        public Address(string street, string zip, string city, Countries country)
        {
            this.Street = street;
            this.ZipCode = zip;
            this.City = city;
            this.Country = country;
        }

        /// <summary>
        /// Property for the street field. Used to get an set the street variable.
        /// </summary>
        public string Street
        {
            get
            {
                return street;
            }

            set
            {
                street = value;
            }
        }

        /// <summary>
        /// Property for the zipCode field. Used to get an set the zipCode variable.
        /// </summary>
        public string ZipCode
        {
            get
            {
                return zipCode;
            }

            set
            {
                zipCode = value;
            }
        }

        /// <summary>
        /// Property for the city field. Used to get an set the city variable.
        /// </summary>
        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        /// <summary>
        /// Property for the country field. Used to get an set the country variable.
        /// </summary>
        public Countries Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
            }
        }

        /// <summary>
        /// Method used to return the country as a string instead of Countries enum.
        /// </summary>
        /// <returns>Return a pretty little string representing the country</returns>
        public string GetCountryAsString()
        {
            string strCountry = country.ToString();
            strCountry = strCountry.Replace("_", " ");
            return strCountry;
        }

        /// <summary>
        /// ToString method that returns a string containing information regarding street, zip code, city and the country where the address is.
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0, -25} {1, -8} {2, -10} {3}", street, zipCode, city, GetCountryAsString());
        }

        /// <summary>
        /// A method used to check so the input from the user is not null
        /// </summary>
        /// <returns> false if something null or empty is detected, else true</returns>
        public bool Validate()
        {
            if (string.IsNullOrEmpty(street.Trim( )) || string.IsNullOrEmpty(zipCode.Trim( )) || string.IsNullOrEmpty(city.Trim( )))
                return false;
            else
                return true;
        }
    }
}
