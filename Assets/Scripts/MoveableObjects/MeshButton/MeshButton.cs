using System.Collections;
using UnityEngine;

public class MeshButton : MonoBehaviour, ISelectable
{
    [SerializeField] private bool shouldReturn;

    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    [SerializeField] private SimpleWaiter waiter;

    private bool isActivated;

    private MeshRenderer renderer;
    private MBAnimator mbAnimator;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        mbAnimator = GetComponent<MBAnimator>();
        animator = GetComponent<Animator>();

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
                //StartCoroutine(AnimateReturnClick(0.75f));
            }
            else
            {
                mbAnimator.MoveBack();
                //animator.SetTrigger("RegularClick");
                //waiter.Finish();
            }
           
        }
    }
    public void OnDeselected()
    {
        renderer.material = defaultMaterial;
    }

    private IEnumerator AnimateReturnClick(float animationLength)
    {
        animator.SetTrigger("ReturnClick");

       yield return new WaitForSeconds(animationLength);

        animator.ResetTrigger("ReturnClick");
    }

}
