using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New DEBUGER", menuName = "Inventory/Debug")]
public class Debuger : ScriptableObject
{
    public void Write()
    {
        Debug.Log("HellouWorld");
    }
}
