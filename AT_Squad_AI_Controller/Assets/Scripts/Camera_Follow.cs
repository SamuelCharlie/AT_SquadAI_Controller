using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public GameObject squad;
    private Vector3 camera_offset;
    void Start()
    {
        camera_offset = transform.position - squad.transform.position;
    }
    void LateUpdate()
    {
        transform.position = squad.transform.position + camera_offset;
    }
}
