using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    Transform target;
    float offSetZ;
    void Start()
    {
        target = GameManager.Instance.ball.transform;
        offSetZ = transform.position.z - target.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //it able us to follow the ball easly without using components or cinemachine for example
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.z = target.position.z + offSetZ;
        transform.position = pos;
    }
}
