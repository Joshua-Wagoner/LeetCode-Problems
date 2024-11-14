namespace LeetCode
{
    /**
     * Author: Joshua Wagoner
     * DLM: 11/13/2024
     * Copyright 2024, 2025 All Rights Reserved
     * 
     * Problem came from Leetcode
     * Name of Problem: Trapped Rain Water
     * source: https://leetcode.com/problems/trapping-rain-water/description/
     */
    public class TrappedRainWater
    {
        private int[] elevationMap;

        private int trappedWaterCount;

        private int startingIndex;

        private int leftIndex;
        private int rightIndex;

        private int leftPointer;
        private int rightPointer;

        private bool boundryCheckFlag;

        //Helper Methods
        public bool CheckBounds(int target, int startAt)
        {
            bool bounded = false;

            for (int i = startAt; i < elevationMap.Length; i++)
                if (elevationMap[i] >= target)
                    bounded = true;

            return bounded;
        }

        public void Shift()
        {
            leftIndex = rightIndex;
            rightIndex += 1;

            leftPointer = elevationMap[leftIndex];
            rightPointer = elevationMap[rightIndex];

            Debug.Print("Shifted Both Pointers");
        }

        public void AdvanceR()
        {
            rightIndex += 1;

            rightPointer = elevationMap[rightIndex];

            Debug.Print("Advanced Right Pointer");
        }

        public void TriggerBoundryFlag()
        {
            boundryCheckFlag = true;
            Debug.Print("Boundry Check Flag Triggered.");
        }

        public void ResetBoundryFlag()
        {
            boundryCheckFlag = false;
            Debug.Print("Boundry Check Flag Reset.");
        }

        //Main Function
        public int Solution(int[] elevationMap)
        {
            boundryCheckFlag = false;

            this.elevationMap = elevationMap;

            startingIndex = 0;

            leftIndex = startingIndex;
            rightIndex = leftIndex + 1;

            leftPointer = elevationMap[leftIndex];
            rightPointer = elevationMap[rightIndex];
            
            while(rightIndex != elevationMap.Length - 1)
            {
                Debug.Print("Left Index: " + leftIndex);
                Debug.Print("Right Index: " + rightIndex);
                Debug.Print("Left Pointer: " + leftPointer);
                Debug.Print("Right Pointer: " + rightPointer);

                //Has the right pointer reached the end of the collection?
                if (rightIndex == elevationMap.Length - 1)
                {
                    Debug.Print("Right Pointer reached Length of Elevation Map Collection.");
                    return trappedWaterCount;
                }
                else
                {
                    if (leftPointer > rightPointer)
                    {
                        Debug.Print("Left Pointer > Right Pointer.");
                        if (boundryCheckFlag)
                        {
                            Debug.Print("Boundry Already Checked.");
                            trappedWaterCount += leftPointer - rightPointer;
                            Debug.Print("Added " + (leftPointer - rightPointer) + " to trapped Water Count.");
                            AdvanceR();
                        }
                        else if (CheckBounds(leftPointer, rightIndex + 1))
                        {
                            TriggerBoundryFlag();
                            Debug.Print("CheckBounds with Parameters(" + "Left Pointer: " + leftPointer 
                                + ", Right Index + 1: " + (rightIndex + 1) + ") : True");
                            trappedWaterCount += leftPointer - rightPointer;
                            Debug.Print("Added " + (leftPointer - rightPointer) + " to trapped Water Count.");
                            AdvanceR(); 
                        }
                        
                        else
                        {
                            Debug.Print("CheckBounds with Parameters(" + "Left Pointer: " + leftPointer
                                + ", Right Index + 1: " + (rightIndex + 1) + ") : False");
                            if ((leftPointer - rightPointer) > 1) {
                                Debug.Print("Left Pointer - Right Pointer > 1");

                                bool found = false;
                                while ((leftPointer - rightPointer) > 1 && !found)
                                {
                                    leftPointer -= 1;
                                    Debug.Print("Left Pointer: " + leftPointer);

                                    if (CheckBounds(leftPointer, rightIndex + 1))
                                    {
                                        TriggerBoundryFlag();
                                        Debug.Print("CheckBounds with Parameters(" + "Left Pointer: " + leftPointer
                                + ", Right Index + 1: " + (rightIndex + 1) + ") : True");
                                        trappedWaterCount += leftPointer - rightPointer;
                                        Debug.Print("Added " + (leftPointer - rightPointer) + " to trapped Water Count.");
                                        AdvanceR();
                                        found = true;
                                    }
                                    else
                                    {
                                        Debug.Print("CheckBounds with Parameters(" + "Left Pointer: " + leftPointer
                                + ", Right Index + 1: " + (rightIndex + 1) + ") : False");
                                    }
                                }
                            }
                            else
                            {
                                Debug.Print("Left Pointer - Right Pointer < 2 or == 1");
                                Shift();
                                ResetBoundryFlag();
                            }
                            
                        }

                    }
                    else if (leftPointer < rightPointer || leftPointer == rightPointer)
                    {
                        Debug.Print("Left Pointer < Right Pointer or Left Pointer == Right Pointer.");
                        Shift();
                        ResetBoundryFlag();
                    }
                }
            }
            return trappedWaterCount;
        }
    }
}
