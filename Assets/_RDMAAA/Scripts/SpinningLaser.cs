using UnityEngine;

public class SpinningLaser : MonoBehaviour
{
    [SerializeField]
    EnemySO enemy;
    [SerializeField]
    float speed;
    void Update()
    {
        transform.Rotate(new Vector3(0, enemy.EnemySpeed * speed * Time.deltaTime, 0));
    }
}
