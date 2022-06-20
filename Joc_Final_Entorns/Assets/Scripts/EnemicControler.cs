using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemicControler : MonoBehaviour
{

    public int vida = 100;
    //public Collider b;
    public int id;
    public bool tocat = false;
    public static int contadorMorts = 0;//Morts totals en la escena actual
    public static int MortsTotals = 0;//Morts totals en tot el joc
    public int valorAtac;
    public static int AtacEnemic;
    public GameObject drop;//10 de hp
    public GameObject drop2;//5 fletxes
    [SerializeField]
    private GameObject model;
    public bool invencible = false;
    public static int minimMorts = 100000;
    public Transform pos;
    public bool conta;
    public AudioClip perdreHP;
    public AudioSource audio;
    public float volume;
    // public Collider EnemyCollider;
    //public Collider EnemyBlockerCollider;

    public void Start()
    {
        AtacEnemic = valorAtac;
       // Physics.IgnoreCollision(EnemyCollider, EnemyBlockerCollider, true);//Asegura que el enemic no es moura dle lloc quan xoqui amb el player ni pot atravessar parets
    }

    void Update()
    {
        if (tocat == true)
        {
            
            perdreVida(deteccioEspasa.DanyCausat);
            
        }
        if (vida <= 0)
        {
            
             MuerteEnemigo();
        }
        if (contadorMorts >= minimMorts)
        {
            ActivaSpawn.obrir = true;
        }
        
    }
    /*public void BaixarVida(int hp)
    {
        Debug.Log("-------------------");
        
            this.vida = this.vida - hp;
            Debug.Log(vida);
        tocat = false;

    }*/

    public void perdreVida(int hp)
    {
        if (invencible) return;
        
        this.vida = this.vida - hp;
        soPerdreHP();
        StartCoroutine(EnemicInv());

        tocat = false;
    }

    void soPerdreHP()
    {
        audio.PlayOneShot(perdreHP, volume);
    }

    //invencibilitat temporal
    private IEnumerator EnemicInv()
    {
        //Debug.Log("Enemy turned invincible!");
        invencible = true;
        
        for (float i = 0; i <= 2; i += 1)
        {
            // Alternate between 0 and 1 scale to simulate flashing
            if (model.transform.localScale == new Vector3(1.5f, 1.5f, 1.5f))
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(new Vector3(1.5f, 1.5f, 1.5f));
            }
            yield return new WaitForSeconds(0.1f);
        }

        //Debug.Log("Enemy is no longer invincible!");
        ScaleModelTo(new Vector3(1.5f, 1.5f, 1.5f));
        invencible = false;
        StopCoroutine(EnemicInv());
    }

    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }



    public void MuerteEnemigo()
    {
        int randomTria = Random.Range(1, 100);//10/100 de que doni hp i 2/100 de que doni fletxes 
        
            if (randomTria >=1 && randomTria <=10)
            {
                Instantiate(drop, pos.position, Quaternion.identity);
            }
            if (randomTria >=11 && randomTria <=12)
            {
                Instantiate(drop2, pos.position, Quaternion.identity);
            }
        

        if (conta == true)
        {
            
            contadorMorts++;
            Debug.Log("Enemic mort. Portes: " + contadorMorts);
        }

        Destroy(gameObject);
        MortsTotals++;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            
            PlayerControl.hit = true;
            this.GetComponent<Rigidbody>().isKinematic = true;

            //Debug.Log(Vida.vida);
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void AtaqueEnemigo(Collider col)
    {

        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
        foreach (Collider c in cols)
        {
            if (c.transform.parent.parent == transform)
            {

                continue;
            }


            switch (c.name)
            {
                case "player":

                    HUD.vida -= AtacEnemic;
                    Debug.Log("Tocado Player");
                    break;
                default:
                    Debug.Log("Miss");
                    break;
            }

        }

    }
}
