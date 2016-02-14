using UnityEngine;
using System.Collections;

public class RunRandom : MonoBehaviour {
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 force;
    public float mass;

    public float maxSpeed = 5.0f;
    public float maxForce = 5.0f;

    public Vector3 randomPosition;

    void Start() {

    }

    Vector3 RunTo(Vector3 target) {
        Vector3 toTarget = target - transform.position;
        toTarget.Normalize();
        return (toTarget * maxSpeed) - velocity;
    }

    void Update()
    {
        force = Vector3.zero;

        force = RunTo(randomPosition);

        force = Vector3.ClampMagnitude(force, maxForce);
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;
        if (velocity.magnitude > float.Epsilon)
            transform.forward = velocity;

        if (Vector3.Distance(randomPosition, transform.position) < 0.05f)
            randomPosition = new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50));
    }

}