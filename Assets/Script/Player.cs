using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 updatedPosition;
    public float moveDistance;
    public float playerMoveSpeed;
    
    public float moveCooldown;
    public float moveCooldownReset;

    public float maxHeight;
    public float minHeight;

    public int playerHealth = 3;
    public int damageReceived = 1;

    // Update is called once per frame
    private void Update()
    {
        PlayerConstraint();
        moveCooldown = moveCooldown - Time.deltaTime;
        
        // move player
        transform.position = Vector2.MoveTowards(transform.position, updatedPosition, playerMoveSpeed * Time.deltaTime);
        PlayerMovementInput();
    }

    private void PlayerMovementInput()
    {
        if (moveCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight)
            {
                updatedPosition = new Vector2(transform.position.x, transform.position.y + moveDistance);
                moveCooldown = moveCooldownReset;
            }

            else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > minHeight)
            {
                updatedPosition = new Vector2(transform.position.x, transform.position.y - moveDistance);
                moveCooldown = moveCooldownReset;
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                updatedPosition = new Vector2(transform.position.x - moveDistance, transform.position.y);
                moveCooldown = moveCooldownReset;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                updatedPosition = new Vector2(transform.position.x + moveDistance, transform.position.y);
                moveCooldown = moveCooldownReset;
            }
        }
    }
    
    private void PlayerConstraint()
    {
        Vector2 constraintPosition = transform.position;
        
        if (constraintPosition.y > 3)
        {
            constraintPosition.y = 3;
        }
        
        else if (constraintPosition.y < -3)
        {
            constraintPosition.y = -3;
        }
    }

    private void CheckHealthStatus()
    {
        if (playerHealth <= 0)
        {
            Destroy(gameObject);

            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("hit");
            playerHealth = playerHealth - damageReceived;
            print(playerHealth);
            CheckHealthStatus(); 
        }
    }
}
