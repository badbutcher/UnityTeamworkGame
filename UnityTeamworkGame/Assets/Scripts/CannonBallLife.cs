using UnityEngine;

public class CannonBallLife : MonoBehaviour
{
    private void Update()
    {
        MonoBehaviour.Destroy(this.gameObject, 10f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Border")
        {
            MonoBehaviour.Destroy(this.gameObject);
        }
    }
}