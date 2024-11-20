using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private const float speed = 25.0f;
    private const float attackRate = 0.3f;
    private bool canShoot = true;

    private const float leftMargin = -23.0f;
    private const float rightMargin = 23.0f;

    public GameObject laser;
    public GameManagerScript gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canShoot)
            {
                ShootLaser();
            }
            MovePlayer();
        }
        
    }

    private void MovePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow) && (transform.position.x > leftMargin) )
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) && (transform.position.x < rightMargin))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

    }

    private void ShootLaser()
    {
        Vector3 laserPosition = transform.position + new Vector3(0, 1, 0);
        Instantiate(laser, laserPosition, Quaternion.identity);
        canShoot = false;
        StartCoroutine(ShootCooldown());
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(attackRate);
        canShoot = true;
    }
}
