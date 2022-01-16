using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonUnit : Unit  // INHERITANCE
{
    public float speed = 3;
    public Animator farmerAnim;

    private Vector3 srcPos, dstPos;
    private float progress, distance, cSpd;
    private Coroutine curCoRoutine = null;

    void Awake()
    {
        name = "The Farmer";
    }

    public override void GoTo(Vector3 dstPosition)
    {
        srcPos = transform.position;
        dstPos = dstPosition;
        distance = (dstPos - srcPos).magnitude;
        progress = 0;

        transform.rotation = Quaternion.LookRotation(dstPos - srcPos);
        farmerAnim.SetFloat("Speed_f", 1f);

        if (curCoRoutine != null)
        {
            StopCoroutine(curCoRoutine);
            curCoRoutine = null;
        }
        else
        {
            cSpd = 0;
        }
        curCoRoutine = StartCoroutine(MoveTo());
    }

    protected IEnumerator MoveTo()  // POLYMORPHISM
    {
        while (progress < distance)
        {
            Vector3 tgtPos = Vector3.Lerp(srcPos, dstPos, progress / distance);
            transform.position = tgtPos;
            progress += Time.deltaTime * cSpd;
            if (cSpd < speed)
            {
                cSpd += speed * Time.deltaTime;
            }
            yield return null;
        }
        transform.position = dstPos;
        farmerAnim.SetFloat("Speed_f", 0f);
        curCoRoutine = null;
    }

}
