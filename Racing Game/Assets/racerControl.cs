using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racerControl : MonoBehaviour {


    private Rigidbody rb;

    public float speed;

    public float turnSpeed;

    public float forwardSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * turnSpeed, 0.0f, moveVertical * forwardSpeed);

        rb.AddForce(movement);
    }

   /* void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            count = count + 1;
            other.gameObject.SetActive(false);
            SetCountText();
            if (count >= 14)
            {
                WinText.text = "You are victorious!";
            }
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
    }

}*/
}
