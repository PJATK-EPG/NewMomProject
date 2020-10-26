using UnityEngine;

public class FPController : PlayerState
{
    public static FPController Instance { get; private set; }

    public GameObject centerPoint;
    public GameObject vignette;
    public GameObject backButton;
    public GameObject diaryButton;
    public GameObject inventoryButton;

    [SerializeField] private SelectionManager selectionManager;

    private void Awake()
    {
        Instance = this;
    }
 
    public override void Lock() => this.isActive = false;
    public override void Unlock()
    {
        this.isActive = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        centerPoint.SetActive(true);
        vignette.SetActive(false);
        backButton.SetActive(false);
        diaryButton.SetActive(false);
        inventoryButton.SetActive(false);

        selectionManager.SetState(PlayerStateType.FirstPerson);
    }
}