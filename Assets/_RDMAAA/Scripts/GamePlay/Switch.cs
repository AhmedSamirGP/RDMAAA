using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //[SerializeField]
    public GameObject player1;
    //[SerializeField]
    public GameObject player2;

    void Start()
    {
        player1 = GetComponent<GameObject>();
        player2 = GetComponent<GameObject>();
    }

    public void SwitchPlayers()
    {
        //if (player1.GetComponent<Player>().enabled == true)
        //{
        //    if (player1.GetComponent<PlayerInput>().enabled == true)
        //    {
        //        if (player1.GetComponent<PlayerController>().enabled == true)
        //        {
        //            player1.GetComponent<Player>().enabled = false;
        //            player1.GetComponent<PlayerInput>().enabled = false;
        //            player1.GetComponent<PlayerController>().enabled = false;

        //        }

        //    }

        //}
    }
}
