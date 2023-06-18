using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Final
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            DisplayCurrentUserLabel();
            PreloadComboBox();
            UpdateLVUser();
        }

        // Adds a new user to the accounts list using the data in the admin window text boxes
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            UserAccount.Role role = (UserAccount.Role)cbRoles.SelectedIndex;
            UserAccount newUser = new UserAccount(name, username, password, role);
            Data.AddUser(newUser);
            lvDisplayUsers.Items.Refresh();
        }

        // Provided Code - Loads the combo box for selecting a role
        void PreloadComboBox()
        {
            cbRoles.Items.Add("User");
            cbRoles.Items.Add("Admin");
            cbRoles.SelectedIndex = 0;
        }

        // updates the users list view
        void UpdateLVUser()
        {
            lvDisplayUsers.ItemsSource = Data.accounts;

        }
        void DisplayCurrentUserLabel()
        {
            lblCurrentUser.Content = $"Current User: {Data.currentUser.Name}";
        }
    }
}
