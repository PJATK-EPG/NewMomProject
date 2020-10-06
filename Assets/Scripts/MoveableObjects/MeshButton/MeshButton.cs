using System.Collections;
using UnityEngine;

public class MeshButton : MonoBehaviour, ISelectable
{
    [SerializeField] private bool shouldReturn;

    [SerializeField] private AudioClip clickSound;

    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    private bool isActivated;

    private MeshRenderer renderer;
    private MBAnimator mbAnimator;
    private AudioSource audioSource;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        mbAnimator = GetComponent<MBAnimator>();
        audioSource = GetComponent<AudioSource>();

        Activate();
    }

    public void Activate() => isActivated = true;

    public void Disactivate() => isActivated = false;


    public void OnSelected()
    {
        if(Options.Instance.shouldRenderSelectedObj)
            renderer.material = selectedMaterial;
        if (Input.GetMouseButtonDown(0) && isActivated)
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
            }
           
        }
    }
    public void OnDeselected()
    {
        renderer.material = defaultMaterial;
    }
}
