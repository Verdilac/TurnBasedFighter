using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    //Object Ref 
    [SerializeField] private Animator unitAnimator;



    //Variables
    private Vector3 targetPosition;
    [SerializeField] private float moveSpeed = 4f;   
    [SerializeField] private float rotateSpeed = 10f;
    private float stoppingDistance = 0.1f;
 
    


    private void Start()
    {
         if(unitAnimator == null)
        {
            Debug.Log("unitAnimator is Null");
        }
    }



    private void Update()
    {
        UpdatePosition();
    


  
    }


    private void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }


    private void UpdatePosition()
    {
        if (stoppingDistance < Vector3.Distance(transform.position, targetPosition))
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

           
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            transform.forward = Vector3.Lerp(transform.forward,moveDirection,Time.deltaTime* rotateSpeed);

            unitAnimator.SetBool("IsWalking", true);


        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }


        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());

        }
    }

   




}
