using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 3f;

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
        health -= damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
