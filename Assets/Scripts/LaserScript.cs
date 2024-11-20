using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private const float speed = 80.0f;
    private const float topMargin = 11.0f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > topMargin)    Destroy(this.gameObject);
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit something!");
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Hit enemy!");
            try
            {
                other.gameObject.GetComponent<BaseEnemy>().DamageEnemy();
                //Debug.Log("Hit base!");
            }
            catch
            {
                try
                {
                    other.gameObject.GetComponent<ScoutEnemy>().DamageEnemy();
                    //Debug.Log("Hit Scout!");
                }
                catch
                {
                    other.gameObject.GetComponent<TankEnemy>().DamageEnemy();
                   // Debug.Log("Hit Tank!");
                }
            }
            Destroy(this.gameObject);
        }
    }
}
