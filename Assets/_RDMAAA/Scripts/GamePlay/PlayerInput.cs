using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{

    public IInputManager inputManager;
    public Vector3SO movement;
    [SerializeField]
    bool switchPlayers;
    [SerializeField]
    bool ability;
    CharacterController controller;
    [SerializeField]
    JetPackSO jetSO;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        jetSO.canJump = false;
        jetSO.canJet = false;
        //getting abilities components
        if (null == inputManager)
        {
            inputManager = new InputHandler();
            // Debug.Log("nulll");
        }
        //getback button listener
    }

    void Update()
    {
        Vector3 moving = Vector3.zero;

        if (inputManager.GetForword())
        {
            moving.z++;
        }
        if (inputManager.GetBackword())
        {
            moving.z--;
        }
        if (inputManager.GetRight())
        {
            moving.x++;
        }
        if (inputManager.GetLeft())
        {
            moving.x--;
        }
        if (inputManager.Jump())
        {
            jetSO.canJump = true;
        }
        if (inputManager.UseJetPack())
        {
           // Debug.Log("can jet");
            jetSO.canJet = true;
        }
        if (inputManager.useTime())
        {
           ////
        }
        this.movement.vector = moving;
    }


}
