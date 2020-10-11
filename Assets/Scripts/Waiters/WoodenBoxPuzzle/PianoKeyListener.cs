using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PianoNotes
{
    DO,
    RE,
    MI,
    FA,
    SOL,
    LA,
    SI,
    ANOTHER
}
public class PianoKeyListener : MonoBehaviour
{
    public static PianoKeyListener Instance { get; private set; }

    private Queue<PianoNotes> playedNotes = new Queue<PianoNotes>();

    private void Awake()
    {
        Instance = this;
    }
    
    public void AddNote(PianoNotes note)
    {
        playedNotes.Enqueue(note);

        if (playedNotes.Count > 3)
        {
            playedNotes.Dequeue();
        }

        if(playedNotes.Count == 3)
        {
            CheckSequence();
        }
    }

    private void CheckSequence()
    {
        PianoNotes[] lastPlayedNotes = playedNotes.ToArray();
        if(lastPlayedNotes[0] == PianoNotes.MI && lastPlayedNotes[0] == PianoNotes.SOL && lastPlayedNotes[0] == PianoNotes.SI)
        {
            Debug.Log("Activated!!!!");
        }
    }
}
