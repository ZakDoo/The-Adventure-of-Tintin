using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovment : MonoBehaviour
{

    private Vector3 posA;
    private Vector3 posB;

    private Vector3 nextPos;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    // Start is called before the first frame update
    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;

        nextPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(childTransform.localPosition, nextPos)<=0.1)
        {
            changeDestination();
        }
    }

    private void changeDestination()
    {
        nextPos = nextPos != posA ? posA : posB;
    }

}
