using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winDapper
{
    class Products
    {
        private int productID;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
    }
}
