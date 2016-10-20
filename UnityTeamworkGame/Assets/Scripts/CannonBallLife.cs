using UnityEngine;

public class CannonBallLife : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Border")
        {
            MonoBehaviour.Destroy(this.gameObject);
        }
    }
}