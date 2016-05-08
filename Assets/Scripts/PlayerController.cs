using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    public int shootForce = 1000;

    public GameObject ballPrefab;

    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) 
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void resetPosition()
    {
        Vector3 position;
        position.x = 150f;
        position.y = 60f;
        position.z = 150f;

        transform.localPosition = position;
    }

    public void throwBall()
    {
        GameObject ball = Instantiate (ballPrefab, transform.position, transform.rotation) as GameObject;
        Transform ballTransform = ball.transform;

        ballTransform.SetParent(this.transform);
        ballTransform.localPosition = new Vector3(0f,0f,1f);
        ballTransform.SetParent(null);

        ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shootForce);

    }
}
