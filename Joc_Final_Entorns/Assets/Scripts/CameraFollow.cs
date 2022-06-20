
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //objectiu de la camara
    /*public Transform target;

    //Ha d'estar entre 0 i 1
    public float smoothSpeed = 0.125f;

    //Aquest vector determina la posició de la camara
    public Vector3 offset;
    //el personatge ha de moure's avans que la camara per tant es fa lateupdate
    void FixedUpdate()
    {
        Vector3 posObjectiu = target.position + offset;
        Vector3 posSmooth = Vector3.Lerp(transform.position, posObjectiu, smoothSpeed * Time.deltaTime);
        transform.position = posSmooth;

        transform.LookAt(target);
    }*/
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    private void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }

}
