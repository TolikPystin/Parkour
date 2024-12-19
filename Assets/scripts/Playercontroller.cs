using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{


    private float horizontal;
    private float vertical;
    public float speed = 10f;
    public float rotationspeed = 50f;
    public float jumpforce = 10f;
    private Rigidbody rb;
    private bool isgraunted = true;
    public float rotationsens = 5f;
    public Transform cameratransform;
    private float ixrotation;






    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * vertical * Time.deltaTime );
        transform.Rotate(Vector3.up * horizontal * rotationspeed * Time.deltaTime );

        if (Input.GetMouseButton(1))
        {
            ixrotation -= Input.GetAxis("Mouse Y") * rotationsens;
            ixrotation = Mathf.Clamp(ixrotation, -60, 60 );

            cameratransform.localEulerAngles = new Vector3 (ixrotation, 0, 0);
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationsens, 0);
        }



        if (Input.GetKeyDown(KeyCode.Space) && isgraunted) 
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);



            isgraunted = false;
        }




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isgraunted = true ;
        }
    }


}
