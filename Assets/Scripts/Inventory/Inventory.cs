using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    [SerializeField] private List<ItemObject> container = new List<ItemObject>();

    private void Awake() => Instance = this;

    public void AddObjectToInventory(ItemObject itemObject)
    {
        container.Add(itemObject);
    }

    public List<ItemObject> GetAllObjects()
    {
        return container;
    }
}
