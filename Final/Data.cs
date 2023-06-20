using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Text.Json;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace Final
{
    internal class Data
    {
        public static UserAccount? currentUser;

        public static List<UserAccount> accounts = new List<UserAccount>();

        public static string userInformation = "users.json";
        static string TransactionExtension = "_transaction.csv";

        // Use a static constructor to load the accounts list ( make sure a file exists before you try to load )
        static Data()
        {
            ReadUsers();
        }

        // Special Method with provided code ( helps save a file with the users name and transaction )
        // This creates a unique file automatically based on the user account that's logged in
        public static string UsersTransactions()
        {
            return currentUser.Name + TransactionExtension;
        }

        // Used to load accounts list the first time, then save to .json
        public static void Preload()
        {
            accounts.Add(new UserAccount("Bill", "bill", "bpass", 0));
            accounts.Add(new UserAccount("Ronda", "ronda", "rpass", (UserAccount.Role)1));
            accounts.Add(new UserAccount("Will", "will", "wpass", 0));
            accounts.Add(new UserAccount("Chen", "chen", "cpass", 0));
            accounts.Add(new UserAccount("Marcos", "marcos", "mpass", 0));
            SaveUsers();
        }

        // Add user to accounts and then save to json
        public static void AddUser(UserAccount account)
        {
            accounts.Add(account);
            SaveUsers();
        }

        // Save accounts json
        public static void SaveUsers()
        {
            JsonSerializerOptions jso = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonManager = JsonSerializer.Serialize(accounts, jso);

            File.WriteAllText(Data.userInformation, jsonManager);
        }


        // Read json and deserialize to accounts
        public static void ReadUsers()
        {
            string listFromFile = File.ReadAllText(userInformation);
            accounts = JsonSerializer.Deserialize<List<UserAccount>>(listFromFile);
        }
    }
}
