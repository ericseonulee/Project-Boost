using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    Rigidbody rocketRigidbody;
    [SerializeField] float mainThrust = 750f;
    [SerializeField] float rotationalThrust = 50f;

    void Start() {
        rocketRigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        ProcessThrust();
        ProcessRotation();
    }

    void ApplyRotation(float rotationThisFram) {
        Vector3 force = Vector3.forward * rotationThisFram * Time.deltaTime;

        rocketRigidbody.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(force);
        rocketRigidbody.freezeRotation = false; // unfrezing rotation so physics system can take over
    }

    void ProcessRotation() {
        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            ApplyRotation(rotationalThrust);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            ApplyRotation(-rotationalThrust);
        }
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            Vector3 force = Vector3.up * mainThrust * Time.deltaTime;
            rocketRigidbody.AddRelativeForce(force);
        }
    }
}
