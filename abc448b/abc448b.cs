#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620, CS8625

class Program
{
	public static int N, M;
	public static long[] T;
	public static List<long>[] L;

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new long[M];
		L = new List<long>[M];
		S = Console.ReadLine().Split();
		for (int i = 0; i < M; i++)
		{
			T[i] = long.Parse(S[i]);
		}
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			(L[int.Parse(S[0]) - 1] ??= new List<long>()).Add(long.Parse(S[1]));
		}

		long R = 0;
		for (int i = 0; i < M; i++)
		{
			if (L[i] == null) continue;
			L[i].Sort();
			long remain = T[i];

			foreach (long l in L[i])
			{
				if (remain <= 0) break;
				long use = Math.Min(remain, l);
				R += use;
				remain -= use;
			}
		}

		Console.WriteLine(R);
	}
}