using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Data/JetPackSO")]

public class JetPackSO : ScriptableObject
{

    public bool canJet;
    public bool canJump;
    public bool grounded;
}
   
