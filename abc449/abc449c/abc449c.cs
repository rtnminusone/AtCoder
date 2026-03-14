#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		int N = int.Parse(S[0]);
		int L = int.Parse(S[1]);
		int R = int.Parse(S[2]);
		S[0] = Console.ReadLine();
		List<int>[] P = new List<int>[26];
		for (int i = 0; i < N; i++)
		{
			(P[S[0][i] - 'a'] ??= new List<int>()).Add(i);
		}

		long r = 0;
		for (int i = 0; i < 26; i++)
		{
			List<int> p = P[i];
			if (p == null || p.Count <= 1) continue;
			int ll = 0, lr = 0;
			for (int j = 0; j < p.Count; j++)
			{
				while (lr < j && p[j] - p[lr] > R)
				{
					lr++;
				}
				while (ll < j && p[j] - p[ll] >= L)
				{
					ll++;
				}
				r += Math.Max(0, ll - lr);
			}
		}

		Console.WriteLine(r);
	}
}