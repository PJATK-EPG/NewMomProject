﻿using UnityEngine;

#if (UNITY_EDITOR)
using UnityEditor;
#endif
public class MeshButtonInformer : MonoBehaviour
{
#if (UNITY_EDITOR)
    [SerializeField] private Transform endPoint;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,1,1,0.1f);
        Handles.color = Color.white;
        Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
        Handles.DrawWireDisc(transform.position, transform.right, 0.2f);
        Handles.zTest = UnityEngine.Rendering.CompareFunction.GreaterEqual;
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(endPoint.position, transform.right, 0.2f);
        //gizmos.drawline(gameobject.transform.right + new vector3(0, 0, 0.25f), gameobject.transform.right + new vector3(0, 0, -0.25f));
        //gizmos.drawline(gameobject.transform.position + new vector3(0, 0.1f, 0.25f), gameobject.transform.position + new vector3(0, 0.1f, -0.25f));
        //gizmos.drawline(gameobject.transform.position + new vector3(0, -0.1f, 0.25f), gameobject.transform.position + new vector3(0, -0.1f, -0.25f));
    }
#endif
}
