using System;
using System.Collections.Generic;
using System.IO;
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
using ClassLibrary;

namespace Final
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public static List<Transaction> transactions = new List<Transaction>();
        public UserWindow()
        {
            InitializeComponent();
            DisplayCurrentUser();
            DisplayUserTransactions();
            CreateNewFile(Data.UsersTransactions());
        }

        // Provided Code
        // Used to create a file on load to guarantee a file exists. Use on page load.
        private void CreateNewFile(string filePath)
        {
            FileStream tryout = File.OpenWrite(filePath);
            tryout.Close();
            tryout.Dispose();
        }

        void DisplayCurrentUser()
        {
            lblCurrentUser.Content = $"Current User: {Data.currentUser.Name}";
        }
        void DisplayUserTransactions()
        {
            lvUserTransactions.ItemsSource = transactions;
        }
        private void btnSortName_Click(object sender, RoutedEventArgs e)
        {
            transactions.Sort();
            UpdateListView();
        }

        private void btnSortTime_Click(object sender, RoutedEventArgs e)
        {
            Transaction_Sort_Time tst = new Transaction_Sort_Time();
            transactions.Sort(tst);
            UpdateListView();
        }

        private void btnSortPrice_Click(object sender, RoutedEventArgs e)
        {
            Transaction_Sort_Price tsp = new Transaction_Sort_Price();
            transactions.Sort(tsp);
            UpdateListView();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            string itemName = txtItemName.Text;
            string userItemPrice = txtItemPrice.Text;
            
            Decimal.TryParse(userItemPrice, out decimal itemPrice);
            transactions.Add(new Transaction(itemName, itemPrice));
            UpdateListView();
        }

        private void btnSaveNewCSV_Click(object sender, RoutedEventArgs e)
        {

        }

        // Updates the listview
        public void UpdateListView()
        {
            lvUserTransactions.Items.Refresh();
        } 

        //    public void WriteTransactions(string filePath) // When called saves transaction list to the users csv

        //    public void ReadTransactions() // Loads the users specific csv
    }
    }
