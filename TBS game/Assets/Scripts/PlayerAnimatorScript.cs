using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{
    [SerializeField]Animator animator;
    void Start()
    {

    }
    public void StartMoovingAnimation()
    {
        animator.SetBool("IsRunning", true);
    }
    public void StopMoovingAnimation()
    {
        animator.SetBool("IsRunning", false);
    }
    void Update()
    {
        
    }
}
