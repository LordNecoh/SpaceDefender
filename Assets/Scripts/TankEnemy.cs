using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankEnemy : BaseEnemy
{
    private int health = 3;
    public GameObject[] stages = new GameObject[3];

    protected override void Start()
    {
        stages[2].SetActive(false);
        stages[1].SetActive(false);
        base.Start();
    }

    public override void DamageEnemy()
    {
        switch(health)
        {
            case 3:
                stages[0].SetActive(false);
                stages[1].SetActive(true);
                break;
            case 2:
                stages[1].SetActive(false);
                stages[2].SetActive(true);
                break;
        }

        health--;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            gameManager.enemiesleft--;
        }
    }

}
