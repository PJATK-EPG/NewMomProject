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

    private float animationAccuracy = 0.125f;

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
           if ((Vector3.Distance(cameraArm.transform.position, armPosition) > animationAccuracy)
           || (Vector3.Distance(additionalCamera.transform.localPosition, cameraPosition) > animationAccuracy))
            {
                cameraArm.transform.position = Vector3.MoveTowards(cameraArm.transform.position, armPosition, armStep * Time.deltaTime);
                additionalCamera.transform.localPosition = Vector3.MoveTowards(additionalCamera.transform.localPosition, cameraPosition, cameraStep * Time.deltaTime);
                if (Options.Instance.shouldUseDefPoints)
                    cameraArm.transform.rotation = Quaternion.Lerp(cameraArm.transform.rotation, armAngleRotation, armRotateStep * Time.deltaTime);
            }
            else
            {
                cameraArm.transform.position = armPosition;
                additionalCamera.transform.localPosition = cameraPosition;
                if (Options.Instance.shouldUseDefPoints)
                    cameraArm.transform.rotation = armAngleRotation;

                szState.Unlock();
                canAnimateToSZ = false;
            }
        }
    }

    public void SwitchToFP()
    {
        mainCamera.SetActive(false);
        additionalCamera.SetActive(false);
        canAnimateToSZ = true;
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
    }

    public void RestartAdditionalCamera()
    {
        cameraArm.transform.position = mainCamera.transform.position ;
        cameraArm.transform.rotation = mainCamera.transform.rotation;
        additionalCamera.transform.localPosition = Vector3.zero;//от нуля и обратно
    }
}
