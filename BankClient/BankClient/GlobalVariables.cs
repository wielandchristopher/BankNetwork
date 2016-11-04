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
        static int CreditAccnumber = 0;
        static int DepositAccnumber = 0;

        public int getCustID()
        {
            return custID;
        }
        public void setCustID(int _ID)
        {
            custID = _ID;
        }
        public int getCreditAccnumber()
        {
            return CreditAccnumber;
        }
        public void setCreditAccnumber(int number)
        {
            CreditAccnumber = number;
        }
        public int getDepositAccnumber()
        {
            return DepositAccnumber;
        }
        public void setDepositAccnumber(int number)
        {
            DepositAccnumber = number;
        }

    }
}
