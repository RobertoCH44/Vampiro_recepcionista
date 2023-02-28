using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoDelCalamar : MonoBehaviour
{

    public AudioSource luzVerde;
    public GameObject demon,damageArea;
    public GameObject player;
    PlayerController playerController;
    public bool attack,attacking;

    void Start()
    {
        StartCoroutine(OpenDemon(3.0f));
        playerController = player.GetComponent<PlayerController>();

    }

    public void Update()
    {
        if(attack && playerController.horizontal != 0)
        {
            if (!attacking)
            {
                attacking = true;
                Instantiate(damageArea, player.transform.position, Quaternion.identity);
            }
        }
    }

    IEnumerator OpenDemon(float waitTime)
    {
        while (true)
        {
            attack = false;
            attacking = false;
            demon.SetActive(false);
            luzVerde.Play();
            yield return new WaitWhile(() => luzVerde.isPlaying);
            demon.SetActive(true);
            luzVerde.Stop();
            attack = true;
            yield return new WaitForSeconds(waitTime);
        }
    }
}