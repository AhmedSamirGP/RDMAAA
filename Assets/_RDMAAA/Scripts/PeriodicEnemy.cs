using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicEnemy : MonoBehaviour
{
    [SerializeField]
    Transform InitialStartTransform;
    [SerializeField]
    Transform InitialEndTransform;
    [SerializeField]
    EnemySO Data;

    public bool active = true;
    [SerializeField]
    float HalfCycleTime = 2;

    bool forward = true;
    float t = 0;
    Vector3 StartPosition;
    Vector3 EndPosition;

    void Start()
    {
        StartPosition = InitialStartTransform.position;
        EndPosition = InitialEndTransform.position;
        transform.position = StartPosition;
    }


    void Update()
    {
        if (!active) return;
        t += Time.deltaTime / (Data.EnemySpeed * HalfCycleTime);
        if (forward)
        {
            if (t >= 1)
            {
                forward = false;
                transform.position = EndPosition;
                t = 0;
            }
            else
                transform.position = Vector3.Lerp(StartPosition, EndPosition, t);
        }
        else
        {
            if (t >= 1)
            {
                forward = true;
                transform.position = StartPosition;
                t = 0;
            }
            else
                transform.position = Vector3.Lerp(EndPosition, StartPosition, t);
        }
    }
}
