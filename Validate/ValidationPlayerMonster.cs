namespace Evolve_Game.Validate
{
    public class ValidationPlayerMonster
    {

        public static List<int> CalcularAtributos() {
            List<int> values = new List<int>();
            System.Random rnd = new System.Random();
            for (int i = 0; i < 6; i++)
            {
                values.Add(rnd.Next(0, 101));
            }

            values.Add((int)values.Take(5).Average());

            return values;
        }
    }
}
