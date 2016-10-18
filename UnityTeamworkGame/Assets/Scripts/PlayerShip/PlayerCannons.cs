using UnityEngine;

public class PlayerCannons : MonoBehaviour
{
    public Rigidbody2D CannonBalls;
    public Transform Cannon;

    private void Start()
    {
    }

    private void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody2D cannon;
            cannon = Instantiate(this.CannonBalls, this.Cannon.position, this.Cannon.rotation) as Rigidbody2D;
            cannon.AddForce(this.Cannon.right * 50f);
        }
    }
}