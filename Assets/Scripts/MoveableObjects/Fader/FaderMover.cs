using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderMover : MonoBehaviour, ISelectable
{
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    private MeshRenderer renderer;

    private Vector3 maxValue;
    private Vector3 minValue;

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool canMove;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void SetBorders(Vector3 minValue, Vector3 maxValue)
    {
        this.maxValue = maxValue;
        this.minValue = minValue;
    }

    public void OnSelected()
    {
        renderer.material = selectedMaterial;
        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        }
    }
    public void OnDeselected()
    {
        renderer.material = defaultMaterial;
    }

    void MouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        canMove = true;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && canMove)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            curPosition = new Vector3(minValue.x, Mathf.Clamp(curPosition.y, minValue.y, maxValue.y), minValue.z);
            transform.position = Vector3.Lerp(transform.position, curPosition, 7*Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }

    }
}

