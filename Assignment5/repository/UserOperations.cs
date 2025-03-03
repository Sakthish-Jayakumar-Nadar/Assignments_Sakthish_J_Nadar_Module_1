using Assignment5.exception;
using Assignment5.model;

namespace Assignment5.repository
{
    internal class UserOperations : IUserOperations
    {
        Dictionary<int, User> _users = new Dictionary<int, User>()
        {
            { 1, new User(){ AccNumber = 1, Name = "Om"} },
            { 2, new User(){ AccNumber = 2, Name = "Sakthish"} },
            { 3, new User(){ AccNumber = 3, Name = "Shreekant"} },
            { 4, new User(){ AccNumber = 4, Name = "Sartak"} },
            { 5, new User(){ AccNumber = 5, Name = "Rahul"} }
        }; 
        bool IUserOperations.GetUserByAccNo(string accNoString)
        {
            try
            {
                bool isAccNo =  int.TryParse(accNoString, out int accNo);
                if (isAccNo)
                {
                    bool gotUser = _users.TryGetValue(accNo, out User user);
                    if (gotUser && user != null)
                    {
                        Console.WriteLine("LoggedIn successfully");
                        Console.WriteLine($"Ac number : {user.AccNumber} \t User name : {user.Name}");
                        return true;
                    }
                    else
                    {
                        throw new InvalidAccNo($"Acc number : {accNo} is incorrect or do not exist");
                    }
                }
                else
                {
                    throw new InvalidAccNo($"Invalid input");
                }
            }
            catch (InvalidAccNo ian)
            {
                Console.WriteLine(ian.Message);
            }
            return false;
        }
    }
}
