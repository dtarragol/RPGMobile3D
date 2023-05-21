using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Transform cam;
    public Joystick joystickMove;
    public Joystick joystickGiro;

    public Transform player;
    public CharacterController controller;

    public float speed=10f;
    float x;
    float y;
    Vector3 move;
    float rotateV;
    float rotateH;
    public float speedGiero = 0.2f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    void Move()
    {
        x = joystickMove.Horizontal + Input.GetAxis("Horizontal");
        y = joystickMove.Vertical + Input.GetAxis("Vertical");
        move = player.right * x + player.forward * y;
        controller.Move(move * speed * Time.deltaTime);
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }

    void Rotate()
    {
        rotateH = joystickGiro.Horizontal * speedGiero;
        rotateV = joystickGiro.Vertical * speedGiero;
        cam.Rotate(rotateV, 0, 0);
        player.Rotate(0, rotateH, 0);
    }
    private void Update()
    {
        Move();
        Rotate();
        
    }
}
