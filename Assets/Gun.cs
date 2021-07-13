using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    private float cumulativeRecoil = 0f;

    public GameObject bullet;
    public GameObject gunny;
    public float angle = 0f;
    public float active = 0f;
    public bool isReady = true;
    public float speed = 100f;
    public float rof = 0.25f;
    public bool isAutomatic = true;
    public int magazineCapasity = 30;
    public int rounds = 30;
    public int available = 120;
    public bool isReloadReady = true;
    public bool isFacingRight = true;
    public float recoil = 20f;
    public float skill = 50f;

    void Update()
    {
        RotateToAngle();
        FlipToDirection();
        CompensateRecoil();
    }

    void CompensateRecoil()
    {
        float distance = Vector3.Distance(transform.position, gunny.transform.position);
        float angleBetween = Utility.GetAngleBetween(transform.position, gunny.transform.position);
        transform.position += Utility.GetVelocityToAngle(angleBetween, distance/2);
    }

    void FlipToDirection()
    {
        if (isFacingRight)
        {
            transform.localScale = new Vector2(2f, 2f);
        }
        else
        {
            transform.localScale = new Vector2(2f, -2f);
        }
    }

    void RotateToAngle()
    {
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg + cumulativeRecoil, Vector3.forward);
    }

    private void FixedUpdate()
    {
        if (active > 0)
        {
            active -= Time.deltaTime;
        }
        else 
        {
            active = 0f;
        }
    }

    public void Fire()
    {
        if ((isAutomatic || isReady) && rounds > 0 && active == 0f)
        {
            rounds--;

            SpawnBullet();

            active = rof;
            isReady = false;
        }
    }

    private void SpawnBullet()
    {
        float distribution = recoil - (skill / 100 * recoil);
        cumulativeRecoil += Random.Range(-distribution / 2, distribution / 2);

        // Move the gun
        transform.position -= Utility.GetVelocityToAngle(angle, distribution / 100);

        // Spawn the bullet
        GameObject item = Instantiate(bullet, transform.position, transform.rotation);
        float adjustedAngle = angle + cumulativeRecoil * Mathf.Deg2Rad;

        // Add velocity
        item.GetComponent<Rigidbody2D>().velocity = Utility.GetVelocityToAngle(adjustedAngle, speed);
    }

    public void Reload()
    {
        isReloadReady = false;

        int missingAmmo = magazineCapasity - rounds;

        if (available > missingAmmo)
        {
            available -= missingAmmo;
            rounds = magazineCapasity;
        }
        else
        {
            rounds = available;
            available = 0;
        }
    }

    public void ReleaseFire()
    {
        isReady = true;
        cumulativeRecoil = 0f;
    }

    public void ReleaseReload()
    {
        isReloadReady = true;
    }
}
