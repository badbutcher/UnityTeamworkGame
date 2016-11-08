
﻿using UnityEngine;

public class PirateMove : MonoBehaviour
{
    public GameObject[] Points;
    public GameObject[] Sprites;
    public int CurrentPoint;
    private float maxTurn = 0.5f;
    public float moveSpeed;

    private void Start()
    {
        this.moveSpeed = PlayerStats.PlayerMoveSpeed + Random.Range(-0.2f, 0.5f);
        this.Reset();
        this.Sprites[0].SetActive(true);
        for (int i = 1; i < this.Points.Length; i++)
        {
            this.Points[i] = GameObject.Find("Point" + Random.Range(2, 16));
        }

        this.Points[0] = GameObject.Find("Point1");
        this.Points[9] = GameObject.Find("Point15");
        this.gameObject.transform.position = this.Points[0].transform.position;
    }

    private void Update()
    {
        if (!PlayerStats.IsDead)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.Points[this.CurrentPoint].transform.position, moveSpeed * Time.deltaTime);
            if (this.transform.position == this.Points[this.CurrentPoint].transform.position)
            {
                if (this.CurrentPoint == this.Points.Length - 1f)
                {
                    this.CurrentPoint = 0;
                }
                else
                {
                    this.Reset();
                    this.CurrentPoint++;
                    Vector2 lastPos = this.Points[this.CurrentPoint - 1].transform.position;
                    Vector2 currentPos = this.Points[this.CurrentPoint].transform.position;
                    if (Mathf.Abs(lastPos.x - currentPos.x) <= this.maxTurn && lastPos.y - currentPos.y > this.maxTurn)
                    {
                        this.Sprites[0].SetActive(true);
                    }
                    else if (lastPos.x - currentPos.x > this.maxTurn && lastPos.y - currentPos.y > this.maxTurn)
                    {
                        this.Sprites[1].SetActive(true);
                    }
                    else if (currentPos.x - lastPos.x > this.maxTurn && lastPos.y - currentPos.y > this.maxTurn)
                    {
                        this.Sprites[2].SetActive(true);
                    }
                    else if (lastPos.x - currentPos.x > this.maxTurn && Mathf.Abs(lastPos.y - currentPos.y) <= this.maxTurn)
                    {
                        this.Sprites[3].SetActive(true);
                    }
                    else if (currentPos.x - lastPos.x > this.maxTurn && Mathf.Abs(lastPos.y - currentPos.y) <= this.maxTurn)
                    {
                        this.Sprites[4].SetActive(true);
                    }
                    else if (Mathf.Abs(lastPos.x - currentPos.x) <= this.maxTurn && currentPos.y - lastPos.y > this.maxTurn)
                    {
                        this.Sprites[5].SetActive(true);
                    }
                    else if (lastPos.x - currentPos.x > this.maxTurn && currentPos.y - lastPos.y > this.maxTurn)
                    {
                        this.Sprites[6].SetActive(true);
                    }
                    else if (currentPos.x - lastPos.x > this.maxTurn && currentPos.y - lastPos.y > this.maxTurn)
                    {
                        this.Sprites[7].SetActive(true);
                    }
                }
            }
        }
    }

    private void Reset()
    {
        this.Sprites[0].SetActive(false);
        this.Sprites[1].SetActive(false);
        this.Sprites[2].SetActive(false);
        this.Sprites[3].SetActive(false);
        this.Sprites[4].SetActive(false);
        this.Sprites[5].SetActive(false);
        this.Sprites[6].SetActive(false);
        this.Sprites[7].SetActive(false);
    }
}