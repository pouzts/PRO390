using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicMovement : Movement
{
    private void LateUpdate()
    {
        // v = a(t) + v0, v0 = 0
        Velocity += Acceleration * Time.deltaTime;
        // clamp the speed (the velocity's magnitude) with the min and max speed
        float speed = Mathf.Clamp(Velocity.magnitude, MinSpeed, MaxSpeed);
        // clamp the velocity with the speed
        Velocity = Vector3.ClampMagnitude(Velocity, speed);
        // s = v(t) + s0, s0 = 0
        transform.position += Velocity * Time.deltaTime;

        // if we orient to movement and the square magnitude of acceleration is greater than 0.1
        if (movementData.orientToMovement && Acceleration.sqrMagnitude > 0.1f)
        {
            // rotate the object around the velocity
            transform.rotation = Quaternion.LookRotation(Velocity);
        }

        // set acceleration to zero
        Acceleration = Vector3.zero;
    }

    public override void MoveTowards(Vector3 target)
    {
        // get the direction of the object towards the target (target - transform.position) normalized
        Vector3 direction = (target - transform.position).normalized;
        // apply the force
        ApplyForce(direction * MaxForce);
    }

    public override void ApplyForce(Vector3 force)
    {
        // add force to accleration
        Acceleration += force;
    }

    public override void Stop()
    {
        // set the velocity to zero
        Velocity = Vector3.zero;
    }

    public override void Resume()
    {
    }
}
