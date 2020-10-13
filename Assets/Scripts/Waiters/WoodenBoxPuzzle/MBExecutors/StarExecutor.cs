using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarExecutor : MBExecutor
{
    [SerializeField] private AudioClip clickSound;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void Execute()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
