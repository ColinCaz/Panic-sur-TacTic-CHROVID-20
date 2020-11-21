using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contagion : MonoBehaviour
{
    // Stade de la maladie :
    //      0 -> non contaminé
    //      1 -> porteur sans symptôme
    //      2 -> éternuement à intervalle régulier
    //      3 -> enlève les masques des autres + fuit devant le joueur
    public int stade = 0;
    public float radiusArea = 5.0f;
    public float timeBetweenCough = 5.0f;
    private float timePassed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (stade > 1)
        {
            timePassed += Time.deltaTime;
            if (timePassed > timeBetweenCough)
            {
                timePassed = 0;
                Cough();
            }
        }
    }

    void Cough()
    {
        Collider[] insideColliders = Physics.OverlapSphere(transform.position, radiusArea);

        foreach (Collider col in insideColliders)
        {
            Contagion script = col.transform.parent.gameObject.GetComponent<Contagion>();
            if (script)
                script.GetInfected();
        }
    }

    void GetInfected()
    {
        if (stade < 3)
            stade++;
    }
}
/*
 Public GameObject objectToAccess;
// drag the object you're calling a method on into the inspector, or alternatively use GameObject.Find to get a handle on it
 
ScriptName scriptToAccess = objectToAccess.GetComponent<ScriptName>();
// get the script on the object (make sure the script is a public class)      
 
scriptToAccess.YourMethodName(your parameters etc);
// calls the method in the script on the other object.
*/