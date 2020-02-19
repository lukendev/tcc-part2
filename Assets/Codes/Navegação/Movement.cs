using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float movementSpeed;

	public float jumpSpeed = 2000;

	private bool podePular = true;


	public float margem = 0.1f;

	public Transform foot;

	private Rigidbody rb;


    // Use this for initialization
    void Start () {
        
		podePular = true;
		rb = GetComponent<Rigidbody> ();
	}

    // Update is called once per frame
    void FixedUpdate() {

        if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey ("w")) {
        
            transform.position += transform.forward * Time.deltaTime * movementSpeed * 2.5F;

        } else if (Input.GetKey ("w") && !Input.GetKey (KeyCode.LeftShift)) {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;

        } else if (Input.GetKey ("s")) {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey ("a") && !Input.GetKey ("d")) {
            transform.position -= transform.right * Time.deltaTime * movementSpeed;

        } else if (Input.GetKey ("d") && !Input.GetKey ("a")) {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }

    }

    void Update () {
			
		if (Input.GetKeyDown (KeyCode.Space) && podePular) {
			podePular = false;
			rb.AddForce (Vector3.up * jumpSpeed);
			return;
		}

		if (rb.velocity.y <= 0) {
			
			RaycastHit hit;

			if (Physics.Raycast(foot.position, -Vector3.up, out hit))
			{
				if (hit.distance < margem) {
					podePular = true;
				}
			}
		}


				
	}

	public void OnDrawGizmos() {
		Gizmos.color = Color.red;

		Gizmos.DrawLine (foot.position, foot.position - Vector3.up * margem);
	}

}
