using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageZone : MonoBehaviour, ISelectable
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material redMaterial;

    private MeshRenderer renderer;
    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    public void OnSelected()
    {
        renderer.material = selectedMaterial;
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            renderer.material = redMaterial;
        }
    }
    public void OnDeselected()
    {
        renderer.material = defaultMaterial;
    }

}
