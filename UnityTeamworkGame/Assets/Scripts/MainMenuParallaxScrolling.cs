using UnityEngine;
using System.Collections;

public class MainMenuParallaxScrolling : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeX;

    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
        tileSizeX = Screen.width;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        transform.position = startPosition + Vector2.right * newPosition;
    }
}
