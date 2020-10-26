using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private InventoryPanel inventoryPanel;
    private SZController szController;

    private bool isActive;
    private void Start()
    {
        szController = SZController.Instance;

        GetComponent<Button>().onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        isActive = !isActive;
        if (isActive)
        {
            inventoryPanel.OnActivated();
        }
        else
        {
            inventoryPanel.gameObject.SetActive(false);
        }
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
