using System.Xml;

namespace Assignment8.Model
{
    internal class Policy
    {
        public int PolicyId { get; set; }
        public int CustomerId { get; set; }
        public string HolderName { get; set; }
        public int Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
