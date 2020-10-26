using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject parentObject;

    
    private List<SlotItem> currentSlotItems = new List<SlotItem>();
    private Inventory inventory;
    private SZController szController;

    private void Start()
    {
        inventory = Inventory.Instance;
        szController = SZController.Instance;
    }
    public void OnActivated()
    {
        gameObject.SetActive(true);
        GenerateSlotItems();
    }

    public void GenerateSlotItems()
    {
        foreach(ItemObject itemObject in inventory.GetAllObjects())
        {
            SlotItem relatedSlotItem = itemObject.slotItem;
            if (!currentSlotItems.Contains(relatedSlotItem))
            {
                AddSlotItem(relatedSlotItem);
            }
        }
    }

    public void AddSlotItem(SlotItem slotItem)
    {
        slotItem.transform.SetParent(parentObject.transform);
        currentSlotItems.Add(slotItem);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        szController.Pause();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        szController.Unpause();
    }

}
