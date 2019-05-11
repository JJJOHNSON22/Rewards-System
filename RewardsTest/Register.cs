using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Text;

namespace RewardsTest
{
    public class Register
    {
       public void RegisterUser()
        {
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            string phoneNumber = Console.ReadLine();
            int rewardsCount = 0;

            string connStr = @"data source = ./BarberShopRewardsData.db3";

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "insert into Customers (FirstName, LastName, PhoneNumber)" +
                        "values (@firstName, @lastName, @phoneNumber); Select last_insert_rowid();";

                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    int x = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.CommandText = "insert into Rewards (CustID, RewardCount) values (@x, 0);";
                    cmd.Parameters.AddWithValue("@x", x);
                    cmd.Parameters.AddWithValue("0", rewardsCount);
                    cmd.ExecuteNonQuery();


                    conn.Close();
                    Console.WriteLine("Data Inserted");
                }
            }

        }
    }
}
