using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement movementScript;
    private Animator animator;
    private AudioSource gruntSound;

    private int sawCooldown = 40;

    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        gruntSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sawCooldown++;
        if((Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.F)) && sawCooldown >= 40){
            sawCooldown = 0;
            animator.SetBool("Sawing", true);
            movementScript.canMove = false;
            gruntSound.Play();
        }
        if(sawCooldown >= 40)
        {
            animator.SetBool("Sawing", false);
            movementScript.canMove = true;
        }
        Debug.Log(animator.GetBool("Sawing"));
    }
}
