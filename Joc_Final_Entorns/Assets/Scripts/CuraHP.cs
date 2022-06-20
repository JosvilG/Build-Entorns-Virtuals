using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuraHP : MonoBehaviour
{

    public int hp;//defineix quanta hp torna el item
    public int augm;//defineix quanta vida permanent afegeix el item
    public bool perma=false;
    public bool fletxes = false;
    public bool permaFletxes = false;
 

    void OnTriggerEnter(Collider other)//defineix si toca el jugador
    {
        if (other.tag == "Player" && this.tag!="orbe")
        {
            if (perma == true)//Tria el tipus de objecte que es
            {
                AumentaHPperm(augm);
            }
            if (perma==false)
            {
                recuperaVida(hp);
            }if(fletxes == true)
            {
                recuperaFletxes(hp);
            }
            if (permaFletxes == true)
            {
                AumentaFletperm();
            }
            
        }
        
    }

    void recuperaVida(int hp)//comprova si el jugador te el maxim de hp i si no ho te el cura. En cas de que es curi mes del maxim de hp que te li ajusta a la maxima que pot tenir
    {
       
        if (HUD.vida < HUD.maxVida)
        {
            HUD.vida += hp;
            if (HUD.vida > HUD.maxVida)
            {
                HUD.vida = HUD.maxVida;
            }
            Destroy(this.gameObject);
            Debug.Log(HUD.vida);
        }
        else
        {
            Debug.Log("vida al max");
        }
        
        

        
    }

    void recuperaFletxes(int hp)//comprova si el jugador te el maxim de hp i si no ho te el cura. En cas de que es curi mes del maxim de hp que te li ajusta a la maxima que pot tenir
    {

        if (HUD.numFletxes < HUD.maxFletxes)
        {
            HUD.numFletxes += hp;
            if (HUD.numFletxes > HUD.maxFletxes)
            {
                HUD.numFletxes = HUD.maxFletxes;
            }
            Destroy(this.gameObject);
            Debug.Log(HUD.numFletxes);
        }
        else
        {
            Debug.Log("fletxes al max");
        }




    }

    void AumentaHPperm(int augm)//Augmenta de forma permanent la hp del jugador
    {
        HUD.maxVida += augm;
        HUD.vida = HUD.maxVida;
        Debug.Log("Ara la vida es: "+ HUD.vida);
        this.gameObject.SetActive(false);
    }

    void AumentaFletperm()
    {
        HUD.maxFletxes += augm;
        HUD.numFletxes = HUD.maxFletxes;
        Debug.Log("Ara el maxim de fletxes es: " + HUD.numFletxes);
        this.gameObject.SetActive(false);
    }


}
