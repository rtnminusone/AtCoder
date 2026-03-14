#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620, CS8625

using System.Text;

class Program
{
	public static Dictionary<int, int> D = new Dictionary<int, int>();

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();

		string[] S = Console.ReadLine().Split();
		int N = int.Parse(S[0]);
		int K = int.Parse(S[1]);
		(int, int)[] T = new (int, int)[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = (int.Parse(S[i]), i);
		}
		Array.Sort(T, (a, b) => a.Item1.CompareTo(b.Item1));

		for (int i = 0; i < K; i++)
		{
			D.Clear();
			int k = int.Parse(Console.ReadLine());
			S = Console.ReadLine().Split();
			for (int j = 0; j < k; j++)
			{
				D[int.Parse(S[j]) - 1] = 1;
			}

			for (int j = 0; j < T.Length; j++)
			{
				if (D.ContainsKey(T[j].Item2)) continue;
				sb.AppendLine(T[j].Item1.ToString());
				break;
			}
		}

		Console.WriteLine(sb.ToString());
	}
}