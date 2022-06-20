using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    Transform enemyTransform;
    public float speed = 3;
    public float rotationSpeed = 3;
    public float detectionRange = 5f;
    public static bool potSeguir = false;
    float distancia;
    public bool noEsPuzzle;
    public static bool knockback = false;
    public static bool debil = true;//Determina si el enemic pot ser atacar una altra vegada

    // Use this for initialization
    void Start()
    {
        enemyTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;

        distancia = Vector3.Distance(target.position, transform.position);
        Vector3 targetHeading = target.position - transform.position;
        Vector3 targetDirection = targetHeading.normalized;
        if (knockback == true)
        {
            debil = false;
            /*transform.rotation = Quaternion.LookRotation(targetDirection);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            enemyTransform.position -= enemyTransform.forward * (speed * 2) * Time.deltaTime;*/
            StartCoroutine(goBack());
            
        }
        else
        {
            //Debug.Log(distancia);
            if (distancia <= detectionRange && potSeguir == true)
            {
                transform.rotation = Quaternion.LookRotation(targetDirection);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                enemyTransform.position += enemyTransform.forward * speed * Time.deltaTime;
            }

            if (distancia <= detectionRange && noEsPuzzle == true)
            {
                transform.rotation = Quaternion.LookRotation(targetDirection);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                enemyTransform.position += enemyTransform.forward * speed * Time.deltaTime;
            }
        }
        

    }

    IEnumerator goBack()
    {
        /*distancia = Vector3.Distance(target.position, transform.position);
        Vector3 targetHeading = target.position - transform.position;
        Vector3 targetDirection = targetHeading.normalized;
        transform.rotation = Quaternion.LookRotation(targetDirection);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        enemyTransform.position -= enemyTransform.forward * (speed*2) * Time.deltaTime;*/
        yield return new WaitForSeconds(0.5f);
        knockback = false;
        debil = true;
    }
}

/*
 Rigidbody enemy = other.gameObject.GetComponent<Rigidbody>();
            if (enemy != null)
            {
                Vector3 difference = enemy.transform.position - posicioPJ.transform.position;
                difference = difference.normalized*thrust;
                enemy.AddForce(difference, ForceMode.Impulse);
                enemy.AddForce(this.transform.forward);
            }
     */
