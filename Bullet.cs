using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public float _launchForce = 90f;
    public float lifetime = 3f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        rb.AddForce(_launchForce * transform.forward);
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (collision.rigidbody != null)
            {
                collision.rigidbody.AddForce(-collision.contacts[0].normal * _launchForce);
            }
        }
        Destroy(gameObject);
    }
}
