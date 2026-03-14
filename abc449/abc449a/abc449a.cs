#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static void Main()
	{
		double R = double.Parse(Console.ReadLine()) / 2.0;

		Console.WriteLine(Math.PI * R * R);
	}
}