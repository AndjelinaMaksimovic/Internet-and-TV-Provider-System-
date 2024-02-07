﻿using System;
using System.Collections.Generic;
using System.Data;
using library.Database;

namespace test_ca {
    internal class Program {
        static void Main(string[] args) {
            
            Database db = Database.GetInstance();
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("@desc", "%" + "r" + "%");

            var x = db.Query("SELECT * FROM client where username LIKE @desc", keyValuePairs);

            foreach (DataRow row in x.Rows) {
                foreach(var e in row.ItemArray) {
                    Console.Write(e + " ");
                }
                Console.WriteLine();
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
