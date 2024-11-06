using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private Enemy enemy;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(enemy.speed * Time.deltaTime * direction.normalized, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= waypoints.points.Length - 1)
        {

            return;
        }
        wavepointIndex++;
        target = waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        Destroy(gameObject);
        PlayerStats.Lives -= 1;
        WaveSpawner.EnemiesAlive--;
    }
}
