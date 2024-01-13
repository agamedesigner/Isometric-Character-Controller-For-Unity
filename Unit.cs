using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;

    [SerializeField] private bool isEnemy;

    private Vector3 targetPosition;

    public bool collidingStorage = false;

    public GameObject eldekibalta;

  

    private void Awake()
    {
        targetPosition = transform.position;


    }
    
  


    private void Update()
    {
        
float stoppingDistance = .1f;
        if(Vector3.Distance(transform.position, targetPosition)>stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            float rotateSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

            unitAnimator.SetBool("IsWalking", true);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }      
        
        
   
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }

    // private void OnCollisionStay(Collision other) {
    //     if(other.transform.CompareTag("Storage"))
    //     {
    //         collidingStorage = true;
    //         other.transform.GetComponent<Animator>().SetBool("IsWalking", false);
    //     }
    // }

    // private void OnCollisionExit(Collision other) {
    //     if(other.transform.CompareTag("Storage"))
    //     {
    //         collidingStorage = false;

    //     }
    // }

}



