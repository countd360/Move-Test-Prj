using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string Name { protected set; get; }        // ENCAPSULATION

    void Awake()
    {
        Name = "Teleport Cone";
    }

    public virtual void GoTo(Vector3 dstPosition)   // ABSTRACTION
    {
        // teleport!
        transform.position = dstPosition;
    }

}
