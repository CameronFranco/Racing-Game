using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class racerController : MonoBehaviour {


   private Rigidbody rb;
    public float antiroll;
    public Text timeText;
    public float turnSpeed;
    public float forwardSpeed;
    public float gravity;
    private float t = 0.0f;
    private float ellapsed = 0.0f;
    private bool over;
    private float powerUp;



    void Start()
    {
        over = false;
       rb = GetComponent<Rigidbody>();
        t = Time.time;
        timeText.text =  ellapsed.ToString("N3");
        powerUp = 0;
           
       
    }

     void Update()
    {
       
        if (over == false)
        {
            ellapsed = Time.time - t + powerUp;
        }
        timeText.text = string.Format("{0:0.00}", ellapsed);
           
    }

   void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, antiroll, moveVertical * forwardSpeed * 100);

        transform.Rotate(0,moveHorizontal * Time.deltaTime * turnSpeed, 0);

        //Vector3 movement = new Vector3(moveHorizontal * turnSpeed, 0.0f, (moveVertical + 1) * forwardSpeed);

        rb.AddRelativeForce(movement);
        rb.AddForce(0, gravity, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            over = true;
        }

        else if (other.gameObject.CompareTag("PowerUp"))
        {
            powerUp = powerUp - 5;
            other.gameObject.SetActive(false);
        }
    }
  

}
