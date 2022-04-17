using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        //Fade out
        animator.SetBool("FadeOut", true);


        StartCoroutine(waiter());
        IEnumerator waiter()
        {
            yield return new WaitForSeconds(0.5f);


            //Transport Player to respawn point
            if (other.CompareTag(("Player")))
            {
                player.transform.position = respawnPoint.transform.position;
                Physics.SyncTransforms();
            }
            //Fade In

            animator.SetBool("FadeOut", false);

            //Flash Death
            Renderer[] meshIndex = player.GetComponentsInChildren<Renderer>();

            StartCoroutine(Flash());
            IEnumerator Flash()
            {
                // This will wait 1 second like Invoke could do, remove this if you don't need it
                yield return new WaitForSeconds(0.5f);


                float timePassed = 0;
                float flashSpeed = 0.25f;
                while (timePassed < 0.25f)
                {
                    foreach (Renderer r in meshIndex)
                        r.enabled = !r.enabled;
                    timePassed += Time.deltaTime;

                    yield return new WaitForSeconds(flashSpeed -= Time.deltaTime);
                }

                foreach (Renderer r in meshIndex)
                    r.enabled = true;
            }
        }

        
      
    }



}
