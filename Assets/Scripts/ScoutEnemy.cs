using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScoutEnemy : BaseEnemy
{
    private const float ScoutSpeedBonus = 15.0f;

    protected override void Start()
    {
        speed += ScoutSpeedBonus;
        base.Start();
    }



}
