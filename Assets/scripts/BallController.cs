using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb;
    public game_manager gameManager;
    public float velocity = 15f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb.velocity.magnitude > velocity)
        {
            _rb.velocity = _rb.velocity.normalized * velocity;
        }
    }
    void LaunchBall()
    {
        bool isRight = false;
        if (Random.value > 0.5f)
        {
            isRight = true;
        }
        float xVelocity = -1;
        if(isRight == true)
        {
            xVelocity = 1;
        }
        float yVelocity = Random.Range(-1f, 1f);
        _rb.velocity = new Vector2(xVelocity * velocity, yVelocity * velocity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ball hit");
        if (collision.gameObject.tag == "LWall")
        {
            gameManager.PuntosP1++;
        }
        if (collision.gameObject.tag == "RWall")
        {
            gameManager.PuntosP2++;
        }
    }
}
