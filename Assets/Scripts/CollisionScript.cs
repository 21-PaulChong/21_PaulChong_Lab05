using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    public Text Scoretext;
    public Text timer;
    public float time;
    public int points;

   void Update()
   {
        Scoretext.text = "Score: " + points;
        timer.text = "Time left: " + time.ToString("0:00");
        time -= Time.deltaTime;

        if(time<=0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
   }

   private void OnCollisionEnter(Collision collision)
   {
        if(collision.gameObject.tag=="Coins")
        {
            Destroy(collision.gameObject);
            points += 10;
        }
   }

   private void OnTriggerEnter(Collider other)
   {
        if(other.gameObject.tag=="Environment")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
   }
}
