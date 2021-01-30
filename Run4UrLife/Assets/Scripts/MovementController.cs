using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public PlayerController controller;
    public float runSpeed = 40f;
    public float airSpeed = 5f;
    private float horizontalMove;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump")) { 
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if(jump)
		{
            horizontalMove = airSpeed;
		}
        controller.Move(horizontalMove * Time.deltaTime, jump);
        jump = false;
    }
}