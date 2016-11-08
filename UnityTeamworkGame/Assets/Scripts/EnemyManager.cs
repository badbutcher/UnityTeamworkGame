using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static List<string> Enemies = new List<string>();
    public static string Enemy;
    private float totalEnemyCount = 5;

    private void Start()
    {
        if (Enemies.Count >= totalEnemyCount)
        {
            for (int i = 0; i < totalEnemyCount; i++)
            {
                Enemies.Remove(gameObject.name = Enemies[i]);
            }
        }

        if (!Enemies.Contains(Enemy))
        {
            Enemies.Add(Enemy);
        }

        for (int i = 0; i < Enemies.Count; i++)
        {
           MonoBehaviour.Destroy(GameObject.Find(gameObject.name = Enemies[i]));
        }
    }
}