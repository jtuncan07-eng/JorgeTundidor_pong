using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 15f;       
    public bool useArrowKeys = false;   
    public float topMargin;             
    public float bottomMargin;
    public bool IA;
    public GameObject ball;
    public float IAfollowTolerance = 0.5f;

    
    void Update()
    {
        if(IA == false)
        {
            MovePaddle();
        }
        else
        {
            MovePaddleIA();
        }
        MovePaddle();
    }
    void MovePaddle()
    {
        this.gameObject.transform.position = new Vector3(transform.position.x, ConstrainPaddle(), transform.position.z);
    }
    void MovePaddleIA()
    {
        int direccion = 0;
        float diferencia = ball.transform.position.y - transform.position.y;

        if (diferencia > IAfollowTolerance)
        {
            direccion = 1;
        }
        else if (diferencia < -IAfollowTolerance)
        {
            direccion = -1;
        }
        float nuevaY = transform.position.y + (direccion * moveSpeed / 2 * Time.deltaTime);
        if (nuevaY > topMargin)
        {
            nuevaY = topMargin;
        }
        if (nuevaY < bottomMargin)
        {
            nuevaY = bottomMargin;
        }
        this.gameObject.transform.position = new Vector3(transform.position.x, nuevaY, transform.position.z);
    }
    float ConstrainPaddle()
    {
        float nuevaY = this.gameObject.transform.position.y + (PaddleDirection() * moveSpeed * Time.deltaTime);
        if (nuevaY > topMargin)
        {
            nuevaY = topMargin;
        }
        if (nuevaY < bottomMargin)
        {
            nuevaY = bottomMargin;
        }
        return nuevaY;
    }
    float PaddleDirection()
    {
        float mover = 0f;

        if (useArrowKeys == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("estas predionando la tecla :0");
                mover = 1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("estas presionando la otra tecla :0");
                mover = -1f; 
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("estas predionando la tecla :0");
                mover = 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("estas presionando la otra tecla :0");
                mover = -1f; 
            }      
        }
        return mover;
    }
}
 