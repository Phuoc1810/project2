using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //tu dong tim gameobject co tag player
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            //gan follow cho virtual camera 
            CinemachineVirtualCamera vcam = GetComponent<CinemachineVirtualCamera>();
            if(vcam != null)
            {
                vcam.Follow = player.transform;
            }
        }
        else
        {
            Debug.Log("Player khong tim thay trong scene nay");
        }
    }
}
