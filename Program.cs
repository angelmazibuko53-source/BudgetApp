namespace BudgetApp
{
    internal class Program
    {
        //Global Variables
        static double totalIncome, totalExpense, budgetLimit, balance;
        static double income, expense;
        static int menuNr, userAge, numIncome, numExpense;
        static string userName;

        static void Main(string[] args)
        {
            //The main menu will only call the user profile to enter the users information
            //Then the menu will go straight to the main menu
            UserProfile();
            Menu();
        }
        static void Menu()
        {
            //The Main Menu where the user will chose which information they want to enter
            Console.Clear();
            Console.WriteLine("*****************************************");
            Console.WriteLine();
            Console.WriteLine("           MICKEY'S BUDGET APP           ");
            Console.WriteLine("                MAIN MENU                ");
            Console.WriteLine();
            Console.WriteLine("1. Add Income                            ");
            Console.WriteLine("2. Add Expense                           ");
            Console.WriteLine("3. View Balance                          ");
            Console.WriteLine("4. Exit                                  ");
            Console.WriteLine();
            Console.WriteLine("*****************************************");
            Console.WriteLine();
            Console.WriteLine("Please enter menu number 1, 2, 3 or 4 to acess the menu.");
            menuNr = Convert.ToInt16(Console.ReadLine());

            CallMenu();

        }
       
            static void CallMenu()
            {
                switch (menuNr)
                {
                    //Calls all the methods and loops back to the main menu after the user is done entering information for each section.
                    case 1:
                        AddIncome();
                        Menu();
                        break;
                    case 2:
                        Expense();
                        Menu();
                        break;
                    case 3:
                        ViewBalance();
                        Menu();
                        break;

                    case 4:
                        ExitProgram();     //Breaks the loop so that the user can exit the app when they choose the option to leave
                        break;
                    default:
                        // Reports back when an incorrect number has been added, and brings back the user back to the main menu
                        Console.WriteLine("The menu number entered was incorrect.");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        Menu();   //Loops back to the main menu

                        break;

                }
            }

        
        static void UserProfile()
        {
            //The user must enter their details.
            Console.Clear();
            Console.WriteLine("********************************************");
            Console.WriteLine();
            Console.WriteLine("      MICKEY'S BUDGET APP    ");
            Console.WriteLine("         USER PROFILE        ");
            Console.WriteLine();
            Console.WriteLine("********************************************");
            Console.WriteLine();
            Console.WriteLine("Please enter your Name:");
            userName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Please enter your Age:");
            userAge = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Welcome to Mickey's Budget App {0}", userName);    //Welcomes users to the app
            Console.WriteLine();
            Console.ReadKey();
        }
        static void AddIncome()
        {

            //The user inputs their total income
            Console.Clear();
            Console.WriteLine("How many income sources do you have?");
            numIncome = Convert.ToInt16(Console.ReadLine());
            // the for loop is for when the user has more than one income.
            for (int i = 0; i < numIncome; i++)
            {
                Console.WriteLine("Enter income source {0} ", i + 1);  //adds every time theres more than one income
                income = Convert.ToDouble(Console.ReadLine());
                totalIncome += income;

            }
            Console.WriteLine("Your total income:    R{0}", totalIncome);
            Console.WriteLine("Income added successfully!");
            Console.WriteLine();

            //The user can set a budget limit after adding their income.
            Console.WriteLine("Enter your monthly budget limit:  ");
            budgetLimit = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Budget limit added successfully!");
            Console.ReadKey();

        }
        static void Expense()
        {
            //User must input all their expenses 
            Console.Clear();
            Console.WriteLine("How many expenses do you have?");
            numExpense = Convert.ToInt16(Console.ReadLine());
            // the for loop is for when the user has more than one expense.
            for (int i = 0; i < numExpense; i++)
            {
                Console.WriteLine("Enter monthly expenses amount {0}: ", i + 1);
                expense = Convert.ToDouble(Console.ReadLine());
                totalExpense += expense;         //The amount they have to use for the month so that the remaining money can be saved
            }

            Console.WriteLine("Total Expenses:  R{0}  ",totalExpense);
            Console.WriteLine("Expenses added successfully!");
            Console.ReadKey();

        }
        static void ViewBalance()
        {
            Calculations();  //brings the calculations to the viewbalance method so that the input that the user entered can be showen and calculated
            Console.Clear();  //All the users infomation is recorded and show in the view balance method
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.WriteLine("            VIEW BALANCE             ");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.WriteLine("Name:                {0}", userName);
            Console.WriteLine("Age:                 {0}", userAge);
            Console.WriteLine("Total Income:       R{0}", totalIncome);
            Console.WriteLine("Total Expenses:     R{0}", totalExpense);
            Console.WriteLine("Remaining Budget:   R{0}", balance);
            Console.WriteLine();


            // Warns you when you the expenses are 80% closer to the budget limit
            if (totalExpense >= budgetLimit * 0.8 && totalExpense <= budgetLimit)
            {
                Console.WriteLine("Warning! you are nearing your budget limit {0}", userName);
            }
            // It shows when you have fineshed your budget or when you have already suppursed your budget!
            else if (totalExpense > budgetLimit)
            {
                Console.WriteLine("Warning! {0} You have exceeded your budget limit!", userName);
            }

            //This if statement was not mix with the above so that both conditions when they are meet they can appear
            if (balance < 0)
            {
                Console.WriteLine("Warning! {0} You are overspending.", userName);
            }
            else if (balance == 0)
            {
                Console.WriteLine(" {0} You have spent all your money!", userName);

            }
            // Shows the remaining money left 
            else
            {
                Console.WriteLine("You have R{0} remaining", balance);
            }


            Console.ReadKey();   //To exit the view balance menu and get back to the main menu
        }
        static void Calculations()
        {
            //Basic calculations
            balance = totalIncome - totalExpense;
        }
        static void ExitProgram()
        {
            //The goodbye program after the user has used the app.
            Console.Clear();
            Console.WriteLine("**************************************************");
            Console.WriteLine();
            Console.WriteLine("              MICKEY'S BUDGET APP                 ");
            Console.WriteLine("                 EXIT PROGRAM                     ");
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            Console.WriteLine();
            Console.WriteLine("Thank you for using Mickey's Budget App. GoodBye! ");
            Console.WriteLine("Press any key to exit...");
            Console.WriteLine();
            Console.ReadKey(); //Exits the app
        }
    }
}
