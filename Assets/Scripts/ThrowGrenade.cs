using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public int grenadeSpeed = 10;
    public Transform grenadeSpawn;
    public GameObject grenadePrefab;
    public GameObject epaule;
    public GameObject player;
    public GameObject grenadeEnMain;

    bool throwing = false;
    int etape = 1;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("MunGrenade", 0) > 0 && !throwing)
        {
            grenadeEnMain.SetActive(true);
            if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
            {
                throwing = true;
            }
        }
        else if(!throwing)
        {
            grenadeEnMain.SetActive(false);
        }
        if (throwing && Time.timeScale!=0)
        {
            float playerX;
            if (player.transform.rotation.eulerAngles.x > 180)
            {
                playerX = player.transform.rotation.eulerAngles.x - 360;
            }
            else
            {
                playerX = player.transform.rotation.eulerAngles.x;
            }
            float epauleZ;
            if (epaule.transform.rotation.eulerAngles.z > 180)
            {
                epauleZ = epaule.transform.rotation.eulerAngles.z - 360;
            }
            else
            {
                epauleZ = epaule.transform.rotation.eulerAngles.z;
            }
            if (etape == 1)
            {
                if (epauleZ <  30 + playerX && epauleZ > -15 + playerX)
                {
                    epaule.transform.Rotate(0, 0, (30 + playerX) * Time.deltaTime * 5, Space.Self);
                }
                else
                {
                    etape++;
                }
            }
            if (etape == 2)
            {
                if (epauleZ < 45 + playerX && epauleZ > -40 + playerX)
                {
                    epaule.transform.Rotate(0, 0, -(70 + playerX) * Time.deltaTime * 5, Space.Self);
                }
                else
                {
                    etape++;
                    PlayerPrefs.SetInt("MunGrenade", PlayerPrefs.GetInt("MunGrenade", 0) - 1);
                    Throw();
                }
            }
            if (etape == 3)
            {
                if (epauleZ < 45 + playerX && epauleZ > -70 + playerX)
                {
                    epaule.transform.Rotate(0, 0, -(30 + playerX) * Time.deltaTime * 5, Space.Self);
                }
                else
                {
                    etape++;
                }
            }
            if (etape == 4)
            {
                if (epauleZ < 0 + playerX && epauleZ > -85 + playerX)
                {
                    epaule.transform.Rotate(0, 0, (70 + playerX) * Time.deltaTime * 5, Space.Self);
                }
                else
                {
                    if (PlayerPrefs.GetInt("MunGrenade", 0) > 0)
                    {
                        grenadeEnMain.SetActive(true);
                    }
                    throwing = false;
                    etape = 1;
                }
            }
        }
    }

    private void Throw()
    {
        GameObject grenade = Instantiate(grenadePrefab);
        grenade.transform.position = grenadeSpawn.position;
        grenade.GetComponent<Rigidbody>().AddRelativeForce(grenadeSpawn.forward * grenadeSpeed, ForceMode.Impulse);
        grenadeEnMain.SetActive(false);
    }
}
