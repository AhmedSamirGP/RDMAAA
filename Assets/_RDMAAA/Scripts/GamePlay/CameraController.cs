using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerDataSO playerData;
    Vector3 offset;

    void Start()
    {
        offset = playerData.position;
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        offset = playerData.position;

        offset = transform.position - player.transform.position;
        Debug.Log(offset);
        transform.position = player.transform.position + offset;
    }
}
