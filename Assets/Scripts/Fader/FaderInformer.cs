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

    [Range(-0.5f, 0.5f)]
    [SerializeField] private float buttonStartPosotion;

    [Range(0, 0.5f)]
    [SerializeField] private float maxValue;

    [Range(-0.5f, 0)]
    [SerializeField] private float minValue;

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
