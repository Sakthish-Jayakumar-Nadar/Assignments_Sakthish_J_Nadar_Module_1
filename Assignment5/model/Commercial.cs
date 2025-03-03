namespace Assignment5.model
{
    internal class Commercial : Insurance
    {
        public override void InsuranceCalculation()
        {
            Console.WriteLine("Insurance For Commercial : " + (basePrice + 1000) + "Rs");
        }
    }
}
