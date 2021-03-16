using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Data/PlayerDataSO")]

public class PlayerDataSO : ScriptableObject
{
    public Vector3 position;
    public float speed;
    public int gainedPoints;
    public bool state;
}
