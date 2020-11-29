﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coop : MonoBehaviour
{
    public AudioSource source;

    //a enlever si on fait vraiment un coop
    public GameObject player;
    public GameObject blue;
    public GameObject green;
    public GameObject blueMasked;
    public GameObject greenMasked;

    private bool go = true;
    private int masked = 2;
    private bool jump = true;
    private bool stop = false;

    void Start()
    {
        source.volume = (float)PlayerPrefs.GetInt("VolumeMusiques") / 400;
    }

    void Update()
    {
        source.volume = (float)PlayerPrefs.GetInt("VolumeMusiques") / 400;

        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(0, 180, 5 - Mathf.PingPong(Time.time * 10, 10)), Time.time * 10); //Quaternion.Euler(0, 180, Mathf.PingPong(Time.time * 10, 10) - 5);

        if (jump)
        {
            //player.transform.position = new Vector3(player.transform.position.x, -2.5f + Mathf.PingPong(Time.time * 2, 1), player.transform.position.z);
            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(5, -2.5f + Mathf.PingPong(Time.time * 2, 1), 0), Time.time * 2);
            if (!stop)
            {
                StartCoroutine(StopJump());
            }
        }
        else
        {
            if (!stop)
            {
                StartCoroutine(Jump());
            }
        }

        if (go)
        {
            StartCoroutine(Run());
        }
        else
        {
            if (masked == 1)
            {
                blueMasked.transform.position += Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(2.5f, 0, 0), Time.deltaTime);
                greenMasked.transform.position += Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(2.5f, 0, 0), Time.deltaTime);
                if (greenMasked.transform.position.x > 10)
                {
                    blueMasked.transform.position = new Vector3(-10, 1, 50);
                    greenMasked.transform.position = new Vector3(-13, 1, 50);
                    go = true;
                }
            }
            else if (masked == 0)
            {
                blue.transform.position += Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(2.5f, 0, 0), Time.deltaTime);
                green.transform.position += Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(2.5f, 0, 0), Time.deltaTime);
                if (green.transform.position.x > 10)
                {
                    blue.transform.position = new Vector3(-10, 1, 25);
                    green.transform.position = new Vector3(-12, 1, 25);
                    go = true;
                }
            }
        }
    }

    IEnumerator Jump()
    {
        stop = true;
        yield return new WaitForSeconds(Random.Range(0, 10));
        jump = true;
        stop = false;
    }

    IEnumerator StopJump()
    {
        stop = true;
        yield return new WaitForSeconds(0.9f);
        jump = false;
        stop = false;
    }

    IEnumerator Run()
    {
        go = false;
        masked = 2;
        yield return new WaitForSeconds(Random.Range(0, 5));
        masked = (int)Random.Range(0.5f, 1.5f);
        if (masked == 0)
        {
            yield return new WaitForSeconds(Random.Range(0, 0.5f));
            blue.transform.position += new Vector3(0, 1 - blue.transform.position.y, 0);
            yield return new WaitForSeconds(Random.Range(0, 0.5f));
            green.transform.position += new Vector3(0, 1 - green.transform.position.y, 0);
        }
        else if (masked == 1)
        {
            yield return new WaitForSeconds(Random.Range(0, 0.5f));
            blueMasked.transform.position += new Vector3(0, 1 - blueMasked.transform.position.y, 0);
            yield return new WaitForSeconds(Random.Range(0, 0.5f));
            greenMasked.transform.position += new Vector3(0, 1 - greenMasked.transform.position.y, 0);
        }
    }
}
