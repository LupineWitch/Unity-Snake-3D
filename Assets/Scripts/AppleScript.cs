using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
   public  GameObject ApplePrefab;

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        HeadScript headScript = collision.gameObject.GetComponent<HeadScript>();
        collision.transform.rotation = Quaternion.identity;
        headScript.EatApple();
        CreateNewApple();
    }


    /// <summary>
    /// Map cords are X: -8;9.5
    ///               Z: -9:9
    /// </summary>

    private bool CheckIfSnakeIsThere(float X, float Z)
    {
        Vector3 spawnPos = new Vector3(X, 1, Z);

        float radius = 0.2f;
 
       if (Physics.CheckSphere(spawnPos, radius))
        {
            return true;
        }
        return false;

    }

    public void CreateNewApple()
    {
        Random rand = new Random();

        float X = Random.Range(-8f, 9.5f);
           
        float Z = Random.Range(-9f, 9f);
      
       /* while(CheckIfSnakeIsThere(X,Z))
            {
                X = Random.Range(-8f, 9.5f);

                Z = Random.Range(-9f, 9f);
             }
             */
     
        GameObject NewApple =  Instantiate(ApplePrefab, new Vector3(X, 1f, Z), Quaternion.identity);
         



    }
}
