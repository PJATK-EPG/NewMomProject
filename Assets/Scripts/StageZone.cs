using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageZone : MonoBehaviour, ISelectable
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;

    private MeshRenderer renderer;
    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    public void OnSelected()
    {
        renderer.material = selectedMaterial;
    }
    public void OnDeselected()
    {
        renderer.material = defaultMaterial;
    }

}
