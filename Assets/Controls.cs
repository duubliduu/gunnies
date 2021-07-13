using UnityEngine;

public class Controls : MonoBehaviour
{
    Gunny gunny;

    private void Start()
    {
        gunny = transform.parent.GetComponent<Gunny>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jump
        if (Input.GetButton("Jump"))
        {
            gunny.Jump();
        }

        // Move
        float movement = Input.GetAxisRaw("Horizontal");
        gunny.Move(movement);

        // Aim
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        float angleRad = Utility.GetAngleBetween(pos, Input.mousePosition);
        bool isFacingRight = Input.mousePosition.x > pos.x;
        gunny.Aim(angleRad, isFacingRight);

        // Fire
        if (Input.GetButton("Fire1"))
        {
            gunny.Fire();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            gunny.ReleaseFire();
        }

        // Reload
        if (Input.GetButton("Fire2"))
        {
            gunny.Reload();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            gunny.ReleaseReload();
        }
    }

    void OnDrawGizmos()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, dir);
    }
}
