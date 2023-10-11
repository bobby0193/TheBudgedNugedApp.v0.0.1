using System;
using TheBudgedNugedApp.v0._0._1;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("\nWellcome to the TheBudgedNugedApp ");
        Console.WriteLine("_________________________________");
        Console.WriteLine("\nHow many expenses do you suspect you will have?\n");
        int numberOfExpenses = Convert.ToInt32(Console.ReadLine());
        int output; // int defined in the do while loop for selecting conditions
        Expense[] expenses = new Expense[numberOfExpenses];
        do
        {
            Console.WriteLine("\n___________________________\n");
            Console.WriteLine("Chose a function");
            Console.WriteLine("___________________________\n");
            Console.WriteLine("Add Expense => 1 ");
            Console.WriteLine("___________________________\n");
            Console.WriteLine("Remove Expense => 2 ");
            Console.WriteLine("___________________________\n");
            Console.WriteLine("Summery => 3 ");
            Console.WriteLine("___________________________\n");
            Console.WriteLine("Totoal Money Spend => 4 ");
            Console.WriteLine("___________________________\n");
            Console.WriteLine("Totoal Change Expense => 5 ");
            Console.WriteLine("___________________________\n");
            Console.WriteLine("Exit => 99");
            Console.WriteLine("___________________________\n");

            output = Convert.ToInt32(Console.ReadLine());

            // Exit Condition Chek
            if (output == 99) { Console.WriteLine("Shutting down..."); continue; }

            // Inputs Testing Things 
            int cost = 0;
            string expenseType = " ";
            int quantity = 0;
            int curID = 0;
            int total = 0;

            switch (output)
            {
                case 1:
                    Expense.addExpense(expenses, numberOfExpenses);
                    break;
                case 2: // Remove Expense
                    Console.WriteLine("Deleting an Expense");
                    Console.WriteLine("______________________\n");

                    Console.WriteLine("ID of the Expense => ");
                    curID = Convert.ToInt32(Console.ReadLine());

                    Expense.deleteExpense(expenses, curID);
                    break;

                case 3: // Summery
                    Console.WriteLine("Displaying All Expenses:");
                    Console.WriteLine("_________________________\n");
                    Expense.Summery(expenses);
                    total = Expense.totalExpense(expenses);
                    Console.WriteLine($"Total Money Spend = {total}\n");
                    break;



                case 4: // Totoal Spend
                    Console.WriteLine("Calculating Monthly Expense");
                    Console.WriteLine("______________________\n");
                    total = Expense.totalExpense(expenses);
                    Console.WriteLine($"Total Money Spend = {total}\n");
                    break;


                case 5:// Change an expense
                    Expense.Summery(expenses);
                    Console.WriteLine("Chose an expense to be Changed");
                    Console.WriteLine("______________________\n");
                    Console.WriteLine("ID of the Expense => ");
                    curID = Convert.ToInt32(Console.ReadLine());

                    Expense.deleteExpense(expenses, curID);
                    Console.WriteLine($"ID : {curID} is Deleted\n");

                    Expense.addExpense(expenses, numberOfExpenses);
                    Console.WriteLine("\nDone!");
                    break;

            }

        } while (output != 99);
        Console.WriteLine("Goodbye!");
    }
}
