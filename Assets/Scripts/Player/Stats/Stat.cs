using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat{
    
    [SerializeField]
    private int baseStatValue;

    public int GetValue()
    {
        return baseStatValue;
    }



}
