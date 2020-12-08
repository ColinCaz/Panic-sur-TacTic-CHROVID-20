using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplodeAfter(delay));
    }

    IEnumerator ExplodeAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (transform.position.y < 1)
        {
            Explode();
        }
        else
        {
            while (transform.position.y > 1)
            {
                yield return new WaitForSeconds(0.1f);
            }
            Explode();
        }
    }

    void Explode(){

        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders=Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders){
            if (nearbyObject.name.Contains("PNJ")){
                GameObject capsule = nearbyObject.transform.GetChild(0).gameObject;
                GameObject brasdroit = capsule.transform.GetChild(0).gameObject;
                GameObject brasgauche = capsule.transform.GetChild(1).gameObject;
                List<GameObject> gameObjects = new List<GameObject>{capsule, brasdroit, brasgauche};
                
                foreach (GameObject item in gameObjects)
                {
                    Renderer rend = item.GetComponent<Renderer>();
                    rend.material.SetColor("_Color",Color.red);
                }
             
            }
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null){
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }
}
