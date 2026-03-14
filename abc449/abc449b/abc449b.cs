#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();

		string[] S = Console.ReadLine().Split();
		int N = int.Parse(S[0]);
		int M = int.Parse(S[1]);
		int K = int.Parse(S[2]);

		for (int i = 0; i < K; i++)
		{
			S = Console.ReadLine().Split();
			int q = int.Parse(S[0]);
			int w = int.Parse(S[1]);
			if (q == 1)
			{
				sb.AppendLine((w * M).ToString());
				N -= w;
			}
			else
			{
				sb.AppendLine((w * N).ToString());
				M -= w;
			}
		}

		Console.WriteLine(sb.ToString());
	}
}