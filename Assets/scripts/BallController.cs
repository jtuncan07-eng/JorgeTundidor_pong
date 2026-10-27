using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb;
    public game_manager gameManager;
    public float velocity = 15f;
    float _lastHorizontalDirection = 10f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        LaunchBall(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb.velocity.magnitude > velocity)
        {
            _rb.velocity = _rb.velocity.normalized * velocity;
        }

        if (Mathf.Abs(_rb.velocity.x) >= velocity * 0.3f)
        {
            _lastHorizontalDirection = Mathf.Sign(_rb.velocity.x);
        }
        else
        {
            float yDirection = Mathf.Sign(_rb.velocity.y);

            if (yDirection == 0f)
            {
                yDirection = 10f;
            }

            float minX = 0.3f;
            float y = Mathf.Sqrt(1f - minX * minX);

            _rb.velocity = new Vector2(
                _lastHorizontalDirection * minX,
                yDirection * y
            ) * velocity;
        }
    }
    void LaunchBall(int dir)
    {
        transform.position = new Vector2(0f, 0f);
        if (dir == 0)
        {
            _lastHorizontalDirection = Random.value > 0.5f ? 1f : -1f;
        }
        else
        {
            _lastHorizontalDirection = dir;
        }

        float yVelocity = Random.Range(-0.7f, 0.7f);

        _rb.velocity = new Vector2(
            _lastHorizontalDirection,
            yVelocity
        ).normalized * velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ball hit");
        if (collision.gameObject.tag == "LWall")
        {
            gameManager.PuntosP2++;
            LaunchBall(1);
        }

        if (collision.gameObject.tag == "RWall")
        {
            gameManager.PuntosP1++;
            LaunchBall(-1);
        }
    }
    
}
