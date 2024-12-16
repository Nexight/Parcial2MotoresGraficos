using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    public GameObject target;
    public GameObject gameManager;
    public CharacterController characterController;
    public Transform[] plataformas;

    float exponencial = 1;
    float contador = 0f;

    void Start()
    {
        contador = 5f;
        StartCoroutine(Crecer());       
    }

    private void Update()
    {
        
        contador -= Time.deltaTime;
        if(contador<=0)
        {
            Teletransportacion();
            contador = 5f;
        }
    }

    private IEnumerator Crecer()
    {
        float delay = 5;
        transform.localScale += new Vector3(1, 1, 1);
        exponencial += 1;
       

        yield return new WaitForSeconds(delay);
        StartCoroutine(Crecer());
    }

    void Teletransportacion()
    {
        /*Debug.Log("tepeando");
        Transform plataformaCercana = plataformas[0];

        float distanciaMinima = Vector3.Distance(transform.localPosition, plataformas[0].position);

        foreach (Transform plataforma in plataformas)
        {
            float distancia = Vector3.Distance(transform.localPosition, plataforma.position);
            if (distancia < distanciaMinima)
            {
                plataformaCercana = plataforma;
                distanciaMinima = distancia;
                Debug.Log("Listo para tepear!");
            }
        }
        transform.localPosition = plataformaCercana.position;*/

        
    }
}
