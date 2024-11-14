﻿namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elevationMap = [20000, 19999, 19998, 19997, 19996, 19995, 19994, 19993, 19992, 19991, 19990, 19989, 19988,
                19987, 19986, 19985, 19984, 19983, 19982, 19981, 19980, 19979, 19978, 19977, 19976, 19975, 19974, 19973, 19972,
                19971, 19970, 19969, 19968, 19967, 19966, 19965, 19964, 19963, 19962, 19961, 19960, 19959, 19958, 19957, 19956,
                ];
            Console.WriteLine(new TrappedRainWater().Solution(elevationMap));
            Debug.Print("Elevation Map Length:" + elevationMap.Length);

            Console.Read();
        }


    }
}
