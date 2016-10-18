using UnityEngine;
using System.Collections;

public class PirateCannon : MonoBehaviour
{
    public Rigidbody2D CannonBalls;
    public Transform Cannon;
    public GameObject Player;

    private void Start()
    {
        this.StartCoroutine(this.ShotRandom());
    }

    private void Update()
    {
        var dir = this.Player.transform.position - this.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    IEnumerator ShotRandom()
    {
        while (!PlayerShip.IsDead)
        {
            yield return new WaitForSeconds(Random.Range(1, 1));
            Rigidbody2D cannon;
            cannon = Instantiate(this.CannonBalls, this.Cannon.position, this.Cannon.rotation) as Rigidbody2D;
            cannon.AddForce(this.Cannon.right * 50f);
        }
    }
}