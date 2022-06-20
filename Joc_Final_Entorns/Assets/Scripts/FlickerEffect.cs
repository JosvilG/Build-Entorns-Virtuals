using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerEffect : MonoBehaviour
{
    // Start is called before the first frame update

    private Light _llum;
    private float _minAlpha = 0.0f;
    private float _maxAlpha = 1.0f;

    void Start()
    {
        _llum = GetComponent<Light>();
        StartCoroutine(eternalflicker());
        
    }

    private IEnumerator eternalflicker()
    {
        while (true)
        {
            _minAlpha = _llum.intensity;
            _maxAlpha = Random.Range(0.0f, 1.0f);
            yield return StartCoroutine(Flicker());
        }
    }



    // Update is called once per frame

    void pampallugues(float _seg)
    {
        float Intensity = Mathf.Lerp(_minAlpha, _maxAlpha, _seg);
        _llum.intensity = Intensity;
    }
    private IEnumerator Flicker()
    {
        float duration = Random.Range(0.1f,0.5f);
        for (float _seg = 0; _seg < duration; _seg += Time.deltaTime)
        {
            pampallugues(_seg/duration);
            yield return null;
        }

    }

}
