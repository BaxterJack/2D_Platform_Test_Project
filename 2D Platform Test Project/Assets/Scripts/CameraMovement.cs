using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform player;
    Transform cameraTransform;
    Vector3 playerPos;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        playerPos = player.position;
        playerPos.z = -1;
        cameraTransform.position = playerPos;
        
    }


    void Update()
    {
        playerPos = player.position;
        playerPos.z = -1;
        cameraTransform.position = playerPos;
    }
}
