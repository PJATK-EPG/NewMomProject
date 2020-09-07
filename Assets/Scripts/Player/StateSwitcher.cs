using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwitcher : MonoBehaviour
{
    public static StateSwitcher Instance { get; private set; }

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject cameraArm;
    [SerializeField] private GameObject additionalCamera;

    private FPSController fpsState;
    private SZController szState;

    private bool canAnimateToFS;
    private bool canAnimateToSZ;

    private Vector3 armPosition;
    private Quaternion armAngleRotation;
    private Vector3 cameraPosition;

    private float armStep = 2f;
    private float armRotateStep = 2f;
    private float cameraStep = 2f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fpsState = FPSController.Instance;
        szState = SZController.Instance;
    }
    private void Update()
    {
        if (canAnimateToFS)
        {

        }
        else if (canAnimateToSZ)
        {
           if ((Vector3.Distance(cameraArm.transform.position, armPosition) > 0.5f)
           || (Quaternion.Angle(cameraArm.transform.rotation, armAngleRotation) > 0.5f)
          // || (Quaternion.Angle(additionalCamera.transform.rotation, Quaternion.Euler(0,180,0)) > 0.5f)
           || (Vector3.Distance(additionalCamera.transform.localPosition, cameraPosition) > 0.5f))
            {
                cameraArm.transform.position = Vector3.MoveTowards(cameraArm.transform.position, armPosition, armStep * Time.deltaTime);
                cameraArm.transform.rotation = Quaternion.Lerp(cameraArm.transform.rotation, armAngleRotation, armRotateStep * Time.deltaTime);
                //additionalCamera.transform.rotation = Quaternion.Lerp(additionalCamera.transform.rotation, Quaternion.Euler(0, 180, 0), armRotateStep * Time.deltaTime);
                additionalCamera.transform.localPosition = Vector3.MoveTowards(additionalCamera.transform.localPosition, cameraPosition, cameraStep * Time.deltaTime);
            }
            else
            {
                cameraArm.transform.position = armPosition;
                cameraArm.transform.rotation = armAngleRotation;
                additionalCamera.transform.localPosition = cameraPosition;
                canAnimateToSZ = false;
                Debug.Log("Finished");
            }
        }
    }

    public void SwitchToFP()
    {
        mainCamera.SetActive(false);
        additionalCamera.SetActive(false);
        canAnimateToSZ = true;
        //fpsState.Unlock();
    }

    public void SwitchToSZ(StageZone aimStageZone)
    {
        CameraParams camParams = aimStageZone.GetCamParams();
        armPosition = camParams.armPosition;
        armAngleRotation = Quaternion.Euler(camParams.armRotation);
        cameraPosition = camParams.cameraPosition;

        RestartAdditionalCamera();

        mainCamera.SetActive(false);
        additionalCamera.SetActive(true);

        canAnimateToSZ = true;
        //szState.Unlock();
    }

    public void RestartAdditionalCamera()
    {
        cameraArm.transform.position = mainCamera.transform.position ;
        cameraArm.transform.rotation = mainCamera.transform.rotation;
        additionalCamera.transform.localPosition = Vector3.zero;//от нуля и обратно
    }
}
