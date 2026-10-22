using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 15f;       //speed of the paddle
    public bool useArrowKeys = false;   //If it's true use the arrows keys, if's not use W and S
    public float topMargin;             //Max limit to move the paddle
    public float bottomMargin;          //Minim limit to move the paddle
    
    void Update()
    {
        MovePaddle();
    }
    void MovePaddle()
    {
        this.gameObject.transform.position = new Vector3(transform.position.x, ConstrainPaddle(), transform.position.z);
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
 