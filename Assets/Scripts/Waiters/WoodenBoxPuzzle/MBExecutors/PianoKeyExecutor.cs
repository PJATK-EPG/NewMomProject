using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKeyExecutor : MBExecutor
{
    [SerializeField] private PianoNotes note;
    [SerializeField] private AudioClip clickSound;

    private AudioSource audioSource;
    private PianoKeyListener pianoKeyListener;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pianoKeyListener = PianoKeyListener.Instance;
    }
    public override void Execute()
    {
        audioSource.PlayOneShot(clickSound);
        pianoKeyListener.AddNote(note);
    }
}
