using Assignment8.Model;

namespace Assignment8.Interface
{
    internal interface ILoginAndRegister
    {
        public bool Loggin(int id, string password);
        public void Register(string name, string password);

    }
}
