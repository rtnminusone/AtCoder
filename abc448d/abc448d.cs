#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620, CS8625

class Program
{
	public static int N;
	public static int[] T;
	public static bool[] V;
	public static string[] R;
	public static List<int>[] L;
	public static Dictionary<int, int> D = new Dictionary<int, int>();

	public static void DFS(int node, bool visited)
	{
		if (visited || D[T[node]] >= 2)
		{
			R[node] = "Yes";
			visited = true;
		}
		else R[node] = "No";

		if (L[node] == null) return;
		foreach (int l in L[node])
		{
			if (V[l]) continue;
			if (!D.ContainsKey(T[l])) D[T[l]] = 1;
			else D[T[l]]++;
			V[l] = true;
			DFS(l, visited);
			D[T[l]]--;
			V[l] = false;
		}
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N];
		V = new bool[N];
		R = new string[N];
		L = new List<int>[N];
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}
		for (int i = 0; i < N - 1; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			(L[left] ??= new List<int>()).Add(right);
			(L[right] ??= new List<int>()).Add(left);
		}

		V[0] = true;
		D[T[0]] = 1;
		DFS(0, false);

		Console.WriteLine(string.Join("\n", R));
	}
}