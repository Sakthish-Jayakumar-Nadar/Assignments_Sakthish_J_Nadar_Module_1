namespace Assignment5.model
{
    internal class TwoWheeler : Insurance
    {
        public override void InsuranceCalculation() 
        {
            Console.WriteLine("Insurance For Two Wheelers : " + (basePrice + 500) + "Rs");
        }
    }
}
