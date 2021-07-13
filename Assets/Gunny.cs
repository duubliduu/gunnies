using UnityEngine;

public class Gunny : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movement = 0f;

    public Gun gun;
    public bool isGrounded = true;
    public float speed = 5f;
    public float jumpStrength = 5f;
    public float jumpOffset = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(speed * movement, rb.velocity.y);
    }

    private void FixedUpdate()
    {
        if (!isGrounded && jumpOffset > 0d)
        {
            jumpOffset -= Time.deltaTime;
        }
    }

    public void Move(float movementInput)
    {
        movement = movementInput;
    }

    public void Jump()
    {
        if (isGrounded || jumpOffset > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            jumpOffset = 0;
        }
    }

    public void Aim(float angle, bool isFacingRight)
    {
        gun.isFacingRight = isFacingRight;
        gun.angle = angle;
    }

    public void Fire()
    {
        gun.Fire();
    }

    public void ReleaseFire()
    {
        gun.ReleaseFire();
    }

    public void Reload()
    {
        gun.Reload();
    }

    public void ReleaseReload()
    {
        gun.ReleaseReload();
    }
}
