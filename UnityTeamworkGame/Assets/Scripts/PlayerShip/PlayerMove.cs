using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public static string[] namesOfDestroyedObjects = new string[100];
    private int counter = 0;

    public GameObject Up;
    public GameObject Down;
    public GameObject Left;
    public GameObject Right;

    public GameObject UpLeft;
    public GameObject UpRight;
    public GameObject DownLeft;
    public GameObject DownRight;

    public Scene scene;

    public static float X;
    public static float Y;

    private void Start()
    {
        

        scene = SceneManager.GetActiveScene();
        if (scene.name == "MainScene")
        {
            this.gameObject.transform.position = new Vector3(X, Y, 0);
        }
        if (namesOfDestroyedObjects.Length > 0)
        {
            for (int i = 0; i < namesOfDestroyedObjects.Length; i++)
            {
                Destroy(GameObject.Find(namesOfDestroyedObjects[i]));
            }
        }
        this.Reset();
        this.Up.SetActive(true);
    }

    private void Update()
    {
        Debug.Log(X);
        if (!PlayerShip.IsDead)
        {
            if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)))
            {
                this.Reset();
                this.UpRight.SetActive(true);
                this.transform.Translate(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            }
            else if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)))
            {
                this.Reset();
                this.UpLeft.SetActive(true);
                this.transform.Translate(-0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            }
            else if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)))
            {
                this.Reset();
                this.DownRight.SetActive(true);
                this.transform.Translate(0.5f * Time.deltaTime, -0.5f * Time.deltaTime, 0);
            }
            else if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)))
            {
                this.Reset();
                this.DownLeft.SetActive(true);
                this.transform.Translate(-0.5f * Time.deltaTime, -0.5f * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                this.Reset();
                this.Up.SetActive(true);
                this.transform.Translate(0, 0.5f * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.Reset();
                this.Down.SetActive(true);
                this.transform.Translate(0, -0.5f * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.Reset();
                this.Left.SetActive(true);
                this.transform.Translate(-0.5f * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.Reset();
                this.Right.SetActive(true);
                this.transform.Translate(0.5f * Time.deltaTime, 0, 0);
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PirateShip" && scene.name == "MainScene")
        {
            namesOfDestroyedObjects[counter] = col.gameObject.name;
            counter++;
            X = this.gameObject.transform.position.x;
            Y = this.gameObject.transform.position.y;
            SceneManager.LoadScene("BattleScene");
        }
    }
}