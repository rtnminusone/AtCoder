#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620, CS8625

class Program
{
	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		int N = int.Parse(S[0]);
		int K = int.Parse(S[1]);
		int[] T = new int[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			int k = int.Parse(S[i]);
			if (k < K)
			{
				K = k;
				T[i] = 1;
			}
			else T[i] = 0;
		}

		Console.WriteLine(string.Join("\n", T));
	}
}