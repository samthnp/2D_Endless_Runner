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

    public float maxUp;
    public float maxDown;
    public float maxLeft;
    public float maxRight;

    public int playerHealth = 3;
    public int damageReceived = 1;

    public int test;

    // Update is called once per frame
    private void Update()
    {
        
        moveCooldown = moveCooldown - Time.deltaTime;
        
        // move player
        transform.position = Vector2.MoveTowards(transform.position, updatedPosition, playerMoveSpeed * Time.deltaTime);
        PlayerMovementInput();
    }
    private void PlayerMovementInput()
    {
        if (moveCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxUp)
            {
                updatedPosition = new Vector2(transform.position.x, transform.position.y + moveDistance);
                moveCooldown = moveCooldownReset;
            }

            else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > maxDown)
            {
                updatedPosition = new Vector2(transform.position.x, transform.position.y - moveDistance);
                moveCooldown = moveCooldownReset;
            }

            else if (Input.GetKeyDown(KeyCode.A) && transform.position.x > maxLeft)
            {
                updatedPosition = new Vector2(transform.position.x - moveDistance, transform.position.y);
                moveCooldown = moveCooldownReset;
            }
            else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < maxRight)
            {
                updatedPosition = new Vector2(transform.position.x + moveDistance, transform.position.y);
                moveCooldown = moveCooldownReset;
            }
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
