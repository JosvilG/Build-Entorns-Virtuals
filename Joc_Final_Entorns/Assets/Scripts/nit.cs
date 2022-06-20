using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nit : MonoBehaviour
{

    public Light llumCel;
    public Color ColorNit;
    public Color ColorDia;
    // Start is called before the first frame update
    void Start()
    {

        ColorNit = new Color(0.074f, 0.11f, 0.22f, 1);
        ColorDia = new Color(1.0f, 0.83f, 0.53f);


    }

    // Update is called once per frame
    void Update()
    {
        if (canviaEscena.nit)
        {
            llumCel.color = ColorNit;
        }
        if (!canviaEscena.nit)
        {
            llumCel.color = ColorDia;
        }
    }
}
