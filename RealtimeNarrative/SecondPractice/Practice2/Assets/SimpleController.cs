using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SimpleController : MonoBehaviour
{
    public float speed = 20.0f;
    Vector3 velocity;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        velocity = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        float stickHorizontal = Input.GetAxis("Horizontal");
        float stickVertical = Input.GetAxis("Vertical");
        velocity.x = stickHorizontal;
        velocity.z = stickVertical;

        //transform.position += ;
        controller.Move((velocity.normalized + Vector3.up*Physics.gravity.y) * speed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.Cross(-hit.normal, transform.right) , hit.normal);
    }
}
