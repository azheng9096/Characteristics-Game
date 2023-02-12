using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Upgrade", order = 1)]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public string description;
    public Sprite sprite;

    public virtual void Use() {
        Debug.Log("Using " + upgradeName);
    }

    public virtual void Remove() {
        Debug.Log("Removing the effects of a single instance of " + upgradeName);
    }
}
