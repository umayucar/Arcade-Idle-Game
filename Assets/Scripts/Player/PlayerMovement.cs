using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public VariableJoystick joystickVariable;
    public Animator animatorController;

    public float movementSpeed = 5f;
    public float movementRotationSpeed = 10f;

    void Update()
    {
        Vector2 joystickDirection = joystickVariable.Direction;
        Vector3 movementVector = new Vector3(joystickDirection.x, 0, joystickDirection.y);

        movementVector = movementVector * Time.deltaTime * movementSpeed;
        transform.position += movementVector;

        if (movementVector.magnitude != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector, Vector3.up), Time.deltaTime * movementRotationSpeed);
        }

        bool isWalking = joystickDirection.magnitude > 0;
        animatorController.SetBool("isWalking", isWalking);
        animatorController.SetFloat("Speed", joystickDirection.magnitude);

    }
}
