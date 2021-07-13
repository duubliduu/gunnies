using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    Gunny gunny;

    // Start is called before the first frame update
    void Start()
    {
        gunny = transform.parent.gameObject.GetComponent<Gunny>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gunny.isGrounded = true;
        // reset jump offset
        gunny.jumpOffset = 0.25f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        gunny.isGrounded = false;
    }
}
