using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region singleton
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
    #endregion
    //normal platform
    [SerializeField] GameObject prefabPlatform;
    //platform like the normal ones but this one falls, just to make the game less static and aware the player
    [SerializeField] GameObject prefabFallingPlatform;
    //like the falling platform,this one accelerates the speed
    [SerializeField] GameObject prefabSpeedUpPlatform;
    //the ball
    [SerializeField] GameObject prefabBall;


    public float ballSpeed;
    public float score;
    public GameObject ball;

    GameObject lastPlatform;

    void Start()
    {
        //instantiate the first block in the position we like
        lastPlatform = Instantiate(prefabPlatform,
      new Vector3(0, -1, 0), Quaternion.identity);

        //first 5 block so the player starts with no difficulties and stress
        for (int i = 0; i < 5; i++)
        {
            InitPlatform();
        }

        //instance of the ball right on top of the first platform(set in the prefab)
        ball = Instantiate(prefabBall);
    }

    // Update is called once per frame
    void Update()
    {
        //condition to generate in real time the platforms
        while (Vector3.Distance(lastPlatform.transform.position, ball.transform.position) < 5)
        {
            GeneratePlatform();
        }
    }


    private void InitPlatform()
    {
        //funtion to generate first normal platforms
        Vector3 position = lastPlatform.transform.position;
        position.z += 1;
        if (Random.Range(0, 2) != 0)
        {
            position.x += 0.5f;
        }
        else
        {
            position.x -= 0.5f;
        }

        //we set the last platform so we can use it when need
        lastPlatform = Instantiate(prefabPlatform, position, Quaternion.identity);
    }
    private void GeneratePlatform()
    {
        Vector3 position = lastPlatform.transform.position;
        position.z += 1;
        if (Random.Range(0, 2) != 0)
        {
            position.x += 0.5f;
        }
        else
        {
            position.x -= 0.5f;
        }
        //here every 10 point of score we put a platform that accelerates the speed of the ball
        if (score % 10 == 0)
        {
            lastPlatform = Instantiate(prefabSpeedUpPlatform, position, Quaternion.identity);
            return;
        }
        //we set the last platform so we can use it when need
        lastPlatform = Instantiate(prefabFallingPlatform, position, Quaternion.identity);
    }
}
