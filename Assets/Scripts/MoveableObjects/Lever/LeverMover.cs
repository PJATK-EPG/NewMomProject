using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMover : MonoBehaviour, ISelectable
{
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    [SerializeField] private Transform centerPoint;


    [SerializeField] private float minAngleValue;
    [SerializeField] private float maxAngleValue;
    private float midValue;

    private MeshRenderer renderer;

    private float leverBackSpeed = 6;

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool canMove;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        midValue = maxAngleValue / 2;
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
        if (!Input.GetMouseButton(0))
        {
            AnimateBackMovement();
        }
        if (Input.GetMouseButton(0) && canMove)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorVector = curScreenPoint;
            Vector3 headVector = Camera.main.WorldToScreenPoint(gameObject.transform.position);
           
            float velocity = cursorVector.y - headVector.y;
            float yAngle = centerPoint.localEulerAngles.y;
            yAngle = (yAngle > 200) ? yAngle - 360 : yAngle;

            if(velocity <0 && yAngle < maxAngleValue || velocity > 0 && yAngle > minAngleValue)
                centerPoint.RotateAround(centerPoint.position, centerPoint.up, (-1)* velocity * Time.deltaTime);
            
        }else if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }
    }

    public void AnimateBackMovement()
    {
        float yAngle = centerPoint.localEulerAngles.y;
        yAngle = (yAngle > 200) ? yAngle - 360 : yAngle;
        if (yAngle <= midValue)
        {
            if (Quaternion.Angle(centerPoint.transform.localRotation, Quaternion.Euler(0, minAngleValue, 0)) > 0.1f)
            {
                centerPoint.transform.localRotation = Quaternion.Lerp(centerPoint.transform.localRotation, Quaternion.Euler(0, minAngleValue, 0), leverBackSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Quaternion.Angle(centerPoint.transform.localRotation, Quaternion.Euler(0, maxAngleValue, 0)) > 0.1f)
            {
                centerPoint.transform.localRotation = Quaternion.Lerp(centerPoint.transform.localRotation, Quaternion.Euler(0, maxAngleValue, 0), leverBackSpeed * Time.deltaTime);
            }
        }
    }
   
}
