using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float speed;
    [SerializeField]
    int gainedPoints;
    [SerializeField]
    bool playerState;
    [SerializeField]
    PlayerDataSO playerData;
    void Start()
    {
        speed = 5f;
        gainedPoints = 0;
        playerState = true;

        playerData.speed = speed;
        playerData.gainedPoints = gainedPoints;
        playerData.state = playerState;    
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == false || playerData.state==false) 
        {
            //Dead animation
            Destroy(this.gameObject);
            playerData.state = false;
            //GameOver
        }
       // this.transform.position = playerData.position;
    }
}
