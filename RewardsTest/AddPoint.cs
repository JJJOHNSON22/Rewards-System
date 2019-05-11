using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RewardsTest
{
    public class AddPoint
    {
        public void Points()
        {
            Console.WriteLine("Enter your phone number.");
            string phoneNumber = Console.ReadLine();

            string connStr = @"data source = ./BarberShopRewardsData.db3";

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "select CustID from Customers where PhoneNumber = @phoneNumber; Select last_insert_rowid();";

                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    int x = Convert.ToInt32(cmd.ExecuteScalar());

                    if (x == 0)
                    {
                        Console.WriteLine("Customer not found");
                        conn.Close();
                    }

                    else
                    {
                        cmd.CommandText = "update Rewards set RewardCount = RewardCount + 1 where CustID = @x;";
                        cmd.Parameters.AddWithValue("@x", x);
                        cmd.ExecuteNonQuery();

                        conn.Close();
                        Console.WriteLine("Points have been allocated.");
                    }
                }
            }
        }
    }
}
