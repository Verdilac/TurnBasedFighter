using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{


    private Vector3 targetPosition;

    private void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Update()
    {
        Vector3 moveDirection = (targetPosition -  transform.position).normalized;

        float moveSpeed = 4f;
        transform.position += moveDirection  * moveSpeed*Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.T))
        {
            Move(new Vector3(4, 0, 4));

        }
    }




}
