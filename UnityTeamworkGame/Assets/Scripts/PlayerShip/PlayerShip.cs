using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    public static bool IsDead;
    public float PlayerHealth;
    public Animator Ani;

    private void Start()
    {
        this.PlayerHealth = 20;
    }

    private void Update()
    {
        if (this.PlayerHealth <= 0)
        {
            this.Ani.Play("Explode");
            IsDead = true;
        }
        if (PirateShip.BattleWon)
        {
            StartCoroutine(Load());
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PirateCannonBall")
        {
            MonoBehaviour.Destroy(col.gameObject);
            this.PlayerHealth -= 10;
        }
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainScene");
    }
}
