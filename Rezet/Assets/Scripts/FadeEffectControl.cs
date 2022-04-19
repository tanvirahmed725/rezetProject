using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffectControl : MonoBehaviour
{

    public Animator animator;

    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeOut();
        }
        if (Input.GetMouseButtonDown(1))
        {
            FadeIn();
        }
    }*/
        
    public void FadeOut()
    {
        animator.SetBool("FadeOut", true);
    }

    public void FadeIn()
    {
        animator.SetBool("FadeOut", false);
    }
}
