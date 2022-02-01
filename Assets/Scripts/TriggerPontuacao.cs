using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerPontuacao : MonoBehaviour
{
    public int pontos;
    public Text placar;
    public AudioClip clip;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        pontos++;
        Bola bola = coll.gameObject.GetComponent<Bola>();
        if(bola != null)
        {
            coll.transform.position = Vector3.zero;
            bola.direction.x = bola.direction.x * -1;
            placar.text = "" + pontos;
            audioSource.Play();
        }
    }
}
