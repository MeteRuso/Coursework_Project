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

    public void AddValue(int Input)
    {
        baseStatValue += Input;
    }

    public void SetValue(int Input)
    {
        baseStatValue = Input;
    }

    public void AmpValue(int Input)
    {
        baseStatValue *= Input;
    }

}
