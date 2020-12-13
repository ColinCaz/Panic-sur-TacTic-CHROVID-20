using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Substring(0, 4) != "Trig" && other.name.Substring(0, 5) != "Stock" && other.name != "GameObject")
        {
            //print("hit " + other.name);
            Destroy(gameObject);
        }
    }
}
