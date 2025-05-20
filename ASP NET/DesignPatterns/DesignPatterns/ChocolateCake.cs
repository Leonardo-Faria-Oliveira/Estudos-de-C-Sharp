namespace DesignPatterns
{
    public class ChocolateCake : Cake
    {

        public override string Name { get; set; } = "Bolo de Chocolate";
        public override void Make()
        {
            Console.WriteLine("Fazendo bolo de chocolate");
        }
    }
}
