using System.Collections;
using System.Collections.Generic;

public static class CurrencySystem {

	private static int currentDux = 2000;

	public  static void Set(int income)
	{
		currentDux += income;
	}

	public static int Get()
	{
		return currentDux;
	}

	public static bool EnoughDux(int cost)
	{
		if (cost > currentDux)
			return false;
		else
			return true;
	}

}
