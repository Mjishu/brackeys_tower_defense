using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startHealth = 100;
    private float health;
    public int Value = 25;

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0f && !isDead)
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
        isDead = true;
        Destroy(gameObject);
        PlayerStats.Money += Value;

        WaveSpawner.EnemiesAlive--;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
    }
}
