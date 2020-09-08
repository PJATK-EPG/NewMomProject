using UnityEngine;

public class CameraParams
{
    public Vector3 armPosition;
    public Vector3 armRotation;
    public Vector3 cameraPosition;

    public CameraParams(Vector3 armPosition, Vector3 armRotation, Vector3 cameraPosition)
    {
        this.armPosition = armPosition;
        this.armRotation = armRotation;
        this.cameraPosition = cameraPosition;
    }
}