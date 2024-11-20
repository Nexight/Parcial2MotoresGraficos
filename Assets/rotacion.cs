using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Velocidad de rotación

    void Update()
    {
        // Rotacio constante
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

