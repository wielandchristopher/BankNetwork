namespace BankClient
{
    public class GlobalVariables
    {
        static int custID;
        static long Accnumber = 0;
        static int CountAcc = 0;
        static int CountUser = 0;
        static int CountaddUser = 0;
        static int maxCountAcc = 5;
        static int maxCountUser = 5;

        public int getCustID()
        {
            return custID;
        }
        public void setCustID(int _ID)
        {
            custID = _ID;
        }
        public long getAccnumber()
        {
            return Accnumber;
        }
        public void setAccnumber(long number)
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
        public int getCountUser()
        {
            return CountUser;
        }
        public void setCountUser(int number)
        {
            CountUser = number;
        }
        public int getmaxCountAcc()
        {
            return maxCountAcc;
        }
        public void setmaxCountAcc(int number)
        {
            maxCountAcc = number;
        }
        public int getmaxCountUser()
        {
            return maxCountUser;
        }
        public void setmaxCountUser(int number)
        {
            maxCountUser = number;
        }
        public int getCountaddUser()
        {
            return CountaddUser;
        }
        public void setCountaddUser(int number)
        {
            CountaddUser = number;
        }
    }
}
