using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshButton : MonoBehaviour, ISelectable
{
    [SerializeField] private bool shouldReturn;

    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;
    

    private MeshRenderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        animator = GetComponent<Animator>();
    }

    public void OnSelected()
    {
        renderer.material = selectedMaterial;
        if (Input.GetMouseButtonDown(0))
        {
            if (shouldReturn)
            {
                StartCoroutine(AnimateReturnClick(0.75f));
            }
            else
            {
                animator.SetTrigger("RegularClick");
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
