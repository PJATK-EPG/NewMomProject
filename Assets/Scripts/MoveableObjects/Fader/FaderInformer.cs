#if (UNITY_EDITOR)
using UnityEditor;
#endif
using UnityEngine;

public enum FaderStates
{
    FaderMin,
    FaderMax
}

public class FaderInformer : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private GameObject button;
    [SerializeField] private FaderMover mover;

    [Range(-0.5f, 0.5f)]
    [SerializeField] private float buttonStartPosotion;

    [Range(0, 0.5f)]
    [SerializeField] private float maxValue;

    [Range(-0.5f, 0)]
    [SerializeField] private float minValue;

    [HideInInspector] public float realMaxValue { get { return center.position.y + maxValue; } }
    [HideInInspector] public float realMinValue { get { return center.position.y + minValue; } }



    private void Start()
    {
        mover.SetBorders(center.position + new Vector3(0, minValue, 0), center.position + new Vector3(0, maxValue, 0));
    }

#if (UNITY_EDITOR)
    private void OnValidate()
    {
        button.transform.localPosition = new Vector3(0, buttonStartPosotion, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(center.position + new Vector3(0, maxValue, 0), 0.05f);
        Gizmos.DrawWireSphere(center.position + new Vector3(0, maxValue, 0), 0.06f);

        Gizmos.DrawWireSphere(center.position + new Vector3(0, minValue, 0), 0.05f);
        Gizmos.DrawWireSphere(center.position + new Vector3(0, minValue, 0), 0.06f);

        Gizmos.DrawLine(center.position + new Vector3(0, minValue, 0), center.position + new Vector3(0, maxValue, 0));
    }
#endif
}
