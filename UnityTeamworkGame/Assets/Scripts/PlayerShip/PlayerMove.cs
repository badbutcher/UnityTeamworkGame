using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public GameObject Up;
    public GameObject Down;
    public GameObject Left;
    public GameObject Right;

    public GameObject UpLeft;
    public GameObject UpRight;
    public GameObject DownLeft;
    public GameObject DownRight;

    public Scene Scene;

    public PlayerStats PlayerStats;

    public static float X;
    public static float Y;

    private void Start()
    {
        this.Scene = SceneManager.GetActiveScene();

        if (this.Scene.name == "MainScene")
        {
            this.gameObject.transform.position = new Vector3(X, Y, 0f);
        }

        this.Reset();
        this.Up.SetActive(true);
    }

    private void Update()
    {
        if (!PlayerStats.IsDead && !this.PlayerStats.IsInShop)
        {
            if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)))
            {
                this.Reset();
                this.UpRight.SetActive(true);
                this.transform.Translate(PlayerStats.PlayerMoveSpeed * Time.deltaTime, PlayerStats.PlayerMoveSpeed * Time.deltaTime, 0f);
            }
            else if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)))
            {
                this.Reset();
                this.UpLeft.SetActive(true);
                this.transform.Translate(-PlayerStats.PlayerMoveSpeed * Time.deltaTime, PlayerStats.PlayerMoveSpeed * Time.deltaTime, 0f);
            }
            else if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)))
            {
                this.Reset();
                this.DownRight.SetActive(true);
                this.transform.Translate(PlayerStats.PlayerMoveSpeed * Time.deltaTime, -PlayerStats.PlayerMoveSpeed * Time.deltaTime, 0f);
            }
            else if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)))
            {
                this.Reset();
                this.DownLeft.SetActive(true);
                this.transform.Translate(-PlayerStats.PlayerMoveSpeed * Time.deltaTime, -PlayerStats.PlayerMoveSpeed * Time.deltaTime, 0f);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                this.Reset();
                this.Up.SetActive(true);
                this.transform.Translate(0f, PlayerStats.PlayerMoveSpeed * Time.deltaTime, 0f);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.Reset();
                this.Down.SetActive(true);
                this.transform.Translate(0f, -PlayerStats.PlayerMoveSpeed * Time.deltaTime, 0f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.Reset();
                this.Left.SetActive(true);
                this.transform.Translate(-PlayerStats.PlayerMoveSpeed * Time.deltaTime, 0f, 0f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.Reset();
                this.Right.SetActive(true);
                this.transform.Translate(PlayerStats.PlayerMoveSpeed * Time.deltaTime, 0f, 0f);
            }
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PirateShip" && this.Scene.name == "MainScene")
        {
            X = this.gameObject.transform.position.x;
            Y = this.gameObject.transform.position.y;

            EnemyManager.Enemy = col.gameObject.name;
            SceneManager.LoadScene("BattleScene");
        }
    }
}