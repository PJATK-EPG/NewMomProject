using UnityEngine;
public enum SwitchAnimType
{
    FP_TO_SZ,
    SZ_TO_FP,
    SZ_TO_SZ_DOWN,
    SZ_TO_SZ_UP
}
public class StateSwitcher : MonoBehaviour
{
    public static StateSwitcher Instance { get; private set; }

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject cameraArm;
    [SerializeField] private GameObject additionalCamera;

    private FPController fpsState;
    private SZController szState;

    private bool canAnimate;
    private SwitchAnimType animType;
    private bool shouldAnimateCamRotation;

    private Vector3 armPosition;
    private Quaternion armAngleRotation;
    private Vector3 cameraPosition;

    private float armStep = 2.5f;
    private float armRotateStep = 2.5f;
    private float cameraStep = 2.5f;

    private float animationAccuracy = 0.125f;
    private float relativeAnimSpeed;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fpsState = FPController.Instance;
        szState = SZController.Instance;
    }
    private void FixedUpdate()
    {
        if (canAnimate)
        {
            if ((Vector3.Distance(cameraArm.transform.position, armPosition) > animationAccuracy)
           || (Vector3.Distance(additionalCamera.transform.localPosition, cameraPosition) > animationAccuracy)
           || (shouldAnimateCamRotation && (Quaternion.Angle(cameraArm.transform.rotation, armAngleRotation) > animationAccuracy)))
            {
                cameraArm.transform.position = Vector3.MoveTowards(cameraArm.transform.position, armPosition, armStep * relativeAnimSpeed * Time.deltaTime);
                additionalCamera.transform.localPosition = Vector3.MoveTowards(additionalCamera.transform.localPosition, cameraPosition, cameraStep * relativeAnimSpeed * Time.deltaTime);
                if(shouldAnimateCamRotation)
                    cameraArm.transform.rotation = Quaternion.Lerp(cameraArm.transform.rotation, armAngleRotation, armRotateStep * relativeAnimSpeed * Time.deltaTime);
            }
            else
            {
                ChoseEndOfAnimation();
            }
        }
    }

    public void MakeSwitchingAnimation(SwitchAnimType animType, CameraParams aimParams)
    {
        this.animType = animType;

        armPosition = aimParams.armPosition;
        armAngleRotation = Quaternion.Euler(aimParams.armRotation);
        cameraPosition = aimParams.cameraPosition;

        shouldAnimateCamRotation =  (animType == SwitchAnimType.FP_TO_SZ || animType == SwitchAnimType.SZ_TO_SZ_DOWN)
                                ? Options.Instance.shouldUseDefPoints
                                : true;

        if(animType == SwitchAnimType.FP_TO_SZ)
        {
            mainCamera.SetActive(false);
            additionalCamera.SetActive(true);
            RestartAdditionalCamera();
        }

        RecountRelativeAnimSpeed();

        canAnimate = true;
    }

    public void ChoseEndOfAnimation()
    {
        cameraArm.transform.position = armPosition;
        additionalCamera.transform.localPosition = cameraPosition;
        if (shouldAnimateCamRotation)
            cameraArm.transform.rotation = armAngleRotation;

        if (animType == SwitchAnimType.SZ_TO_FP)
        {
            mainCamera.SetActive(true);
            additionalCamera.SetActive(false);

            fpsState.Unlock();
        }
        else 
        {
            szState.Unlock();
        }

        canAnimate = false;
    }

    public void RecountRelativeAnimSpeed()
    {
        relativeAnimSpeed = Vector3.Distance(cameraArm.transform.position, armPosition)/2;
    }
    public void RestartAdditionalCamera()
    {
        cameraArm.transform.position = mainCamera.transform.position;
        cameraArm.transform.rotation = mainCamera.transform.rotation;
        additionalCamera.transform.localPosition = Vector3.zero;
    }

    public CameraParams GetFPCamParams()
    {
        return new CameraParams(mainCamera.transform.position, mainCamera.transform.eulerAngles, Vector3.zero);
    }
}
