using UnityEngine;
using System.Collections;

public class ShipMove : MonoBehaviour
{
    public GameObject Up;
    public GameObject Down;
    public GameObject Left;
    public GameObject Right;

    public GameObject UpLeft;
    public GameObject UpRight;
    public GameObject DownLeft;
    public GameObject DownRight;

    void Start()
    {
        this.Reset();
        this.Up.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad8))
        {
            this.Reset();
            this.Up.SetActive(true);
            this.transform.Translate(0, 0.5f * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.Keypad7))
        {
            this.Reset();
            this.UpLeft.SetActive(true);
            this.transform.Translate(-0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.Keypad9))
        {
            this.Reset();
            this.UpRight.SetActive(true);
            this.transform.Translate(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            this.Reset();
            this.Down.SetActive(true);
            this.transform.Translate(0, -0.5f * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.Keypad1))
        {
            this.Reset();
            this.DownLeft.SetActive(true);
            this.transform.Translate(-0.5f * Time.deltaTime, -0.5f * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.Keypad3))
        {
            this.Reset();
            this.DownRight.SetActive(true);
            this.transform.Translate(0.5f * Time.deltaTime, -0.5f * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.Keypad4))
        {
            this.Reset();
            this.Left.SetActive(true);
            this.transform.Translate(-0.5f * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.Keypad6))
        {
            this.Reset();
            this.Right.SetActive(true);
            this.transform.Translate(0.5f * Time.deltaTime, 0, 0);
        }
    }

    private void Reset()
    {
        this.Up.SetActive(false);
        this.Down.SetActive(false);
        this.Left.SetActive(false);
        this.Right.SetActive(false);
        this.UpLeft.SetActive(false);
        this.UpRight.SetActive(false);
        this.DownLeft.SetActive(false);
        this.DownRight.SetActive(false);
    }
}