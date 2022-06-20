using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScriptBaldosas : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInParent<Puzzle4>().aversifunciona(other, this.name);
    }
}
