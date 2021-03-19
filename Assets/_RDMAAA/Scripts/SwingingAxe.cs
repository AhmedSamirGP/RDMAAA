using UnityEngine;

public class SwingingAxe : MonoBehaviour
{
    [SerializeField]
    EnemySO timeSlowSO;
    [SerializeField]
    bool RotateOnZAxis = false;
    [SerializeField]
    float MaxAngle = 70;
    [SerializeField]
    float Duration = 2;
    float Degree = 0;
    bool bForward = true;
    bool bUp = true;
    float t = 0;

    private void FixedUpdate()
    {
        t += Time.deltaTime;
        if (bForward)
        {
            if (bUp)
            {
                Degree = EaseOut(4 * t * timeSlowSO.EnemySpeed / (Duration )) * MaxAngle;
                if (Degree >= MaxAngle)
                {
                    bUp = false;
                    bForward = false;
                    t = 0;
                }
            }
            else
            {
                Degree = (1 - EaseIn(4 * t * timeSlowSO.EnemySpeed / (Duration ))) * -MaxAngle;
                if (Degree >= 0)
                {
                    bUp = true;
                    t = 0;
                }
            }

        }
        else
        {
            if (bUp)
            {
                Degree = (EaseOut(4 * t * timeSlowSO.EnemySpeed / (Duration ))) * -MaxAngle;
                if (Degree <= -MaxAngle)
                {
                    bUp = false;
                    bForward = true;
                    t = 0;
                }
            }
            else
            {
                Degree = (1 - EaseIn(4 * t * timeSlowSO.EnemySpeed / (Duration ))) * MaxAngle;
                if (Degree <= 0)
                {
                    bUp = true;
                    t = 0;
                }
            }
        }
        if (RotateOnZAxis)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, Degree);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(Degree, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
        }
    }
    float EaseOut(float x)
    {
        return Mathf.Sin((x * Mathf.PI) / 2);
    }
    float EaseIn(float x)
    {
        return 1 - Mathf.Cos((x * Mathf.PI) / 2);
    }

}
