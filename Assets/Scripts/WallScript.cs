using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallScript : MonoBehaviour
{

    private AudioSource source;


    public void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(eh());
    }


   IEnumerator  eh()
    {
        Time.timeScale = 0.0f;
        source.Play();
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
