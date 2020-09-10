using UnityEditor;
using UnityEngine;

public class StageZoneParams
{
    public float[] xBorder { get; private set; }
    public float[] yBorder { get; private set; }
    public float[] zBorder { get; private set; }

    public StageZoneParams(float x1,float x2, float y1, float y2, float z1, float z2)
    {
        xBorder =new float[] { x1, x2 };
        yBorder = new float[] { y1, y2 };
        zBorder = new float[] { z1, z2 };
    }
}

[RequireComponent(typeof(StageZone))]
public class StageZoneInformer : MonoBehaviour
{
    private StageZone stageZone;

    [SerializeField] private GameObject cameraPoint;
    [SerializeField] private GameObject cameraArm;

    private CameraParams defaultCamParams;

    [Range(0.5f, 2)]
    [SerializeField] private float distance = 1f;

    [Range(0.5f, 2)]
    [SerializeField] private float minimalDistance = 0.5f;

    [Range(0.5f, 2)]
    [SerializeField] private float maxDistance = 2f;

    [Range(0, 90)]
    [SerializeField] private float topAngle = 0f;

    [Range(-90, 0)]
    [SerializeField] private float bottomAngle = 0f;

    [SerializeField] private bool freeAspect;

    [Range(-180, 0)]
    [SerializeField] private float leftAngle = 0f;

    [Range(0, 180)]
    [SerializeField] private float rightAngle = 0f;

    private void Awake()
    {
        stageZone = GetComponent<StageZone>();
    }
    private void Start()
    {
        defaultCamParams = new CameraParams(cameraArm.transform.position,
                                            cameraArm.transform.eulerAngles,
                                            cameraPoint.transform.localPosition * RecountScale());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("My real scale: " + RecountScale());
        }
    }
    public CameraParams GetDefaultCamParams()
    {
        return defaultCamParams;
    }

    public StageZoneParams GetStageZoneParams()
    {
        StageZoneParams returnParams = new StageZoneParams(leftAngle, rightAngle, bottomAngle, topAngle, minimalDistance, maxDistance);
        if (freeAspect)
            returnParams= new StageZoneParams(-360, 360, bottomAngle, topAngle, minimalDistance, maxDistance);
        return returnParams;
    }

    public float RecountScale()
    {
        if (stageZone.GetParent() == null)
        {
            return cameraArm.transform.localScale.x;
        }
        else
        {
            return cameraArm.transform.localScale.x * stageZone.GetParent().szInformer.RecountScale();
        }
    }

    private void OnValidate()
    {
        cameraPoint.transform.localPosition = new Vector3(0, 0, -1 * distance);
    }

    private void OnDrawGizmosSelected()
    {

        ///Handles.DrawWireArc add to project
        //Connect camera arm and camera point
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(cameraArm.transform.position, cameraPoint.transform.position);

        //Point sphere
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(cameraPoint.transform.position, 0.1f);
        Gizmos.DrawWireSphere(cameraPoint.transform.position, 0.11f);

        //Point minDistance
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(cameraArm.transform.position, Vector3.up, minimalDistance);

        //Point minDistance
        Handles.color = Color.red;
        Handles.DrawWireDisc(cameraArm.transform.position, Vector3.up, maxDistance);

        if (maxDistance > minimalDistance
            && maxDistance >= (-1) * cameraPoint.transform.localPosition.z * cameraArm.transform.localScale.x
            && minimalDistance <= (-1) * cameraPoint.transform.localPosition.z * cameraArm.transform.localScale.x)
        {
            Handles.color = new Color(0.09f, 0.58f, 0, 0.1f);
        }
        else
        {
            Handles.color = new Color(1, 0, 0, 0.1f);
        }
        Handles.DrawSolidDisc(cameraArm.transform.position, Vector3.up, maxDistance);


        //Draw angles
        Vector3 vect = new Vector3(0, 0, -distance);
        Handles.color = Color.cyan;

        Handles.DrawWireArc(cameraArm.transform.position, Vector3.right, vect, topAngle, (-1) * cameraPoint.transform.localPosition.z * cameraArm.transform.localScale.x);
        Handles.DrawWireArc(cameraArm.transform.position, Vector3.right, vect, topAngle, (-1) * cameraPoint.transform.localPosition.z * cameraArm.transform.localScale.x + 0.01f);

        Handles.DrawWireArc(cameraArm.transform.position, Vector3.right, vect, bottomAngle, (-1) * cameraPoint.transform.localPosition.z * cameraArm.transform.localScale.x);
        Handles.DrawWireArc(cameraArm.transform.position, Vector3.right, vect, bottomAngle, (-1) * cameraPoint.transform.localPosition.z * cameraArm.transform.localScale.x + 0.01f);

        Handles.DrawWireArc(cameraArm.transform.position, Vector3.up, vect, (-1) * leftAngle, (-1) * cameraPoint.transform.localPosition.z * cameraArm.transform.localScale.x);
        Handles.DrawWireArc(cameraArm.transform.position, Vector3.up, vect, (-1) * leftAngle, (-1) * cameraPoint.transform.localPosition.z * cameraArm.transform.localScale.x + 0.01f);

        Handles.DrawWireArc(cameraArm.transform.position, Vector3.up, vect, (-1) * rightAngle, (-1) * cameraPoint.transform.localPosition.z * cameraArm.transform.localScale.x);
        Handles.DrawWireArc(cameraArm.transform.position, Vector3.up, vect, (-1) * rightAngle, (-1) * cameraPoint.transform.localPosition.z * cameraArm.transform.localScale.x + 0.01f);
    }
}
