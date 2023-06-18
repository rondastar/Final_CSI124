﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Transaction_Sort_Price : IComparer<Transaction>
    {
        // compares the price of transactions and sorts them in ascending order
        public int Compare(Transaction x, Transaction y)
        {
             return x.Price.CompareTo(y.Price);
        }
    }
}
