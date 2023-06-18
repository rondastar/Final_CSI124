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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary;
// Ronda Rutherford
// CSI 124 Final
// June 17, 2023
namespace Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Data.Preload();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ValidateUser();
        }

        // Uses userAccount methods to validate user information, should open up admin window if userAccount has a Role.Admin, or user page if the have a Role.User
        public void ValidateUser()
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            for (int i = 0; i < Data.accounts.Count; i++)
            {
                if (Data.accounts[i].IsUser(userName))
                {
                    if(Data.accounts[i].ValidateUser(userName, password))
                    {
                        // saves logged in user as current user
                        Data.currentUser = Data.accounts[i];
                        if(Data.currentUser.UserRole == 0)
                        {
                            UserWindow uw = new UserWindow();
                            uw.Show();
                        }
                        else if(Data.currentUser.UserRole == (UserAccount.Role)1)
                        {
                            AdminWindow aw = new AdminWindow();
                            aw.Show();
                        }
                        else
                        {
                            MessageBox.Show("No user role assigned. Please contact your admin.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid password");
                    }
                }
            }
        }

    } // class 
} // namespace
