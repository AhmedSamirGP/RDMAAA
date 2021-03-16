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

    bool forward = true;
    [SerializeField]
    float HalfCycleTime = 2;
    float t = 0;
    Vector3 StartPosition;
    Vector3 EndPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = InitialStartTransform.position;
        EndPosition = InitialEndTransform.position;
        transform.position = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {
            t += Time.deltaTime * Data.EnemySpeed / HalfCycleTime;
        if(forward)
        {
            if (t >= 1)
            {
                forward = false;
                transform.position = EndPosition;
                t = 0;
            }
            else
                transform.position = Vector3.Lerp(StartPosition, EndPosition, t);
        }else
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
