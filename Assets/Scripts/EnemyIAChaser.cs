using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIAChaser : MonoBehaviour
{
    private float speed;
    public float MaxSpeed;

    private Collider[] hitColliders;
    private RaycastHit Hit;

    public float sightRange;
    public float detectionRange;

    public Rigidbody rb;
    public GameObject target;

    private bool seePlayer;

    // Start is called before the first frame update
    void Start()
    {
        speed = MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //detectar al player
        if (!seePlayer)
        {
            hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
            foreach(var hitCollider in hitColliders )
            {
                if(hitCollider.tag=="Player")
                {
                    target = hitCollider.gameObject;
                    seePlayer = true;
                }
            }
        }
        else
        {
            if(Physics.Raycast(transform.position,(target.transform.position-transform.position),out Hit,sightRange))
            {
                if (Hit.collider.tag!="Player")
                {
                    seePlayer = false;
                }else
                {
                    //calcular la direccion
                    var heading = target.transform.position - transform.position;
                    var distance = heading.magnitude;
                    var direction = heading / distance;

                    //moverse hacia el player
                    Vector3 move = new Vector3(direction.x*speed, 0, direction.z*speed);
                    rb.velocity = move;
                    transform.forward = move;
                }
            }
        }
        
            

    }

    
}
