using System.Collections;
using UnityEngine;

public class MeshButton : MonoBehaviour, ISelectable
{
    [SerializeField] private bool shouldReturn;

    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    private MeshRenderer renderer;
    private MBAnimator mbAnimator;
    private Activator activator;
    private MBExecutor mbExecutor;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        activator = GetComponent<Activator>();
        mbAnimator = GetComponent<MBAnimator>();
        mbExecutor = GetComponent<MBExecutor>();
    }
    public void OnSelected()
    {
        if(Options.Instance.shouldRenderSelectedObj)
            renderer.material = selectedMaterial;
        if (Input.GetMouseButtonDown(0) && activator.isActivated())
        {
            
            if (shouldReturn)
            {
                mbExecutor.Execute();
                mbAnimator.MoveWithReturn();
            }
            else
            {
                mbExecutor.Execute();
                mbAnimator.MoveBack();
                activator.DisactivateThisObj();
            }
           
        }
    }
    public void OnDeselected()
    {
        renderer.material = defaultMaterial;
    }
}
