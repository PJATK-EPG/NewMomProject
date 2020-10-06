#if (UNITY_EDITOR)
using UnityEditor;
#endif
using UnityEngine;

public class FaderInformer : MonoBehaviour
{
    [SerializeField] private bool shouldRender;
    [SerializeField] private Transform minPoint;
    [SerializeField] private Transform pivotPoint;
    [SerializeField] private Transform maxPoint;

    private void OnDrawGizmos()
    {
        if (shouldRender) 
        {
            Gizmos.DrawLine(minPoint.position, maxPoint.position);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(minPoint.position, 0.01f);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(pivotPoint.position, 0.03f);
            Gizmos.DrawWireSphere(pivotPoint.position, 0.031f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(maxPoint.position, 0.01f);
        }
    } 
}
