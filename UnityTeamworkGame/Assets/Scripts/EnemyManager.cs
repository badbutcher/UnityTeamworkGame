using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static List<string> Enemies = new List<string>();
    public static string Enemy;

    void Start()
    {
        if (!Enemies.Contains(Enemy))
        {
            Enemies.Add(Enemy);
        }

        for (int i = 0; i < Enemies.Count; i++)
        {
           MonoBehaviour.Destroy(GameObject.Find(gameObject.name = Enemies[i]));
        }
    }

    void Update()
    {
        Debug.Log(Enemies.Count);
    }
}