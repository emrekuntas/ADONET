using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winDapper
{
    class Categories
    {
        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        //
        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
