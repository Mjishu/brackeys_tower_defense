using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public int Value = 25;

    public GameObject deathEffect;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        PlayerStats.Money += Value;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity); //todo DRAG THE deathEffect onto this in the Unity UI !IMPORTANT
        Destroy(effect, 5f);
    }
}
