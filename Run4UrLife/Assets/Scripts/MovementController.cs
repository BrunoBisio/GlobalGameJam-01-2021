using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public PlayerController controller;
    [SerializeField] private float runSpeed = 40f;
    private float horizontalMove;
    private bool jump = false;
    private float currentSpeed;
    // booster
    [SerializeField] private float speedBoost = 10f;
    [SerializeField] private float boostTime = 3;
    private float boostTimer = 0;
    private bool boosting = false;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(boosting)
		{
            boostTimer += Time.deltaTime;
            if (boostTimer >= boostTime)
			{
                currentSpeed = runSpeed;
                boostTimer = 0;
                boosting = false;
			}
		}

        horizontalMove = Input.GetAxisRaw("Horizontal") * currentSpeed;
        if (Input.GetButtonDown("Jump")) { 
            jump = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, jump);
        jump = false;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("booster"))
		{
            boosting = true;
            currentSpeed = runSpeed + speedBoost;
		}
	}


}