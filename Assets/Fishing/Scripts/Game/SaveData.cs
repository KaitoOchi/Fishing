using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    [System.Serializable]
    public struct Data
    {
        public int money;
        public int rodPower;
        public int[] feed;
        public int[] GetNum;
        public float[] maxSize;
    }

    public Data saveData;
}
