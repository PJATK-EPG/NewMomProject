using System.Collections;
using UnityEngine;

public class MeshButton : MonoBehaviour, ISelectable
{
    [SerializeField] private bool shouldReturn;

    [SerializeField] private AudioClip clickSound;

    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    private MeshRenderer renderer;
    private MBAnimator mbAnimator;
    private Activator activator;
    private AudioSource audioSource;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        activator = GetComponent<Activator>();
        mbAnimator = GetComponent<MBAnimator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void OnSelected()
    {
        if(Options.Instance.shouldRenderSelectedObj)
            renderer.material = selectedMaterial;
        if (Input.GetMouseButtonDown(0) && activator.isActivated())
        {
            
            if (shouldReturn)
            {
                audioSource.PlayOneShot(clickSound);
                mbAnimator.MoveWithReturn();
            }
            else
            {
                audioSource.PlayOneShot(clickSound);
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
