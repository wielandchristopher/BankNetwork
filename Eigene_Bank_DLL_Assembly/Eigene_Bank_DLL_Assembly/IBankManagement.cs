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
        int createSavingsAccount(int _id);
        int createCreditAccount(int _id);
        void deleteSavingsAccount(int _sNumber, int _id);
        void deleteCreditAccount(int _cNumber, int _id);
        void depositCreditAcc(int _cNumber, String _usage, double _amount);
        void depositSavingsAcc(int _sNumber, String _usage, double _amount);
        void withdrawCreditAcc(int _cNumber, double _amount);
        void transfer(int _cNumber, int _toAccNumber, String _usage, double _amount);
        void addSavingsAccountUser(int _sNumber, int _id);
        void addCreditAccountUser(int _cNumber, int _id);
        int getBankAccountNumber(int _id, int _whichAccount);
        string getAccType(int Accnumber);

        // Währungsmodul und Kontoauszug
        void createBankStatement(int _accNumber);
        void convertMoney(int _cNumber, string _currency);
        void showChangeOfCourse(int _cNumber);
    }
}
