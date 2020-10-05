using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderMover : MonoBehaviour, ISelectable
{
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    [SerializeField] private Transform minPoint;
    [SerializeField] private Transform centerPoint;
    [SerializeField] private Transform maxPoint;

    [SerializeField] private float movingSpeed;



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
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = gameObject.transform.position  - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        canMove = true;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && canMove)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            //curPosition = new Vector3(minValue.x,
            //                        Mathf.Clamp(curPosition.y, minValue.y, maxValue.y),
            //                        minValue.z);


            //Vector3 nearestPoint = FindNearestPointOnLine(curPosition , minPoint.position, maxPoint.position);
            transform.position = Vector3.Lerp(transform.position, curPosition, 7 * Time.deltaTime);



            //    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            //    Vector3 cursorVector = curScreenPoint;
            //    Vector3 headVector = Camera.main.WorldToScreenPoint(transform.position + centerPoint.localPosition);

            //    float velocity = cursorVector.y - headVector.y;

            //    if (velocity > 0)
            //    {
            //            transform.position = Vector3.Lerp(transform.position, minPoint.position, movingSpeed * Time.deltaTime);
            //    }
            //    else
            //    {
            //            transform.position = Vector3.Lerp(transform.position , maxPoint.position, movingSpeed * Time.deltaTime);
            //    }
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }

    }

        public Vector3 FindNearestPointOnLine(Vector3 origin, Vector3 minPoint, Vector3 maxPoint)
    {
        Vector3 p1 = minPoint;
        Vector3 p2 = maxPoint;
        Vector3 q = origin;

        Vector3 u = p2 - p1;
        Vector3 pq = q - p1;

        //Vector3 w1 = new Vector3 
        Vector3 w2 = pq - u * Vector3.Dot(pq, u)  / u.sqrMagnitude;

        
        Vector3 point = q - w2;
        return point;
    }
}

