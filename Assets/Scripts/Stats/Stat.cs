using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Stat 
{
    [SerializeField]
    private int baseValue;

    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }


    public void AddModifier (int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }


    public void RemoveModifier (int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }

    // Use multipliers for power ups
    public void AddMultiplier(int multiplier)
    {
        if (multiplier != 0)
        {
            baseValue *= multiplier;
        }
    }

    // use multipliers for power ups
    public void RemoveMultiplier(int multiplier)
    {
        if (multiplier != 0)
        {
            baseValue /= multiplier;
        }
    }

}
