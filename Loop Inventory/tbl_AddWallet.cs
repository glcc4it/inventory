//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Loop_Inventory
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_AddWallet
    {
        public int id { get; set; }
        public Nullable<int> WelletNumber { get; set; }
        public string Date { get; set; }
        public string AccountType { get; set; }
        public string CurrencyType { get; set; }
        public string WalletName { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public string Status { get; set; }
    }
}
