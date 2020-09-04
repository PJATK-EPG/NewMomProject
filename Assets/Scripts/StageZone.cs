using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageZone : MonoBehaviour, ISelectable
{
    [SerializeField] private StageZone parent;
    [SerializeField] private List<StageZone> children;

    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material redMaterial;

    private MeshRenderer renderer;
    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = Options.Instance.shouldRenderStageZones;
    }
    public void OnSelected()
    {
        renderer.material = selectedMaterial;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("!@@!");
            renderer.material = redMaterial;
        }
    }
    public void OnDeselected()
    {
        renderer.material = defaultMaterial;
    }

}
