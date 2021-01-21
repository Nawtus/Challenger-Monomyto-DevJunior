using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera Cam;
    private Transform PlayerTransform;

    void Start()
    {
        Cam = Camera.main;
        PlayerTransform = GetComponent<Transform>();
    }



    void Update()
    {
        Following();
    }



    void Following()
    {
        Vector3 posCam = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, Cam.transform.position.z);
        Cam.transform.position = posCam;
    }
}
