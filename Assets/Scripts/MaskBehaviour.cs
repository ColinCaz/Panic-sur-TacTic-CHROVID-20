using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Substring(0, 7) != "Trigger")
        {
            //print("hit " + other.name);
            Destroy(gameObject);
        }
    }
}
