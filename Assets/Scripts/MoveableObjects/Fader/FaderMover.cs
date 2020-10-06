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

    [SerializeField] private float movingSpeed;



    private MeshRenderer renderer;

    private Vector3 maxValue;
    private Vector3 minValue;

    private Vector3 wantedValue;

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool canMove;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        wantedValue = transform.position;
    }

    public void SetBorders(Vector3 minValue, Vector3 maxValue)
    {
        this.maxValue = maxValue;
        this.minValue = minValue;
    }

    public void OnSelected()
    {
        if(Options.Instance.shouldRenderSelectedObj)
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

            Vector2 cursourPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);

            Vector3 cP = Camera.main.WorldToScreenPoint(new Vector3((minPoint.position.x + maxPoint.position.x) / 2,
                                              (minPoint.position.y + maxPoint.position.y) / 2,
                                              (minPoint.position.z + maxPoint.position.z) / 2));

            Vector2 cP2 = new Vector2(cP.x, cP.y);
            Vector3 maxVectorPoint = Camera.main.WorldToScreenPoint(maxPoint.position);
            Vector2 mVP = new Vector2(maxVectorPoint.x, maxVectorPoint.y);

            float cosValue = Mathf.Cos(Mathf.Deg2Rad * Vector2.Angle(mVP - cP2, cursourPoint - cP2));


            Vector3 centerPoint = new Vector3((minPoint.position.x + maxPoint.position.x) / 2,
                                              (minPoint.position.y + maxPoint.position.y) / 2,
                                              (minPoint.position.z + maxPoint.position.z) / 2);


            Vector3 vectA = maxPoint.position - centerPoint;
            Vector3 vectB = pivotPoint.position - centerPoint;

            Vector3 vectC = maxPoint.position - minPoint.position;

            Vector3 finalVector = vectA * cosValue;

            Vector3 maybeVector = (finalVector + centerPoint);

            //Gizmos.DrawLine(centerPoint, maxPoint.position);
            //Gizmos.DrawLine(centerPoint, pivotPoint.position);
            //Gizmos.color = Color.yellow;
            //Gizmos.DrawLine(centerPoint, maybeVector);

            wantedValue = maybeVector;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }
        if (canMove)
        {
            transform.position = Vector3.Lerp(transform.position, wantedValue, 2 * Time.deltaTime);
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

