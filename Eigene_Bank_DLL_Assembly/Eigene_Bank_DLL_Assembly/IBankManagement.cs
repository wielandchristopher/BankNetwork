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
        long createSavingsAccount(int _id);
        long createCreditAccount(int _id);
        void deleteSavingsAccount(long _sNumber, int _id);
        void deleteCreditAccount(long _cNumber, int _id);
        void depositCreditAcc(long _cNumber, String _usage, double _amount);
        void depositSavingsAcc(long _sNumber, String _usage, double _amount);
        void withdrawCreditAcc(long _cNumber, double _amount);
        void transfer(long _cNumber, long _toAccNumber, String _usage, double _amount);
        void addSavingsAccountUser(long _sNumber, int _id);
        void addCreditAccountUser(long _cNumber, int _id);
        long getBankAccountNumber(int _id, int _whichAccount);
        int getAccType(long Accnumber);
        double getDepositkontostand(long snumber);
        double getCreditkontostand(long snumber);
        int getDepositAccOwner(long snumber, int whichuser);
        int getCreditAccOwner(long cnumber, int whichuser);
        int deleteCreditAccUser(long Kontonummer, int additionalUser);
        int deleteSavingsAccUser(long Kontonummer, int additionalUser);

        void withdrawSavingsAcc(long _snumber, double _amount);

        // Währungsmodul und Kontoauszug
        void createBankStatement(long _accNumber);
        void convertMoney(long _cNumber, string _currency);
        void showChangeOfCourse(long _cNumber);
        double currencyConversion(int _currency, double _value);

        // BIC
        int getBankBIC();
    }
}
