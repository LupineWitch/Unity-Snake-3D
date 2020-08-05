using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BodyScript : MonoBehaviour
{

    public BodyScript NextNode;

    public GameObject BodyPrefab;

   private bool ShouldReproduce = false;

    private AudioSource source;



    private void Start()
    {
        source = GetComponent<AudioSource>();
    }


    public void SignalToMove(Vector3 New)
    {
        Vector3 Old = transform.position;
        transform.position = New;
        if (NextNode != null)
        {
            NextNode.SignalToMove(Old);
        }
        else if (NextNode == null && ShouldReproduce)
        {
            ShouldReproduce = false;
            GameObject GO = Instantiate(BodyPrefab, Old, Quaternion.identity);
            NextNode = GO.GetComponent<BodyScript>();
        }
        
    }



    public void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(eh());
    }


    IEnumerator eh()
    {
        Time.timeScale = 0.0f;
        source.Play();
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


    public void SignalToExtend()
    {
        if(NextNode != null)
        {
            NextNode.SignalToExtend();
        }
        else
        {
            ShouldReproduce = true;
        }
    }


}
