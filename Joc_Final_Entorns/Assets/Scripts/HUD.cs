using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Text VidaText;
    Text ClausText;
    Text FletxesText;
    Text orbeNum1;
    Text orbeNum2;
    Text orbeNum3;
    Text orbeNum4;
    
    public Image Espasa;
    public Image EspasaDes;
    public Image Arc;
    public Image ArcDes;
    public Image Bum;
    public Image BumDes;
    public Image fletxa;

    public static int vida=100;
    public static int maxVida = 100;
    public static int numClaus = 0;
    public static int numFletxes = 40;
    public static int maxFletxes = 40;
    public static bool estatEspasa;
    public static bool estatBum;
    public static bool estatArc;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        if(this.name== "VidaText")
        {
            VidaText = GetComponent<Text>();
            healthBar.SetMaxHealth(maxVida);
        }
        if (this.name == "ClausText")
        {
            ClausText = GetComponent<Text>();
        }
        if (this.name == "NumeroFletxes")
        {
            FletxesText = GetComponent<Text>();
        }
        if (this.name == "ControlEspasa")
        {
            Espasa.enabled = false;
            EspasaDes.enabled = false;
        }
        if (this.name == "ControlBum")
        {
            Bum.enabled = false;
            BumDes.enabled = false;
        }
        if (this.name == "ControlArc")
        {
            Arc.enabled = false;
            ArcDes.enabled = false;
        }
        if (this.name == "ControlFletxa")
        {
            fletxa.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackControl.getEspasa == true && this.name == "ControlEspasa")
        {
            if (estatEspasa == true)
            {
                Espasa.enabled = true;
                EspasaDes.enabled = false;
            }
            else if(estatEspasa == false)
            {
                Espasa.enabled = true;
                EspasaDes.enabled = true;
            }
            
        }

        if (AttackControl.getArc == false)
        {
            if (this.name == "NumeroFletxes")
            {
                FletxesText.GetComponent<Text>().enabled = false;
            }
        }
        if (AttackControl.getArc == true && this.name == "ControlFletxa")
        {
            fletxa.enabled = true;
        }
            if (AttackControl.getArc == true && this.name == "ControlArc")
        {
            
            if (this.name == "NumeroFletxes")
            {
                FletxesText.GetComponent<Text>().enabled = true;
                FletxesText.text = "Fletxes: " + numFletxes;
            }

            if (estatArc == true)
            {
                Arc.enabled = true;
                ArcDes.enabled = false;
            }
            else
            {
                Arc.enabled = false;
                ArcDes.enabled = true;
            }
        }

        if (AttackControl.getArc == true && this.name == "NumeroFletxes" && estatArc == true)
        {
            FletxesText.GetComponent<Text>().enabled = true;
            FletxesText.text = "" + numFletxes;
        }

        if (this.name == "NumeroFletxes" && estatArc == false)
        {
            FletxesText.GetComponent<Text>().enabled = false;
        }
        if (AttackControl.getBumerang == true && this.name == "ControlBum")
        {
            if (estatBum == true)
            {
                Bum.enabled = true;
                BumDes.enabled = false;
            }
            else
            {
                Bum.enabled = false;
                BumDes.enabled = true;
            }
        }
        if (vida < 0)
        {
            vida = 0;
            vida = maxVida;
        }
        if (this.name == "VidaText")
        {
            VidaText.text = "Vida: " + vida;
            healthBar.SetHealth(vida);
        }
       
        if (this.name == "ClausText")
        {
            ClausText.text = "X " + numClaus;
        }
        if(this.name == "NumeroFletxes")
        {
            FletxesText.text = "" + numFletxes;
        }
        
    }
}
