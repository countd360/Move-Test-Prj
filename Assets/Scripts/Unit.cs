using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string Name { private set; get; }        // ENCAPSULATION

    public virtual void GoTo(Vector3 dstPosition)   // ABSTRACTION
    {
        // teleport!
        transform.position = dstPosition;
    }

}
