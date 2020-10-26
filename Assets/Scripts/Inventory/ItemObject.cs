using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Small,
    Medium,
    Large
}

[CreateAssetMenu(fileName ="New Item Object", menuName ="Inventory System/ItemObject")]
public class ItemObject : ScriptableObject
{
    public SlotItem slotItem;
    public ItemType type;
    [TextArea]
    public string description;
}
