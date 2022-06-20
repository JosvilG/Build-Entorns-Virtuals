using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPuzzle5 : MonoBehaviour
{
    public GameObject Player;
    public GameObject ColliderEmputxar;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arma")
        {
            Physics.IgnoreCollision(Player.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
