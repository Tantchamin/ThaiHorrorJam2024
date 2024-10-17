using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemyList;

    public void MoveAllEnemy()
    {
        foreach(Enemy enemy in enemyList)
        {
            enemy.Move();
        }
    }
}
