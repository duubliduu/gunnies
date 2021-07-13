using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 previousPosition;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Linecast(previousPosition, transform.position);

        if (hit.collider != null)
        {
            // Remove self if we hit anything
            if (hit.collider.name != "Gunny")
            {
                Destroy(gameObject);
            }

            Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();

            if (enemy != null) { 
                enemy.TakeDamage(1f * rb.velocity.magnitude);
            }
        }
    }

    private void FixedUpdate()
    {
        previousPosition = transform.position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(previousPosition, transform.position);
    }

    private void OnBecameInvisible()
    {
       Destroy(gameObject);
    }
}