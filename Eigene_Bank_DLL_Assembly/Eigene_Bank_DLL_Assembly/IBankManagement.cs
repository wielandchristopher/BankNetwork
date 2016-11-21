using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Eigene_Bank_DLL_Assembly
{
    public interface IBankManagement
    {
        // Interface Methoden des Customer Managements
        int createCustomer(String _Vorname, String _Nachname, String _Geburtsdatum, String _adresse, String _Wohnort, String _Telefon);
        void changeCustomer(int _id, String _Vorname, String _Nachname, String _adresse, String _Wohnort, String _Telefon);
        int getCustomer(String _firstName, String _lastName, String _birthDate);        // Statt searchUser
        void deleteCustomer(int _id);

        // Interface Methoden des Account Managements
        String createSavingsAccount(int _id);
        string createCreditAccount(int _id);
        void deleteSavingsAccount(String _sNumber, int _id);
        void deleteCreditAccount(String _cNumber, int _id);
        void depositCreditAcc(String _cNumber, String _usage, double _amount);
        void depositSavingsAcc(String _sNumber, String _usage, double _amount);
        void withdrawCreditAcc(String _cNumber, double _amount);
        void transfer(String _cNumber, String _toAccNumber, String _usage, double _amount);
        void addSavingsAccountUser(String _sNumber, int _id);
        void addCreditAccountUser(String _cNumber, int _id);
        String getBankAccountNumbers(int _id);
        int getAccType(String Accnumber);
        double getDepositkontostand(String snumber);
        double getCreditkontostand(String snumber);
        //int getDepositAccOwner(String snumber, String whichuser);
        //int getCreditAccOwner(String cnumber, String whichuser);
        int deleteCreditAccUser(String Kontonummer, int additionalUser);
        int deleteSavingsAccUser(String Kontonummer, int additionalUser);

        void withdrawSavingsAcc(String _snumber, double _amount);

        // Währungsmodul und Kontoauszug
        void createBankStatement(String _accNumber);
        void convertMoney(String _cNumber, string _currency);
        void showChangeOfCourse(String _cNumber);
        double currencyConversion(int _currency, double _value);

        // BIC
        int getBankBIC();
    }
}
