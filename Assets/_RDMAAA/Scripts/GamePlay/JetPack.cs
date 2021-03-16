using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    [SerializeField]
    float jetForce; // how powerfull the jetpack
    [SerializeField]
    float jetWait;  //how long it's going to take before needing to be recovered
    [SerializeField]
    float jetRecovery;
    [SerializeField]
    float max_fuel; // how much fuel is in the jetpack

    float currentFeul;
    float currentRecovery;
    bool canJet = false;
    Rigidbody rig;
    [SerializeField]
    JetPackSO jetSO;
    void Start()
    {
        jetSO.canJet = false;
        currentFeul = max_fuel;
        rig = GetComponent<Rigidbody>();
    }


    void Update()
    {

    }
    void FixedUpdate()
    {
        // if() jetpack butting hitted getkey space bs w 5ly eljump get key down
        //if can jump and not grounded
        if (jetSO.canJet)
        {
            if (jetSO.canJump & !jetSO.grounded)
                canJet = true;
            if (jetSO.grounded)
                canJet = false;

            jetSO.canJet = canJet;

            if (canJet && jetSO.canJet && currentFeul > 0)
            {
                rig.AddForce(Vector3.up * jetForce * Time.fixedDeltaTime, ForceMode.Acceleration);
                currentFeul = Mathf.Max(0, currentFeul - Time.fixedDeltaTime);
                //update current fuel in SO
            }
        }

    }
}
