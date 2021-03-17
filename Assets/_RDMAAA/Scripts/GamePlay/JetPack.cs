using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    [SerializeField]
    float jetForce=500; // how powerfull the jetpack
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
    [SerializeField]
    UIBarSO uiBar;
    void Start()
    {
        jetSO.canJet = false;
        currentFeul = max_fuel;
        rig = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {

        // if() jetpack butting hitted getkey space bs w 5ly eljump get key down
        //if can jump and not grounded
        if (jetSO.canJet)
        {
          //  Debug.Log("Git");

            if (!jetSO.grounded && jetSO.canJet && currentFeul > 0)
            {
                //Debug.Log("jetting");
                Vector3 value = Vector3.forward * jetForce ;
                // Debug.Log(value);
                  rig.AddForce(value, ForceMode.Acceleration);
                //rig.AddForce(0, 0, 500);
                currentFeul = Mathf.Max(0, currentFeul - Time.fixedDeltaTime);
                //update current fuel in SO
                uiBar.Value = currentFeul;
            }
        }

    }
}
