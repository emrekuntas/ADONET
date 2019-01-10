using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// emre küntaş
/// </summary>
namespace winDapper
{
    class UrunSiparis
    {
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        //
        private int orderID;

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        //
        private string orderDate;

        public string OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }
        //d
        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private decimal unitPrice;

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

    }
}
