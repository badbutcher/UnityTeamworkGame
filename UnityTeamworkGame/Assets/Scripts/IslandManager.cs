using UnityEngine;
using System.Collections.Generic;

public class IslandManager : MonoBehaviour
{
    public static List<string> Islands = new List<string>();
    public static string Island;
    private int totalEnemyCount = 5;

    private void Start()
    {
        if (!Islands.Contains(Island))
        {
            Islands.Add(Island);
        }

        for (int i = 0; i < Islands.Count; i++)
        {
            MonoBehaviour.Destroy(GameObject.Find(gameObject.name = Islands[i]));
        }
    }
}