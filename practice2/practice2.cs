#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620, CS8625

class Program
{
	public static int N, K;
	public static char[] T, tmp;
	public static Dictionary<(char, char), string> D = new Dictionary<(char, char), string>();

	public static void Mergesort(int left, int right)
	{
		if (left >= right) return;

		int mid = (left + right) / 2;

		Mergesort(left, mid);
		Mergesort(mid + 1, right);

		Merge(left, mid, right);
	}

	public static void Merge(int left, int mid, int right)
	{
		int l = left, r = mid + 1, k = 0;

		while (l <= mid && r <= right)
		{
			if (D.ContainsKey((T[l], T[r])))
			{
				if (D[(T[l], T[r])].Equals("<")) tmp[k++] = T[l++];
				else tmp[k++] = T[r++];
			}
			else if (D.ContainsKey((T[r], T[l])))
			{
				if (D[(T[r], T[l])].Equals(">")) tmp[k++] = T[l++];
				else tmp[k++] = T[r++];
			}
			else
			{
				Console.WriteLine("? " + T[l] + " " + T[r]);
				Console.Out.Flush();
				D[(T[l], T[r])] = Console.ReadLine();
				D[(T[r], T[l])] = D[(T[l], T[r])].Equals(">") ? "<" : ">";
				if (D[(T[l], T[r])].Equals("<")) tmp[k++] = T[l++];
				else tmp[k++] = T[r++];
			}
		}

		while (l <= mid) tmp[k++] = T[l++];
		while (r <= right) tmp[k++] = T[r++];

		for (int i = 0; i < k; i++)
		{
			T[left++] = tmp[i];
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		T = new char[N];
		tmp = new char[N];
		for (int i = 0; i < N; i++)
		{
			T[i] = (char)('A' + i);
		}

		Mergesort(0, N - 1);

		Console.WriteLine("! " + string.Join("", T));
		Console.Out.Flush();
	}
}