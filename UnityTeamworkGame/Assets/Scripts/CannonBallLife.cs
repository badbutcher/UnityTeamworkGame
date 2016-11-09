using UnityEngine;

public class CannonBallLife : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 10);
    }
}