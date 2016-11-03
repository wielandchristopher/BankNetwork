using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    public class GlobalVariables
    {
        static int custID;

        public int getCustID()
        {
            return custID;
        }
        public void setCustID(int _ID)
        {
            custID = _ID;
        }


    }
}
