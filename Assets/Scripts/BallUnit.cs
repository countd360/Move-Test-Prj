using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUnit : Unit    // INHERITANCE
{
    public float speed = 10;

    private Vector3 offset;
    private Vector3 srcPos, dstPos;
    private float progress, distance;
    private IEnumerator moveRoutine = null;

    // Start is called before the first frame update
    void Awake()
    {
        Name = "Rolling Ball";
        offset = new Vector3(0, 0.5f, 0);
    }

    public override void GoTo(Vector3 dstPosition)
    {
        srcPos = transform.position;
        dstPos = dstPosition + offset;
        distance = (dstPos - srcPos).magnitude;
        progress = 0;

        if (moveRoutine != null)
        {
            StopCoroutine(moveRoutine);
        }
        moveRoutine = MoveTo();
        StartCoroutine(moveRoutine);
    }

    protected IEnumerator MoveTo()  // POLYMORPHISM
    {
        while (progress < distance)
        {
            Vector3 tgtPos = Vector3.Lerp(srcPos, dstPos, progress / distance);
            transform.position = tgtPos;
            progress += Time.deltaTime * speed;
            yield return null;
        }
        transform.position = dstPos;
    }
}
