using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAtTarget : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.transform.position;
    }
}
