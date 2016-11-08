using UnityEngine;

public class CannonBallLife : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Border")
        {
            MonoBehaviour.Destroy(this.gameObject);
        }
    }
}