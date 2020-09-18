using UnityEngine;

#if (UNITY_EDITOR)
using UnityEditor;
#endif
public class MeshButtonInformer : MonoBehaviour
{
#if (UNITY_EDITOR)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(gameObject.transform.position + new Vector3(0, 0, 0.25f), gameObject.transform.position + new Vector3(0, 0, -0.25f));
        Gizmos.DrawLine(gameObject.transform.position + new Vector3(0, 0.1f, 0.25f), gameObject.transform.position + new Vector3(0, 0.1f, -0.25f));
        Gizmos.DrawLine(gameObject.transform.position + new Vector3(0, -0.1f, 0.25f), gameObject.transform.position + new Vector3(0, -0.1f, -0.25f));
    }
#endif
}
