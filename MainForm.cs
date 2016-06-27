using Assignment6.ContactFiles;
using System;
using System.Windows.Forms;

namespace Assignment6
{
    /// <summary>
    /// The main class containing the logic and user interface elements.
    /// Written by Sebastian Aspegren
    /// </summary>
    public partial class MainForm : Form
    {

        private ContactManager contactmanager;

        /// <summary>
        /// Constructor to initiate the user interface and the field.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            contactmanager = new ContactManager();
            InitGUI();
        }

        /// <summary>
        /// Set all graphical elements to their default status.
        /// </summary>
        private void InitGUI()
        {
            lblNoOfRecords.Text = "0";
            string[] names = Enum.GetNames(typeof(Countries));
            cBoxCountry.Items.AddRange(names);
            cBoxCountry.SelectedIndex = (int)Countries.Sverige;
        }

        /// <summary>
        /// Method called when the add button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ReadInput())
            {
                UpdateGUI();
            }
        }

        /// <summary>
        /// Method that updates the list and label with the current data stored in the contact manager.
        /// </summary>
        private void UpdateGUI()
        {
            string[] strContacts = contactmanager.GetContactsInfo();

            if (strContacts != null)
            {
                listBoxMain.Items.Clear();
                listBoxMain.Items.AddRange(strContacts);
                lblNoOfRecords.Text = listBoxMain.Items.Count.ToString();
            }
        }

        /// <summary>
        /// Method used to validate the input and then add a contact object to the list if it is okay.
        /// </summary>
        /// <returns>true if the contact was successfully validated, otherwise false</returns>
        private bool ReadInput()
        {
            bool ok = false;
            Contact contact = CreateContact();
            if(contact!= null)
            ok = contact.validate();
            if (ok)
            {
                contactmanager.AddContact(contact);
            }
            else
            {
                MessageBox.Show("Check your input then try again!");
            }
            return ok;
        }

        /// <summary>
        /// A method used to create a contact object using the current input
        /// </summary>
        /// <returns>a new contact object</returns>
        private Contact CreateContact()
        {
            Contact contact = new Contact();
            contact.FirstName = txtBoxFirstName.Text;
            contact.LastName = txtBoxLastName.Text;
            Address address = ReadAddress();
            contact.Address = address;
            if (contact.validate())
            {
                return contact;
            }
            return null;
        }

        /// <summary>
        /// A method used to create a new address object using the current input
        /// </summary>
        /// <returns>the address object if it validates, othewise null</returns>
        private Address ReadAddress()
        {
            Address address = new Address();
            address.City = txtBoxCity.Text;
            address.Country = (Countries)cBoxCountry.SelectedIndex;
            address.Street = txtBoxStreet.Text;
            address.ZipCode = txtBoxZipCode.Text;

            if (address.Validate())
            {
                return address;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Method called when the button change is clicked. it uses the contact manager field to edit a contact given the current input and the currently selected contact.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            int index = listBoxMain.SelectedIndex;
            if (index != -1)
            {
                contactmanager.EditContact(CreateContact(), index);
                UpdateGUI();
            }
        }

        /// <summary>
        /// Called when the user clicks the delete button. it deletes the contact that is highlighted in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = listBoxMain.SelectedIndex;
            if (index != -1)
            {
                contactmanager.DeleteContact(index);
                UpdateGUI();
            }

        }

        /// <summary>
        /// A method used to populate the textboxes with information regarding the currently selected contact.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateContactInfoFromRegistry();
        }

        /// <summary>
        /// Method used to fetch information regarding the selected contact and populate all boxes with information regarding it.
        /// </summary>
        private void UpdateContactInfoFromRegistry()
        {
            int index = listBoxMain.SelectedIndex;
            if (index < 0)
                return;

            Contact contact = contactmanager.GetContact(index);

            cBoxCountry.SelectedIndex = (int)contact.Address.Country;
            txtBoxFirstName.Text = contact.FirstName;
            txtBoxLastName.Text = contact.LastName;
            txtBoxCity.Text = contact.Address.City;
            txtBoxStreet.Text = contact.Address.Street;
            txtBoxZipCode.Text = contact.Address.ZipCode;
        }
    }
}
