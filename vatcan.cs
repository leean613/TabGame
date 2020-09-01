using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vatcan : MonoBehaviour
{ 

    //[SerializeField] ParticleSystem collectParticle=null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
            //Collect();
        GameController.instance.OnPlayerHitObstacle();

    }
    /* hieu ung khi player cham tung Obstacle (hieu ung don le)
    private void Collect()
    {
        ParticleSystem no1 = Instantiate(collectParticle, transform.position, Quaternion.identity);
        no1.Play();


    }
    */
}
