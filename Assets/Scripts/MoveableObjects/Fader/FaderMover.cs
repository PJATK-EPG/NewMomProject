using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderMover : MonoBehaviour, ISelectable
{
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    [SerializeField] private Transform minPoint;
    [SerializeField] private Transform pivotPoint;
    [SerializeField] private Transform maxPoint;

    [SerializeField] private float movingSpeed = 2;

    private Vector3 wantedValue;
    private bool canMove;

    private MeshRenderer renderer;
    private Activator activator;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        activator = GetComponent<Activator>();
        wantedValue = transform.position;
    }

    public void OnSelected()
    {
        if(Options.Instance.shouldRenderSelectedObj)
            renderer.material = selectedMaterial;
        if (Input.GetMouseButtonDown(0))
        {
            canMove = true;
        }
    }
    public void OnDeselected()
    {
        renderer.material = defaultMaterial;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && canMove)
        {

            Vector2 cursourPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);

            Vector3 centerPoint = new Vector3((minPoint.position.x + maxPoint.position.x) / 2,
                                              (minPoint.position.y + maxPoint.position.y) / 2,
                                              (minPoint.position.z + maxPoint.position.z) / 2);
            Vector2 centerScreenPoint = Camera.main.WorldToScreenPoint(centerPoint);

            Vector2 maxVectorPoint = Camera.main.WorldToScreenPoint(maxPoint.position);

            float cosValue = Mathf.Cos(Mathf.Deg2Rad * Vector2.Angle(maxVectorPoint - centerScreenPoint, 
                                                                    cursourPoint - centerScreenPoint));

            Vector3 maxPointVector = maxPoint.position - centerPoint;
            Vector3 finalVector = (maxPointVector * cosValue) + centerPoint;

            wantedValue = finalVector;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }
        if (activator.isActivated() && canMove)
        {
            transform.position = Vector3.Lerp(transform.position, wantedValue, movingSpeed * Time.deltaTime);
        }
    }


}

