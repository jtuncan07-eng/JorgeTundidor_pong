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
    public game_manager gameManager;
    Rigidbody2D _rb;
    AudioSource _audio;
    public AudioClip _aClip;
    public AudioClip _bClip;
    public float BallVelocity = 15f;
    float _lastHorizontalDirection = 10f;
    public float timeAlive = 0f;
    public float velocityMulti = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        LaunchBall(0);
    }

    private void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 2f && velocityMulti < 1.75f)
        {
            velocityMulti += 0.25f;
            BallVelocity *= velocityMulti;
            timeAlive = 0f;
        }
        else
        {
            timeAlive += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb.velocity.magnitude > BallVelocity)
        {
            _rb.velocity = _rb.velocity.normalized * BallVelocity;
        }

        if (Mathf.Abs(_rb.velocity.x) >= BallVelocity * 0.3f)
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
            ) * BallVelocity;
        }
    }
    void LaunchBall(int dir)
    {
        velocityMulti = 1f;
        timeAlive = 0f;
        BallVelocity = 10f;
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
        ).normalized * BallVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ball hit");
        if (collision.gameObject.tag == "LWall")
        {
            gameManager.PuntosP2++;
            LaunchBall(1);
            _audio.clip = _bClip;
            _audio.Play();
        }

        if (collision.gameObject.tag == "RWall")
        {
            gameManager.PuntosP1++;
            LaunchBall(-1);
            _audio.clip = _bClip;
            _audio.Play();
        }
        if (collision.gameObject.tag == "pala")
        {
            _audio.clip = _aClip;
            _audio.Play();
        }

    }
    
}
