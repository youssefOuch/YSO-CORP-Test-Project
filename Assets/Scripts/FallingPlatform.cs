using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] GameObject cube;
    void Update()
    {
        //platform falls without using rigidbody
        if (cube.transform.position.y > transform.position.y)
        {
            //here i use ballspeed so if the speed of the ball increases the falling of the platform too.
            cube.transform.position += Vector3.down * GameManager.Instance.ballSpeed * Time.deltaTime;
        }
    }
}
