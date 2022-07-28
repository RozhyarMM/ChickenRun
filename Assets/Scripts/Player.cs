using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        transform.Translate(new Vector3(0,0,3) * Time.deltaTime);

    float _horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.x < -1.5)
        {
            transform.position = new Vector3(-1f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 1.5)
        {
            transform.position = new Vector3(1f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(Jump());
        }
    }
    IEnumerator Jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 1.5f, 0) * 3;
        yield return new WaitForSeconds(0.6f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, -1.5f, 0) * 3;
        if (transform.position.y <= 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

}
