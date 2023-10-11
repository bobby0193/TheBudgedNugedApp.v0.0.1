using System;
namespace TheBudgedNugedApp.v0._0._1
{
    public class Expense // All expenses use a list of spenses where items can be added or deleted (like in the maneger app)
    {

        public string Type;
        public int Cost;
        public DateTime Time;
        public int Volume;
        public int ID;


        public Expense(string type, int currentCost, DateTime time, int volume, int id) // Gets Expenses and adds them to a list 
        {
            Type = type;
            Cost = currentCost;
            Time = time;
            Volume = volume;
            ID = id;

            if (currentCost <= 0 || volume <= 0)
            {
                throw new ArgumentException("Cost and quantity cannot be negative.");
            }

            if (String.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("Type must be defined!");
            }


        }

        public static void addExpense(Expense[] expenses, int z)
        {
            // Check if the array is full.
            bool isFull = true;
            for (int i = 0; i < expenses.Length; i++)
            {
                if (expenses[i] == null)
                {
                    isFull = false;
                    break;
                }
            }

            if (isFull)
            {
                Console.WriteLine("\nError: Cannot add more expenses. Your expense list is full.");
                return;
            }

            Console.WriteLine("\nCreating a new Expense");
            Console.WriteLine("______________________\n");

            Console.WriteLine("Expense type => ");
            string expenseType = Console.ReadLine();

            Console.WriteLine("Amount Spend => ");
            int cost = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Amount Bought => ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            DateTime date = DateTime.Now;

            Random random = new Random();

            int curID;
            HashSet<int> existingIds = new HashSet<int>();
            foreach (var expense in expenses)
            {
                if (expense != null)
                {
                    existingIds.Add(expense.ID);
                }
            }
            do
            {
                curID = random.Next(0, z);
            } while (existingIds.Contains(curID));

            // Find a place to store the new expense
            bool added = false;

            for (int x = 0; x < expenses.Length; x++)
            {
                if (expenses[x] == null) // Check if this slot is empty/null
                {
                    expenses[x] = new Expense(expenseType, cost, date, quantity, curID); // Add the new expense here
                    Console.WriteLine("\nDisplaying Entered Expense: \n");
                    displayDetailesOfExpense(expenses[x]);
                    added = true; // Mark as added
                    break; // Exit the loop immediately after adding the expense to avoid adding it multiple times
                }
            }

            // If we did not add the expense, notify the user that the array is full
            if (!added)
            {
                Console.WriteLine("\nError: Cannot add more expenses. Your expense list is full.");
            }
        }


        public static void deleteExpense(Expense[] expenses, int id) // Deletes a expense (uses date&time)
        {
            int indexToDelete = -1;

            // Find the index of the expense to delete
            for (int i = 0; i < expenses.Length; i++)
            {
                if (expenses[i] != null && expenses[i].ID == id)
                {
                    indexToDelete = i;
                    break; // Exit the loop once we find the expense to delete
                }
            }

            // Delete the found expense, if one was found
            if (indexToDelete != -1)
            {
                expenses[indexToDelete] = null; // Set the found expense to null
                Console.WriteLine("Expense with ID: " + id + " was deleted.");
            }
            else
            {
                Console.WriteLine("Expense with ID: " + id + " not found.");
            }
        }

        public static void displayDetailesOfExpense(Expense expense)
        {
            Console.WriteLine($"ID: {expense.ID}, Type: {expense.Type}, Cost: {expense.Cost}, Date: {expense.Time}, Amount Bought: {expense.Volume}");
        }

        public static int totalExpense(Expense[] expenses) // Calcualtes monthly expenses automatically
        {
            if (expenses == null || expenses.Length == 0)
            { Console.WriteLine("No expenses recorded yet! "); return 0; }

            int totalExpense = 0;
            foreach (var expense in expenses)
            {
                if (expense != null)
                {
                    totalExpense += expense.Cost;
                }
            }
            return totalExpense;
        }
        public static void Summery(Expense[] expenses)
        {
            // Check if there's at least one non-null expense.
            bool hasExpenses = false;
            for (int i = 0; i < expenses.Length; i++)
            {
                if (expenses[i] != null)
                {
                    hasExpenses = true;
                    break;
                }
            }

            // If there are no expenses, inform the user and skip the displaying loop.
            if (!hasExpenses)
            {
                Console.WriteLine("No expenses recorded yet.");
            }
            else
            {
                // Iterate through each Expense object in the expenses array.
                for (int i = 0; i < expenses.Length; i++)
                {
                    // Check if the current Expense object is not null to avoid NullReferenceException.
                    if (expenses[i] != null)
                    {
                        Expense.displayDetailesOfExpense(expenses[i]);

                    }
                }
            }
        }
    }
}



