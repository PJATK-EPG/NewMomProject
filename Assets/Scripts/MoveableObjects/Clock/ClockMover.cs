using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMover : MonoBehaviour, ISelectable
{
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    [SerializeField] private Transform centerPoint;

    private MeshRenderer renderer;

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool canMove;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
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

            
            Vector3 cursorVector = (curScreenPoint - Camera.main.WorldToScreenPoint(centerPoint.position)).normalized;
            Vector3 clockVector = (Camera.main.WorldToScreenPoint(gameObject.transform.position) - Camera.main.WorldToScreenPoint(centerPoint.position)).normalized;
            float angle = TransformAngle(Vector3.SignedAngle(cursorVector, clockVector, Camera.main.WorldToScreenPoint(centerPoint.position)));

            Debug.Log(angle);
            float rotationVelocity = 3f;
            centerPoint.RotateAround(centerPoint.position, centerPoint.right, angle * rotationVelocity * Time.deltaTime );
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }

    }

    public float TransformAngle(float angle)
    {
        float returnAngle = 0;
        if (Mathf.Abs(angle) < 90)
        {
            returnAngle = angle;
        } 
        return returnAngle;
    }
}
