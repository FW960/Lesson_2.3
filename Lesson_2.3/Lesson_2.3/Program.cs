using System;

namespace Lesson_2._3
{
    internal class Program
    {
        public static (Bank, (string, string)) bankAccountCreation(Bank bankAccounts, (string bankAccountValueType, string bankAccountType) bankAccountValueAndType)
        {
            Console.WriteLine("Создание счета.");

            Console.WriteLine("Каким образом вы хотите создать счет?");

            Console.WriteLine("1 - Счет по умолчанию.");

            Console.WriteLine("2 - Создать счет и выбрать его тип.");

            Console.WriteLine("3 - Создать счет и внести сумму в рублях на баланс.");

            Console.WriteLine("4 - Создать счет, выбрать его тип и внести сумму в выбранной валюте на баланс.");

            string UserChoice = string.Empty;

            int checkCode = 0;

            do
            {
                UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "1":
                        bankAccounts = new Bank(); bankAccountValueAndType.bankAccountType = "Рублевый"; bankAccountValueAndType.bankAccountValueType = "RUB"; checkCode = 1;
                        break;
                    case "2":
                        (int bankAccountType, string bankTypeOfAccount, string bankAccountValueType) cortage = bankTypeBankAccountCreate(bankAccountValueAndType);

                        bankAccountValueAndType.bankAccountType = cortage.bankTypeOfAccount;

                        bankAccountValueAndType.bankAccountValueType = cortage.bankAccountValueType;

                        bankAccounts = new Bank(0, cortage.bankAccountType, 0);

                        Console.WriteLine("Счет успешно создан.");

                        checkCode = 1;

                        break;
                    case "3":

                        (int balance, string bankTypeOfAccount, string bankAccountValueType) cortage1 = bankBalanceAccountCreate(bankAccountValueAndType);

                        bankAccountValueAndType.bankAccountType = cortage1.bankTypeOfAccount;

                        bankAccountValueAndType.bankAccountValueType = cortage1.bankAccountValueType;

                        bankAccounts = new Bank(cortage1.balance);

                        Console.WriteLine("Счет успешно создан.");

                        checkCode = 1;

                        break;
                    case "4":
                        (int bankAccountType, string bankTypeOfAccount, string bankAccountValueType) cortage2 = bankTypeBankAccountCreate(bankAccountValueAndType);

                        bankAccountValueAndType.bankAccountType = cortage2.bankTypeOfAccount;

                        bankAccountValueAndType.bankAccountValueType = cortage2.bankAccountValueType;

                        (int balance, string bankTypeOfAccount, string bankAccountValueType) cortage3 = bankBalanceAccountCreate(bankAccountValueAndType);

                        bankAccounts = new Bank(cortage3.balance, cortage2.bankAccountType);

                        Console.WriteLine("Счет успешно создан.");

                        checkCode = 1;

                        break;
                    default:
                        Console.WriteLine("Введите команду корректно.");
                        break;
                }

            } while (checkCode == 0);


            return (bankAccounts, bankAccountValueAndType);

        }
        static (int, string, string) bankTypeBankAccountCreate((string bankAccountValueType, string bankAccountType) bankAccountValueAndType)
        {
            Console.WriteLine("Введите тип счета, который вы хотели бы открыть.");

            Console.WriteLine("1 - Рублевый счет");

            Console.WriteLine("2 - Бюджетный счет.");

            Console.WriteLine("3 - Валютный счет.");

            string NewUserChoice = string.Empty;

            int bankAccountType = 0;

            int checkCode = 0;

            do
            {
                NewUserChoice = Console.ReadLine();

                if (NewUserChoice == "1" || NewUserChoice == "2" || NewUserChoice == "3")
                {
                    bankAccountType = Convert.ToInt32(NewUserChoice);

                    if (bankAccountType == 1)
                    {
                        bankAccountValueAndType.bankAccountType = "Рублевый"; bankAccountValueAndType.bankAccountValueType = "RUB";
                    }
                    else if (bankAccountType == 2)
                    {
                        bankAccountValueAndType.bankAccountType = "Бюджетный"; bankAccountValueAndType.bankAccountValueType = "RUB";
                    }
                    else
                    {
                        bankAccountValueAndType.bankAccountType = "Валютный"; bankAccountValueAndType.bankAccountValueType = "USD";
                    }

                    checkCode = 1;
                }
                else
                {
                    continue;
                }

            } while (checkCode == 0);

            return (bankAccountType, bankAccountValueAndType.bankAccountType, bankAccountValueAndType.bankAccountValueType);
        }
        static (int, string, string) bankBalanceAccountCreate((string bankAccountValueType, string bankAccountType) bankAccountValueAndType)
        {
            Console.WriteLine("Введите сумму, которую вы хотите внести на счет.");

            string NewUserChoice = string.Empty;

            int CheckCode = 0;

            int Sum = 0;

            do
            {
                try
                {
                    int SumOfRubles = Convert.ToInt32(Console.ReadLine());

                    if (SumOfRubles < 0)
                    {
                        Console.WriteLine("Вы не можете положить на счет отрицательную сумму.");

                        continue;
                    }
                    else
                    {
                        bankAccountValueAndType.bankAccountType = "Рублевый"; bankAccountValueAndType.bankAccountValueType = "RUB";

                        Console.WriteLine($"На счет внесена сумма в {SumOfRubles} {bankAccountValueAndType.bankAccountValueType}");

                        Sum = SumOfRubles;

                        CheckCode = 1;
                    }
                }
                catch
                {
                    Console.WriteLine("Введите сумму в корректном формате.");
                }
            } while (CheckCode == 0);

            return (Sum, bankAccountValueAndType.bankAccountType, bankAccountValueAndType.bankAccountValueType);
        }

        static void Main()
        {
            int numberOfAccounts = 0;

            Console.WriteLine("Введите число банковских счетов.");

            do
            {
                try
                {
                    numberOfAccounts = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число банковских счетов в корректном формате.");

                    continue;
                }
                if (numberOfAccounts < 0 || numberOfAccounts == 0)
                {
                    Console.WriteLine("Введите число банковских счетов в корректном формате.");
                }

            } while (numberOfAccounts == 0 || numberOfAccounts < 0);

            Bank[] bankAccounts = new Bank[numberOfAccounts];

            (string bankAccountValueType, string bankAccountType)[] bankAccountsValuesAndTypes = new (string AccountType, string ValueType)[numberOfAccounts];

            for (int i = 0; i < bankAccounts.Length; i++)
            {

                (bankAccounts[i], bankAccountsValuesAndTypes[i]) = bankAccountCreation(bankAccounts[i], bankAccountsValuesAndTypes[i]);

                Console.Clear();

            }

            string UserChoice = string.Empty;

            do
            {
                Console.WriteLine("Введите 'Посмотреть', чтобы посмотреть информацию о счете и его номер.");

                Console.WriteLine("Введите 'Снять', чтобы снять деньги со счета.");

                Console.WriteLine("Введите 'Перевести', чтобы перевести деньги с одного счета на другой.");

                Console.WriteLine("Введите 'Очистить', чтобы очистить консоль.");

                Console.WriteLine("Введите 'Выход', чтобы выйти из приложения.");

                UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "Посмотреть":
                        Console.WriteLine("Введите номер аккаунта.");

                        try
                        {
                            int accountNumber = Convert.ToInt32(Console.ReadLine());

                            if (accountNumber <= 0 || accountNumber > bankAccounts.Length)
                            {
                                Console.WriteLine("Введите существующий номер счета.");

                                break;
                            }


                            bankAccountGetInfo(bankAccounts, bankAccountsValuesAndTypes, --accountNumber);
                        }
                        catch
                        {
                            Console.WriteLine("Произошла ошибка.");

                            Console.Clear();
                        }
                        break;
                    case "Снять":
                        try
                        {
                            Console.WriteLine("Введите номер счета, с которого хотите снять деньги.");

                            int BankAccountNum = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите сумму, которую хотите снять.");

                            int WithdrawSumOfMoney = Convert.ToInt32(Console.ReadLine());

                            WithdrawMoney(ref bankAccounts, bankAccountsValuesAndTypes, BankAccountNum, WithdrawSumOfMoney);

                        }
                        catch
                        {
                            Console.WriteLine("Произошла ошибка");

                            break;
                        }
                        break;
                    case "Перевести":

                        try
                        {
                            Console.WriteLine("Введите номер счета с которого вы хотите перевести сумму.");

                            int SourceBankAccount = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите сумму, которую вы хотели бы перевести.");

                            int TransferSumOfMoney = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите счет, на который вы хотели бы перевести сумму.");

                            int DestinationBankAccount = Convert.ToInt32(Console.ReadLine());

                            TransferMoney(ref bankAccounts, bankAccountsValuesAndTypes, SourceBankAccount, DestinationBankAccount, TransferSumOfMoney);

                            Console.WriteLine("Введите номер счета в корректном формате.");

                        }
                        catch
                        {
                            Console.WriteLine("Произошла.");
                            break;
                        }
                        break;
                    case "Очистить":
                        Console.Clear();
                        break;
                    case "Выход":
                        break;
                    default:
                        Console.WriteLine("Введите запрос корректно.");
                        break;
                }
            } while (UserChoice != "Выход");

        }
        static void bankAccountGetInfo(Bank[] bank, (string bankAccountValueType, string bankAccountType)[] bankAccountsValuesAndTypes, int bankAccountNumber)
        {
            Console.WriteLine($"Номер счета: {bank[bankAccountNumber].BankAccountNumber}");

            Console.WriteLine($"Баланс: {bank[bankAccountNumber].Balance} {bankAccountsValuesAndTypes[bankAccountNumber].bankAccountValueType}");

            Console.WriteLine($"Тип счета: {bankAccountsValuesAndTypes[bankAccountNumber].bankAccountType}");
        }
        static void WithdrawMoney(ref Bank[] bankAccounts, (string ValueType, string AccountType)[] bankAccountsValuesAndTypes, int BankAccountNum, int SumOfMoney)
        {

            for (int i = 0; i < bankAccounts.Length; i++)
            {
                if (bankAccounts[i].BankAccountNumber == BankAccountNum || bankAccounts[i].Balance >= SumOfMoney)
                {
                    if (SumOfMoney <= 0)
                    {
                        Console.WriteLine($"Вы не можете снять {SumOfMoney} {bankAccountsValuesAndTypes[i].ValueType}.");

                        return;
                    }

                    bankAccounts[i].Balance = bankAccounts[i].Balance - SumOfMoney;

                    Console.WriteLine($"Со счета {bankAccounts[i].BankAccountNumber} успешно снято {SumOfMoney} {bankAccountsValuesAndTypes[i].ValueType}. Остаток: {bankAccounts[i].Balance} {bankAccountsValuesAndTypes[i].ValueType}");

                    return;

                }
                if (bankAccounts[i].BankAccountNumber - 1 == i)
                {
                    Console.WriteLine("Счет не существует или на нем недостаточно средств.");
                }
            }
        }
        public static void TransferMoney(ref Bank[] bankAccounts, (string ValueType, string AccountType)[] bankAccountsValuesAndTypes, int SourceBankAccount, int DestinationBankAccount, int SumOfMoney)
        {

            for (int i = 0; i < bankAccounts.Length; i++)
            {
                if (bankAccounts[i].BankAccountNumber == SourceBankAccount && bankAccounts[i].Balance >= SumOfMoney)
                {
                    Console.WriteLine("Введите счет, на который вы хотели бы перевести сумму.");

                    for (int j = 0; j < bankAccounts.Length; j++)
                    {
                        if (bankAccounts[j].BankAccountNumber == DestinationBankAccount && bankAccountsValuesAndTypes[i].ValueType == bankAccountsValuesAndTypes[j].ValueType)
                        {
                            if (SumOfMoney <= 0)
                            {
                                Console.WriteLine($"Вы не можете перевести {SumOfMoney} {bankAccountsValuesAndTypes[i].ValueType}.");

                                return;
                            }

                            bankAccounts[i].Balance = bankAccounts[i].Balance - SumOfMoney;

                            bankAccounts[j].Balance = bankAccounts[j].Balance + SumOfMoney;

                            Console.WriteLine($"На счет {bankAccounts[j].BankAccountNumber} успешно зачислено {SumOfMoney} {bankAccountsValuesAndTypes[j].ValueType}. Баланс: {bankAccounts[j].Balance} {bankAccountsValuesAndTypes[j].ValueType}");
                            return;
                        }
                        if (j == bankAccounts.Length - 1)
                        {
                            Console.WriteLine("Введенный счет получения не существует или вы пытаетесь перевести деньги на счета разной валютности.");
                            return;
                        }
                    }
                }
                if (bankAccounts.Length - 1 == i)
                {
                    Console.WriteLine("Счет не существует или на нем недостаточно средств.");
                    return;
                }
            }

        }
    }

}


public class Bank
{
    public static int LastBankAccountNumber = (int)BankAccountInfo.bankAccountNumber;

    public static int BankAccountNumberEnumerater()
    {
        if (LastBankAccountNumber == 0)
        {
            Random random = new Random();

            LastBankAccountNumber = random.Next(40000000, 50000000);
        }

        int BankAccountNumber = LastBankAccountNumber++;

        return BankAccountNumber;

    }

    private enum BankAccountInfo
    {
        bankAccountNumber = 0,

        balance = 0,

        bankAccountType = 1 // 1 Означает то, что это рублевый счет(по умолчанию). 2 Бюджетный счет. 3 Валютный.
    }

    public Bank()
    {
        BankAccountNumber = BankAccountNumberEnumerater();

        Balance = (int)BankAccountInfo.balance;

        BankAccountType = (int)BankAccountInfo.bankAccountType;

    }
    public Bank(int Balance)
    {

        BankAccountNumber = BankAccountNumberEnumerater();

        this.Balance = Balance;

        BankAccountType = (int)BankAccountInfo.bankAccountType;

    }
    public Bank(int NoBalance, int BankAccountType, int RandomNum)
    {
        BankAccountNumber = BankAccountNumberEnumerater();

        Balance = (int)BankAccountInfo.balance;

        this.BankAccountType = BankAccountType;
    }
    public Bank(int Balance, int BankAccountType)
    {
        BankAccountNumber = BankAccountNumberEnumerater();

        this.Balance = Balance;

        this.BankAccountType = BankAccountType;
    }


    public int BankAccountNumber;

    public int Balance = (int)BankAccountInfo.balance;

    public int BankAccountType = (int)BankAccountInfo.bankAccountType;

}

