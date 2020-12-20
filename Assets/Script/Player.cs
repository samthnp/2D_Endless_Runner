using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Vector2 updatedPosition;
    public float valueOfMovement;
    public float playerMoveSpeed;

    public float maxHeight;
    public float minHeight;

    public int playerHealth = 3;

    // Update is called once per frame
    private void Update()
    {
        PlayerConstraint();
        transform.position = Vector2.MoveTowards(transform.position,updatedPosition,playerMoveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight)
        {
            updatedPosition = new Vector2(transform.position.x,transform.position.y + valueOfMovement);
        }

        else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > minHeight)
        {
            updatedPosition = new Vector2(transform.position.x, transform.position.y - valueOfMovement);
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
    void CheckHealthStatus()
    {
        if (playerHealth <= 0)
        {
            Destroy(gameObject);

            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("hit");
            CheckHealthStatus(); 
        }
    }
}
