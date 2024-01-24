using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timing : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(audioSource.clip.length + 1);
        audioSource.Play();
        StartCoroutine(DelayTimer(audioSource.clip.length));
    }    
    private IEnumerator DelayTimer(float DT)
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(DT);
        Debug.Log("End");
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
