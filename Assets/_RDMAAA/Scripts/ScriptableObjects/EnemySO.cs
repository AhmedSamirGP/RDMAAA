using UnityEngine;

[CreateAssetMenu]
public class EnemySO : ScriptableObject, InitializibleSO<float>
{
    public float EnemySpeed;
    [SerializeField]
    float InitialEnemySpeed;
    public float GetInitialValue()
    {
        return InitialEnemySpeed;
    }

    public void SetValue(float initValue)
    {
        EnemySpeed = initValue;
    }
}
