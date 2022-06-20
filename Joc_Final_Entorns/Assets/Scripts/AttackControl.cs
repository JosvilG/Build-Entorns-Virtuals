using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AttackControl : MonoBehaviour
{


    Animator anim;
    public static int daño = 30;
    public bool tocado = false;
    public static bool espasaToca = false;
    public GameObject boomerang;
    public GameObject ArcFletxes;
    private float segons;
    public static bool Espasa = true;
    public static bool bmrng = false;//boomerang
    public static bool fletxes = false;
    public static bool getEspasa = true;
    public static bool getBumerang = true;
    public static bool getArc = true;
    public AudioClip hitAudio;
    int id;
  
    // Start is called before the first frame update

    public Collider[] attackHitboxes;

    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && getEspasa==true)
        {
            HUD.estatEspasa = true;
            HUD.estatArc = false;
            HUD.estatBum = false;
            Espasa = true;
            bmrng = false;
            fletxes = false;
            daño = 30;
            
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && getArc==true)
        {
            HUD.estatEspasa = false;
            HUD.estatArc = true;
            HUD.estatBum = false;
            Espasa = false;
            bmrng = false;
            fletxes = true;
            daño = 100;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && getBumerang == true)
        {
            HUD.estatEspasa = false;
            HUD.estatArc = false;
            HUD.estatBum = true;
            Espasa = false;
            bmrng = true;
            fletxes = false;
            daño = 10;

        }
        if (Espasa)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (deteccioEspasa.atacant == false)
                {
                    AtaqueSimple(attackHitboxes[0]);
                    segons = 0.6f;
                    StartCoroutine(potAtacar());
                }

            }
        }
        if (bmrng)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (deteccioEspasa.atacant == false)
                {
                    TiraBoomerang();
                    segons = 1.0f;
                    StartCoroutine(potAtacar());
                }
            }
        }
        if (fletxes)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (deteccioEspasa.atacant == false && HUD.numFletxes>0)
                {
                    HUD.numFletxes--;
                    DisparaFletxes();
                    segons = 0.2f;
                    StartCoroutine(potAtacar());
                }
            }
        }

        /*  if (Input.GetKeyDown(KeyCode.E))
          {
              if(deteccioEspasa.atacant == false)
              {
                  TiraBoomerang();
                  segons = 1.0f;
                  StartCoroutine(potAtacar());
              }

          }*/


    }

    IEnumerator potAtacar()
    {
        deteccioEspasa.atacant = true;
        yield return new WaitForSeconds(segons);
        deteccioEspasa.atacant = false;
    }

    private void AtaqueSimple(Collider col)
    {
        anim.SetTrigger("Simple_Atack_Animation");
    }
   


    public void Defensa()
    {
      anim.SetBool("Defensa", true);
      anim.SetBool("QuitarDefensa", false);

    }

    public void QuitarDefensa()
    {
       anim.SetBool("Defensa", false);
       anim.SetBool("QuitarDefensa", true);
    }

    public void TiraBoomerang()
    {
        GameObject clone;
        clone = Instantiate(boomerang, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation) as GameObject;
        
    }

    public void DisparaFletxes()
    {
        GameObject clone;
        clone = Instantiate(ArcFletxes, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation) as GameObject;

    }
}
