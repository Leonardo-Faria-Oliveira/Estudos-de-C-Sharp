namespace DesignPatterns
{
    public class StrawberryCake : Cake
    {
        public override string Name { get; set; } = "Bolo de Morango";
        public override void Make()
        {
            Console.WriteLine("Fazendo bolo de morango");
        }
    }
}
