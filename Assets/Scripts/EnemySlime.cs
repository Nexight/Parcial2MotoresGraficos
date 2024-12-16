using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    public GameObject target;

    float exponencial = 1;
    void Start()
    {
        StartCoroutine(Crecer());
    }

    private IEnumerator Crecer()
    {
        float delay = 2;
        transform.localScale += new Vector3(1, 1, 1);
        exponencial += 1;
        yield return new WaitForSeconds(delay);
        StartCoroutine(Crecer());
    }   

    
}
