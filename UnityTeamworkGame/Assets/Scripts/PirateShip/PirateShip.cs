using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PirateShip : MonoBehaviour
{
    public static bool BattleWon;
    public float Health;
    public Animator Ani;

    private void Start()
    {
        this.Health = 20;
    }

    private void Update()
    {
        if (this.Health <= 0)
        {
            BattleWon = true;
            this.Ani.Play("Explode");
            
            MonoBehaviour.Destroy(this.gameObject, 0.52f);

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerCannonBall")
        {
            MonoBehaviour.Destroy(col.gameObject);
            this.Health -= 10;
        }
    }

   
}