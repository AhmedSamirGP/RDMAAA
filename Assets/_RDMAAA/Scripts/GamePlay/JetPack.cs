using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    [SerializeField]
    float jetForce = 500; // how powerfull the jetpack
    [SerializeField]
    float jetWait;  //how long it's going to take before needing to be recovered
    [SerializeField]
    float jetRecovery;

    bool canJet = false;
    Rigidbody rig;
    [SerializeField]
    JetPackSO jetSO;

    [SerializeField]
    float fuelConsumption;
    [SerializeField]
    UIBarSO uiBar;
    void Start()
    {
        jetSO.canJet = false;
        rig = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {
        // if() jetpack butting hitted getkey space bs w 5ly eljump get key down
        //if can jump and not grounded
        if (jetSO.canJet)
        {
            //  Debug.Log("Git");

            if (!jetSO.grounded && uiBar.Value > 0)
            {
                //Debug.Log("jetting");
                Vector3 value = transform.up * jetForce;
                // Debug.Log(value);
                if (transform.position.y < 15)
                {
                    rig.AddForce(value, ForceMode.Acceleration);
                } 
                else
                {
                    rig.velocity = new Vector3(rig.velocity.x, 0, rig.velocity.z);
                }
                //rig.AddForce(0, 0, 500);
                uiBar.Value = Mathf.Max(0, uiBar.Value - Time.fixedDeltaTime * fuelConsumption);
                Debug.Log(uiBar.Value);
            }
        }

    }
}
