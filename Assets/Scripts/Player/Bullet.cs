using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    [HideInInspector] public float damageAmount = 10f;
    private Vector3 direction;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirectionAndSpeed(Vector3 newDirection, float newSpeed=10, float damage=1)
    {
        direction = newDirection.normalized;
        speed = newSpeed;
        damageAmount = damage;
    }

    void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damageAmount);
        }
        Destroy(gameObject);
    }
}
