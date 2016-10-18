using UnityEngine;
using System.Collections;

public class MainMenuParallaxScrolling : MonoBehaviour
{
    public float ScrollSpeed;
    public float TileSizeX;

    private Vector2 startPosition;

    void Start()
    {
        this.startPosition = this.transform.position;
        this.TileSizeX = Screen.width;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * this.ScrollSpeed, this.TileSizeX);
        this.transform.position = this.startPosition + Vector2.right * newPosition;
    }
}