using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    float speed = 1.5f;
    Rigidbody rigidBody;
    bool gameOver;

    void Start()
    {
        gameOver = false;
        rigidBody = transform.GetComponent<Rigidbody>();
    }
    void Update()
    {
        //same as the fixed update, if game over we call the function for the game over and we return
        //because we dont need to execute the rest
        if (gameOver && transform.position.y > -10)
        {
            StartCoroutine(GameOver());
            return;
        }
        
        //movement of the ball(always go forward by default so it's unstopable
        transform.position += transform.forward * Time.deltaTime * speed;

        //controls of the ball
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position += Vector3.right * touch.deltaPosition.x * 0.003f;
            }
        }
    }
    private void FixedUpdate()
    {
        //if game over we dont need to execute the rest of the code
        if (gameOver) return;

        //checks if there's something under, if not it's game over and the ball can fall
        if (!Physics.Raycast(transform.position, Vector3.down))
        {
            rigidBody.useGravity = true;
            rigidBody.constraints = RigidbodyConstraints.None;
            gameOver = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //accelerates the ball when it collides
        if (collision.transform.CompareTag("SpeedUpPlatform"))
        {
            speed += 0.5f;
        }
        //up date the score
        GameManager.Instance.score++;
        //call to destroy object so we dont have a lot of objects to handle with the time
        StartCoroutine(DestroyObject(collision.gameObject));
    }

    //reloads the scene when game over is true
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    //destroys the object that we alredy passed
    IEnumerator DestroyObject(GameObject go)
    {
        yield return new WaitForSeconds(2);
        Destroy(go);
    }
}

