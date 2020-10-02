using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceSwitcher : MonoBehaviour
{
    [SerializeField] private Camera fromCamera;
    [SerializeField] private Camera toCamera;

    public void MakeSwith()
    {
        fromCamera.gameObject.SetActive(false);
        toCamera.gameObject.SetActive(true);
    }
}
