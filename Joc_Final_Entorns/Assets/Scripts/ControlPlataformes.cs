using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlataformes : MonoBehaviour
{
    public float speed;
    public bool dreta = false; //punt 3
    public bool esquerra = false;//punt 1
    public bool amunt = true; //punt 2
    public bool abaix = false; //punt4
    public Transform punt1;
    public Transform punt2;
    public Transform punt3;
    public Transform punt4;
    private float t;
    public float duration = 1;
    public float lerpValue = 0;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Mou());
    }

    // Update is called once per frame
    void Update()
    {
        duration++;
        Mou();



    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Point1")
        {
            dreta = false;
            esquerra = false;
            amunt = true;
            abaix = false;
        }
        if (other.gameObject.name == "Point2")
        {

            dreta = true;
            esquerra = false;
            amunt = false;
            abaix = false;
        }
        if (other.gameObject.name == "Point3")
        {
            dreta = false;
            esquerra = false;
            amunt = false;
            abaix = true;
        }
        if (other.gameObject.name == "Point4")
        {
            dreta = false;
            esquerra = true;
            amunt = false;
            abaix = false;
        }
    }



    IEnumerator Mou()
    {
        duration = 4;

        for (t = 0; t < duration; t += Time.deltaTime)
        {
            PlatformLocation();
            yield return null;
        }


    }

    private void PlatformLocation()
    {
        lerpValue += Time.deltaTime / speed;
        if (esquerra)
        {
            transform.position = Vector3.Lerp(this.transform.position, punt1.position, lerpValue);

        }
        else if (dreta)
        {
            transform.position = Vector3.Lerp(this.transform.position, punt3.position, lerpValue);
        }
        else if (amunt)
        {
            transform.position = Vector3.Lerp(this.transform.position, punt2.position, lerpValue);
        }
        else if (abaix)
        {
            transform.position = Vector3.Lerp(this.transform.position, punt4.position, lerpValue);
        }
        lerpValue = 0;
    }
}
