﻿namespace BankClient
{
    public class GlobalVariables
    {
        static int custID;
        static int Accnumber = 0;
        static int CountAcc = 0;
        static int maxCountAcc = 5;

        public int getCustID()
        {
            return custID;
        }
        public void setCustID(int _ID)
        {
            custID = _ID;
        }
        public int getAccnumber()
        {
            return Accnumber;
        }
        public void setAccnumber(int number)
        {
            Accnumber = number;
        }
        public int getCountAcc()
        {
            return CountAcc;
        }
        public void setCountAcc(int number)
        {
            CountAcc = number;
        }
        public int getmaxCountAcc()
        {
            return maxCountAcc;
        }
        public void setmaxCountAcc(int number)
        {
            maxCountAcc = number;
        }
    }
}
