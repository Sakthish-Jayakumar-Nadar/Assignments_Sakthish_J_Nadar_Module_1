using System.ComponentModel;
using Assignment8.Interface;
using Assignment8.Model;
using Assignment8.Repository;

namespace Assignment8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int id;
            Console.WriteLine("Welcome to Appna Policies");

            DoYouHaveAccount:
            Console.WriteLine("\nDo you have an account ?\nPress 1 : Yes\nPress 2 : No\nPress 3 : Terminate program");
            bool isAccountOption = int.TryParse(Console.ReadLine(), out int accountOption);
            if(!isAccountOption ||  accountOption > 3 || accountOption < 1)
            {
                Console.WriteLine("\nInvalid input\nTry again");
                goto DoYouHaveAccount;
            }
            ILoginAndRegister loginAndRegister = new LoginAndRegister();
            LoginForm:
            if (accountOption == 1)
            {
                Console.WriteLine("\nLogin Form");
                Console.Write("Id : ");
                bool isId = int.TryParse(Console.ReadLine(), out id);
                if (!isId)
                {
                    InnerOption:
                    Console.WriteLine("\nInvalid input");
                    Console.WriteLine("Press 1: Try again");
                    Console.WriteLine("Press 2 : Go to start page");
                    bool isInnerOption = int.TryParse(Console.ReadLine(), out int innterOption);
                    if (!isInnerOption || innterOption > 2 || innterOption < 1)
                    {
                        goto InnerOption;
                    }
                    if (innterOption == 1)
                    {
                        goto LoginForm;
                    }
                    if (innterOption == 2)
                    {
                        goto DoYouHaveAccount;
                    }
                    
                }
                Console.Write("Password : ");
                string password = Console.ReadLine();
                bool isLoggedIn = loginAndRegister.Loggin(id, password);
                if (isLoggedIn)
                {
                    Console.WriteLine("\nLoggedin successfully");
                    Menu:
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("Press 1 : Add policy");
                    Console.WriteLine("Press 2 : View all policy");
                    Console.WriteLine("Press 3 : Search policy by Id");
                    Console.WriteLine("Press 4 : Updated policy");
                    Console.WriteLine("Press 5 : Delete policy");
                    Console.WriteLine("Press 6 : View active policy");
                    Console.WriteLine("Press any key to exit/Loggout");
                    bool isMenuOption = int.TryParse(Console.ReadLine(), out int menuOption);
                    if (isMenuOption)
                    {
                        IPolicy policy = new PolicyAction();
                        switch (menuOption)
                        {
                            case 1:
                                {
                                    AddPolicy:
                                    Console.WriteLine("\nAdd policy\nPolicy Type\nPress 1 : Life\nPress 2 : Health\nPress 3 : Vehical\nPress 4 : Property");
                                    bool isPolicyType = int.TryParse(Console.ReadLine(),out int policyType);
                                    if (!isPolicyType || policyType > 4 || policyType < 1)
                                    {
                                        Console.WriteLine("\nInvalid input\nTry again");
                                        goto AddPolicy;
                                    }
                                    Console.Write("Holder name : ");
                                    string holderName = Console.ReadLine();
                                    if (string.IsNullOrEmpty(holderName))
                                    {
                                        Console.WriteLine("\nInvalid input\nTry again");
                                        goto AddPolicy;
                                    }
                                    Console.Write("Policy period : ");
                                    bool isPolicyPeriod = int.TryParse(Console.ReadLine(), out int policyPeriod);
                                    if (!isPolicyPeriod)
                                    {
                                        Console.WriteLine("\nInvalid input\nTry again");
                                        goto AddPolicy;
                                    }
                                    bool addedResult = policy.AddNewPolicy(id, holderName, policyType, policyPeriod);
                                    if (addedResult)
                                    {
                                        Console.WriteLine("Policy add successfully");
                                    }
                                    if (!addedResult)
                                    {
                                        Console.WriteLine("Something went wrong");
                                        goto DoYouHaveAccount;
                                    }
                                    else
                                    {
                                        goto Menu;
                                    }
                                }
                            case 2:
                                {
                                    Console.WriteLine("\nView all policy");
                                    List<Policy> policies = policy.ViewAllPolicy(id);
                                    if (policies.Count > 0)
                                    {
                                        policies.ForEach(policy =>
                                        {
                                            Console.WriteLine($"PolicyId::{policy.PolicyId}\tHolder name::{policy.HolderName}\tPolicy type::{(Enums)policy.Type}\tStart date::{policy.StartDate.ToString("dd/MM/yyyy")}\tEnd date::{policy.EndDate.ToString("dd/MM/yyyy")}");
                                        });
                                    }
                                    else
                                    {
                                        Console.WriteLine("No available policies");
                                    }
                                    goto Menu;
                                }
                            case 3:
                                {
                                    SearchByPolicyId:
                                    Console.WriteLine("\nSearch policy by id");
                                    Console.Write("Enter Id : ");
                                    bool isPolicyId = int.TryParse(Console.ReadLine(), out int policyId);
                                    if (isPolicyId)
                                    {
                                        List<Policy> policies = policy.SearchPolicyById(id, policyId);
                                        if (policies.Count > 0)
                                        {
                                            policies.ForEach(policy =>
                                            {
                                                Console.WriteLine($"PolicyId::{policy.PolicyId}\tPolicy type::{(Enums)policy.Type}\tStart date::{policy.StartDate.ToString("dd/MM/yyyy")}\tEnd date::{policy.EndDate.ToString("dd/MM/yyyy")}");
                                            });                               
                                        }
                                        else
                                        {
                                            Console.WriteLine("No policy with id " + policyId);
                                            InnerOption:
                                            Console.WriteLine("Press 1: Try again");
                                            Console.WriteLine("Press 2 : Go to menu");
                                            bool isInnerOption = int.TryParse(Console.ReadLine(), out int innterOption);
                                            if(!isInnerOption || innterOption > 2 || innterOption < 1)
                                            {
                                                Console.WriteLine("\nInvalid input");
                                                goto InnerOption;
                                            }
                                            if(innterOption == 1)
                                            {
                                                goto SearchByPolicyId;
                                            }
                                            if(innterOption == 2)
                                            {
                                                goto Menu;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid input\nTry again");
                                        goto SearchByPolicyId;
                                    }
                                    goto Menu;
                                }
                            case 4:
                                {
                                    UpdateByPolicyId:
                                    Console.WriteLine("\nUpdate policy by id");
                                    Console.Write("Enter Id : ");
                                    bool isPolicyId = int.TryParse(Console.ReadLine(), out int policyId);
                                    if (isPolicyId)
                                    {
                                        bool isSuccess = policy.UpdatePolicyById(id, policyId);
                                        if (isSuccess)
                                        {
                                            Console.WriteLine($"Policy with id : {policyId} updated successfully");
                                        }
                                        if (!isSuccess)
                                        {
                                            Console.WriteLine("Invalid PolicyId : "+policyId);
                                        InnerOption:
                                            Console.WriteLine("Press 1: Try again");
                                            Console.WriteLine("Press 2 : Go to menu");
                                            bool isInnerOption = int.TryParse(Console.ReadLine(), out int innterOption);
                                            if (!isInnerOption || innterOption > 2 || innterOption < 1)
                                            {
                                                Console.WriteLine("\nInvalid input");
                                                goto InnerOption;
                                            }
                                            if (innterOption == 1)
                                            {
                                                goto UpdateByPolicyId;
                                            }
                                            if (innterOption == 2)
                                            {
                                                goto Menu;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid input\nTry again");
                                        goto UpdateByPolicyId;
                                    }
                                    goto Menu;
                                }
                            case 5:
                                {
                                    DeleteByPolicyId:
                                    Console.WriteLine("\nDelete policy by id");
                                    Console.Write("Enter Id : ");
                                    bool isPolicyId = int.TryParse(Console.ReadLine(), out int policyId);
                                    if (isPolicyId)
                                    {
                                        bool isSuccess = policy.DeletPolicy(id, policyId);
                                        if (isSuccess)
                                        {
                                            Console.WriteLine($"Policy with id:{policyId} deleted successfully");                                           
                                        }
                                        
                                        if (!isSuccess)
                                        {
                                            Console.WriteLine("No policy with id " + policyId);
                                        InnerOption:
                                            Console.WriteLine("Press 1: Try again");
                                            Console.WriteLine("Press 2 : Go to menu");
                                            bool isInnerOption = int.TryParse(Console.ReadLine(), out int innterOption);
                                            if (!isInnerOption || innterOption > 2 || innterOption < 1)
                                            {
                                                Console.WriteLine("\nInvalid input");
                                                goto InnerOption;
                                            }
                                            if (innterOption == 1)
                                            {
                                                goto DeleteByPolicyId;
                                            }
                                            if (innterOption == 2)
                                            {
                                                goto Menu;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid input\nTry again");
                                        goto DeleteByPolicyId;
                                    }
                                    goto Menu;
                                }
                            case 6:
                                {
                                    Console.WriteLine("\nView active policy");
                                    List<Policy> policies = policy.ShowActivePolicy(id);
                                    if (policies.Count > 0)
                                    {
                                        policies.ForEach(policy =>
                                        {
                                            Console.WriteLine($"PolicyId::{policy.PolicyId}\tHolder name::{policy.HolderName}\tPolicy type::{(Enums)policy.Type}\tStart date::{policy.StartDate.ToString("dd/MM/yyyy")}\tEnd date::{policy.EndDate.ToString("dd/MM/yyyy")}");
                                        });
                                    }
                                    else
                                    {
                                        Console.WriteLine("No available policies");
                                    }
                                    goto Menu;
                                }
                            default:
                                {
                                    accountOption = 4;
                                    goto LoginForm;
                                }
                        }
                    }
                    else
                    {
                        accountOption = 4;
                        goto LoginForm;
                    }
                }
                else
                {
                    InnerOption:
                    Console.WriteLine("\nInvalid credentials");
                    Console.WriteLine("Press 1: Try again");
                    Console.WriteLine("Press 2 : Go to start page");
                    bool isInnerOption = int.TryParse(Console.ReadLine(), out int innterOption);
                    if (!isInnerOption || innterOption > 2 || innterOption < 1)
                    {
                        goto InnerOption;
                    }
                    if (innterOption == 1)
                    {
                        goto LoginForm;
                    }
                    if (innterOption == 2)
                    {
                        goto DoYouHaveAccount;
                    }
                    goto LoginForm;
                }
            }
            if(accountOption == 2)
            {
                Console.WriteLine("\nRegister Form");
                Console.Write("Name : ");
                string name = Console.ReadLine();
                Console.Write("Password : ");
                string password = Console.ReadLine();
                loginAndRegister.Register(name, password);
                accountOption = 1;
                goto LoginForm;
            }
            if (accountOption == 4) 
            {
                id = -1;
                Console.WriteLine("Logged out successfully");
                goto DoYouHaveAccount;
            }
            Console.WriteLine("\nProgram terminated successfully");
        }
    }
}
