using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NarrativeManager : MonoBehaviour
{
    public static NarrativeManager instance; 

    public UnityEvent PreviousInteraction;
    public UnityEvent PostInteraction;

    public UnityEvent<string> TriggerAction;

    private void Awake()
    {
        if(instance == null || instance != this)
        {
            instance = this;
        }
    }

    public void OnPrepairForInteraction()
    {
        if(PreviousInteraction != null)
        {
            instance.PreviousInteraction.Invoke();
        }
    }
    public void OnPostInteraction()
    {
        if (PostInteraction != null)
        {
            instance.PostInteraction.Invoke();
        }
    }
}
