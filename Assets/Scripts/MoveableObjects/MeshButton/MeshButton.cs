using System.Collections;
using UnityEngine;

public class MeshButton : MonoBehaviour, ISelectable
{
    [SerializeField] private bool shouldReturn;

    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    private bool isActivated;

    private MeshRenderer renderer;
    private MBAnimator mbAnimator;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        mbAnimator = GetComponent<MBAnimator>();

        Activate();
    }

    public void Activate() => isActivated = true;

    public void Disactivate() => isActivated = false;


    public void OnSelected()
    {
        renderer.material = selectedMaterial;
        if (Input.GetMouseButtonDown(0) && isActivated)
        {
            
            if (shouldReturn)
            {
                mbAnimator.MoveWithReturn();
            }
            else
            {
                mbAnimator.MoveBack();
            }
           
        }
    }
    public void OnDeselected()
    {
        renderer.material = defaultMaterial;
    }
}
