using NUnit.Framework.Constraints;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public int Value = 25;

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public GameObject deathEffect;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    public void Slow(float amount) //11:50
    {
        speed = startSpeed * (1f - amount);
    }

    void Die()
    {
        Destroy(gameObject);
        PlayerStats.Money += Value;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity); //todo DRAG THE deathEffect onto this in the Unity UI !IMPORTANT
        Destroy(effect, 5f);
    }
}
