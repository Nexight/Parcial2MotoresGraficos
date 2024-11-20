using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target; 
    public float range = 10f; 
    public GameObject projectilePrefab; 
    public Transform firePoint; // punto de origen de la bala
    public float fireRate = 1f; 
    public LineRenderer laserLine; // LineRenderer component para el laser

    private float fireCountdown = 0f;

    void Start()
    {
        if (!laserLine)
        {
            laserLine = gameObject.AddComponent<LineRenderer>();
            laserLine.startWidth = 0.05f;
            laserLine.endWidth = 0.05f;

            // Create and assign a new material
            Material laserMaterial = new Material(Shader.Find("Unlit/Color"));
            laserMaterial.SetColor("_Color", Color.red);
            laserLine.material = laserMaterial;

            // Set a color gradient
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.yellow, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
            );
            laserLine.colorGradient = gradient;
        }
    }

    void Update()
    {
        // Detect target
        if (Vector3.Distance(transform.position, target.position) <= range)
        {
            // Rotate turret towards the target
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            // Fire at the target
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;

            // Enable and set laser line positions
            laserLine.SetPosition(0, firePoint.position);
            laserLine.SetPosition(1, target.position);
            laserLine.enabled = true;
        }
        else
        {
            // Disable the laser when the target is out of range
            laserLine.enabled = false;
        }
    }
    void Shoot()
    {
        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Set the projectile's direction
        Vector3 direction = (target.position - firePoint.position).normalized;

        // Apply velocity to the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = direction * 10f; // Adjust speed as needed
    }
    void OnDrawGizmosSelected()
    {
        // dibuja el rango
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
