using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineFindPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //CinemachineVirtualCamera cineMachine = new CinemachineVirtualCamera();
        CinemachineVirtualCamera cineMachine = GetComponent<CinemachineVirtualCamera>();
        cineMachine.LookAt = PlayerManager.Instance.gameObject.transform;
        cineMachine.Follow = PlayerManager.Instance.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
