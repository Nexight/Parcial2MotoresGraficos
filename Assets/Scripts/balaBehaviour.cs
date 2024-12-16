using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Speed of the projectile
    public float lifetime = 5f; // How long the projectile lasts before being destroyed

    void Start()
    {
        // Destroy the projectile after a set time
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the projectile forward
        transform.position += transform.forward * speed * Time.deltaTime;
    }
   
    void OnCollisionEnter(Collision collision)
    {
       if(collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}

