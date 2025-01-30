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
    private Animator animator;
    public Gamemaneger gamemaneger;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
    }


    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * vertical * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontal * rotationspeed * Time.deltaTime);

        if (vertical == 0)
        {
            animator.SetBool("Walking", false);
        }
        else
        {
            animator.SetBool("Walking", true);
        }

        if (Input.GetMouseButton(1))
        {
            ixrotation -= Input.GetAxis("Mouse Y") * rotationsens;
            ixrotation = Mathf.Clamp(ixrotation, -60, 60);

            cameratransform.localEulerAngles = new Vector3(ixrotation, 0, 0);
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationsens, 0);
        }



        if (Input.GetKeyDown(KeyCode.Space) && isgraunted)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            animator.SetTrigger("Jump");


            isgraunted = false;
        }




    }





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isgraunted = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            gamemaneger.lifes--;
            gamemaneger.UpdateGui();
            Debug.Log("Жизни = " + gamemaneger.lifes);
            Destroy(collision.gameObject);
            if (gamemaneger.lifes <= 0)
            {
                gamemaneger.LoseGame();
            }
        }

        if (collision.gameObject.CompareTag("Gift"))
        {
            Debug.Log("вы победили");

        }


        if (collision.gameObject.CompareTag("Killer"))
        {
            gamemaneger.lifes -= 22;
            gamemaneger.UpdateGui();
            Debug.Log("Жизни = " + gamemaneger.lifes);
            Destroy(collision.gameObject);
            if (gamemaneger.lifes <= 0)
            {
                gamemaneger.LoseGame();
            }
        }
       
        if (collision.collider.tag == "Gift")
        {
            Debug.Log("вы дошли до подарка");
            gamemaneger.WinGame();


        }


    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("money"))
        {

            Destroy(other.gameObject);
            gamemaneger.coins++;
            Debug.Log("вы столкнулись" + other.tag + " money " + gamemaneger.coins);
            gamemaneger.UpdateGui();
        }

        if (other.CompareTag("medicine"))
        {
            Destroy(other.gameObject);
            gamemaneger.lifes++;
            Debug.Log("вы столкнулись" + other.tag + " lifes " + gamemaneger.lifes);
            gamemaneger.UpdateGui();
        }

        if (other.CompareTag("medicina"))
        {
            Destroy(other.gameObject);
            gamemaneger.lifes += 15;
            Debug.Log("вы столкнулись" + other.tag + " lifes " + gamemaneger.lifes);
            gamemaneger.UpdateGui();
        }

    }

    

}






