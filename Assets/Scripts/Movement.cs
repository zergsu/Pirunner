using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    public Vector3 move = new Vector3();

    public int jumpForce = 300;
    public float moveSpeed = 2;
    public bool canBHop;
    public float bHopWindow;
    public float bHopForce;
    public bool isGrounded;


    // Update is called once per frame
    void Update()
    {

        Vector3 move = new Vector3();

        move = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;

        if (move.magnitude > 1f)
        {
            move.Normalize();
        }

        rb.velocity = (move * Time.deltaTime * moveSpeed);


        //if (Input.GetKey(KeyCode.W))
        //{
        //    rb.AddForce(Vector3.forward * moveSpeed);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    rb.AddForce(Vector3.left * moveSpeed);
        //    //rb.velocity = Vector3.left;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    rb.AddForce(Vector3.back * moveSpeed);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    rb.AddForce(Vector3.right * moveSpeed);
        //}
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (canBHop == true)
            {
                Debug.Log("BHop");
                rb.AddForce(rb.velocity * bHopForce);
            }

            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isGrounded)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                canBHop = true;
                StartCoroutine(BHop());
            }
        }
    }

    IEnumerator BHop()
    {
        yield return new WaitForSeconds(bHopWindow);
        canBHop = false;
    }
}
