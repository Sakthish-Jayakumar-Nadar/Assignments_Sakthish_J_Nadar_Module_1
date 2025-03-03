namespace Assignment5.model
{
    internal class ThreeWheelers : Insurance
    {
        public override void InsuranceCalculation()
        {
            Console.WriteLine("Insurance For Three Wheelers : " + (basePrice + 800) + "Rs");
        }
    }
}
