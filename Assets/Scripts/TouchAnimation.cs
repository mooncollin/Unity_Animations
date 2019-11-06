using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAnimation : MonoBehaviour
{
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        anim.SetTrigger("Touch");
    }
}
