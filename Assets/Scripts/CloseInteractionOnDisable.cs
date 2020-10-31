using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInteractionOnDisable : MonoBehaviour
{
    /// <summary>
    /// Se deberia desactivar al objeto 
    /// </summary>
    
    // Start is called before the first frame update
    void OnDisable()
    {
        NarrativeManager.instance.OnPostInteraction();
    }

}
