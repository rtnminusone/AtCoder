#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static long CountEven(long x)
	{
		if (x < 0) return 0;

		return x / 2 + 1;
	}

	public static long SumEven(long x)
	{
		if (x < 0) return 0;

		return (x / 2) * (x / 2 + 1);
	}

	public static long CountBlackEven(long x, long y)
	{
		if (x < 0 || y < 0) return 0;

		long s1 = SumEven(Math.Min(x, y)) + CountEven(Math.Min(x, y));
		if (x > y) s1 += (CountEven(x) - CountEven(y)) * (y + 1);

		long s2 = SumEven(Math.Min(y, x + 1));
		if (y > x + 1) s2 += (CountEven(y) - CountEven(x + 1)) * (x + 1);

		return s1 + s2;
	}

	public static long CountBlackAll(long x1, long x2, long y1, long y2)
	{
		if (x1 > x2 || y1 > y2) return 0;

		return CountBlackEven(x2, y2) - CountBlackEven(x1 - 1, y2) - CountBlackEven(x2, y1 - 1) + CountBlackEven(x1 - 1, y1 - 1);
	}

	public static long Solve(long L, long R, long D, long U)
	{
		long r = 0;

		long x1 = Math.Max(0, L), x2 = R;
		long y1 = Math.Max(0, D), y2 = U;
		if (x1 <= x2 && y1 <= y2) r += CountBlackAll(x1, x2, y1, y2);

		long xr = Math.Min(R, -1);
		if (L <= xr)
		{
			x1 = -xr;
			x2 = -L;
			y1 = Math.Max(0, D);
			y2 = U;
			if (y1 <= y2) r += CountBlackAll(x1, x2, y1, y2);
		}

		long yu = Math.Min(U, -1);
		if (D <= yu)
		{
			x1 = Math.Max(0, L);
			x2 = R;
			y1 = -yu;
			y2 = -D;
			if (x1 <= x2) r += CountBlackAll(x1, x2, y1, y2);
		}

		xr = Math.Min(R, -1);
		yu = Math.Min(U, -1);
		if (L <= xr && D <= yu)
		{
			x1 = -xr;
			x2 = -L;
			y1 = -yu;
			y2 = -D;
			r += CountBlackAll(x1, x2, y1, y2);
		}

		return r;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		long L = long.Parse(S[0]);
		long R = long.Parse(S[1]);
		long D = long.Parse(S[2]);
		long U = long.Parse(S[3]);

		Console.WriteLine(Solve(L, R, D, U));
	}
}