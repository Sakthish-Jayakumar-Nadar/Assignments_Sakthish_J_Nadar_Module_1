using Assignment8.Model;

namespace Assignment8.Interface
{
    internal interface IPolicy
    {
        public bool AddNewPolicy(int customerId, string name, int policyType, int policyPeriod);
        public List<Policy> ViewAllPolicy(int customerId);
        public List<Policy> SearchPolicyById(int customerId, int policyId);
        public bool UpdatePolicyById(int customerId, int policyId);
        public bool DeletPolicy(int customerId, int policyId);
        public List<Policy> ShowActivePolicy(int customerId);
    }
}
