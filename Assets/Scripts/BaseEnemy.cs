using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    protected const float topMargin = 11.0f;
    protected const float bottomMargin = -6.25f;
    protected const float leftMargin = -23.0f;
    protected const float rightMargin = 23.0f;

    protected bool isGoingRight = true;

    protected float speed = 20.0f;
    protected const float downMovement = 350.0f;

    protected GameManagerScript gameManager;

    protected virtual void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    protected virtual void Update()
    {
        if(!gameManager.isGameOver) MoveEnemy();
    }

    protected void MoveEnemy()
    {
        if (isGoingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x > rightMargin)
            {
                isGoingRight = false;
                transform.position += Vector3.down * downMovement * Time.deltaTime;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x < leftMargin)
            {
                isGoingRight = true;
                transform.position += Vector3.down * downMovement * Time.deltaTime;
            }
        }
    }

    public virtual void DamageEnemy()
    {
        Destroy(this.gameObject);
        gameManager.enemiesleft--;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.isGameOver = true;
        }
    }
}
