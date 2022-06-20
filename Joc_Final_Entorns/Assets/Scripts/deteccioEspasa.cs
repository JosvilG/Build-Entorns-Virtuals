using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deteccioEspasa : MonoBehaviour
{
    public static bool atacant = false;
    public static int DanyCausat;
    public int dany;
    float distancia;
    public float speed = 3;
    public EnemicControler en;
    public Rigidbody rb;
    Transform target;
    Transform enemyTransform;
    Collision enemic;

    void Start()
    {
        dany = AttackControl.daño;
    }

    void Update()
    {
        if (EnemyAI.knockback == true && enemyTransform!=null && AttackControl.Espasa==true)
        {

            target = GameObject.FindWithTag("Player").transform;
            distancia = Vector3.Distance(target.position, transform.position);
            Vector3 targetHeading = target.position - transform.position;
            Vector3 targetDirection = targetHeading.normalized;

            transform.rotation = Quaternion.LookRotation(targetDirection);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            enemyTransform.position -= enemyTransform.forward * (speed * 2) * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        DanyCausat = dany;
        if (other.collider.tag == "enemic" && atacant == true && EnemyAI.debil==true)
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            enemyTransform = other.gameObject.GetComponent<Transform>();
            
            enemic = other;
            EnemyAI.knockback = true;
                
            en = other.gameObject.GetComponent<EnemicControler>();
            en.perdreVida(dany);
            //EnemicControler.tocat = true;
            
        }
        
    }

    void OnCollisionStay(Collision other)
    {
        if (other.collider.tag == "enemic" && atacant == true && EnemyAI.debil == true)
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            enemyTransform = other.gameObject.GetComponent<Transform>();

            enemic = other;
            EnemyAI.knockback = true;
            //en = GameObject.FindGameObjectWithTag("enemic").GetComponent<EnemicControler>();
            en = other.gameObject.GetComponent<EnemicControler>();
            en.perdreVida(dany);
            //EnemicControler.tocat = true;

        }

    }

    void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == "enemic" && atacant == true && EnemyAI.debil == true)
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            enemyTransform = other.gameObject.GetComponent<Transform>();

            enemic = other;
            EnemyAI.knockback = true;
            //en = GameObject.FindGameObjectWithTag("enemic").GetComponent<EnemicControler>();
            en = other.gameObject.GetComponent<EnemicControler>();
            en.perdreVida(dany);
            //EnemicControler.tocat = true;

        }

    }

}
