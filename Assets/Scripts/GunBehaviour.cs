using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public GameObject maskPrefab;
    public Transform maskSpawn;

    public float maskSpeed = 30;
    public float lifeTime = 3;

    public float timeBetweenFire = 0.5f;
    private float timePassed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (Input.GetButton("Fire1") && timePassed > timeBetweenFire)
        {
            Fire();
            timePassed = 0.0f;
        }
    }

    private void Fire()
    {
        GetComponent<AudioSource>().Play();

        GameObject mask = Instantiate(maskPrefab);

        Physics.IgnoreCollision(mask.GetComponent<Collider>(), maskSpawn.parent.GetComponent<Collider>());

        mask.transform.position = maskSpawn.position;

        Vector3 rotation = mask.transform.rotation.eulerAngles;
        mask.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        mask.GetComponent<Rigidbody>().AddForce(maskSpawn.forward * maskSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyMaskAfterTime(mask, lifeTime));
    }

    private IEnumerator DestroyMaskAfterTime(GameObject mask, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(mask);
    }
}
