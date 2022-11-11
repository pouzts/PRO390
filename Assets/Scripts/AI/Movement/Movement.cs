using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected MovementData movementData;

    // min speed
    public float MinSpeed { get => movementData.minSpeed; }
    // max speed
    public float MaxSpeed { get => movementData.maxSpeed; }
    // max force
    public float MaxForce { get => movementData.maxForce; }

    // velocity
    public virtual Vector3 Velocity { get; set; } = Vector3.zero;
    // acceleration
    public virtual Vector3 Acceleration { get; set; } = Vector3.zero;
    // direction
    public virtual Vector3 Direction { get => Velocity.normalized; }
    // destination
    public virtual Vector3 Destination { get; set; } = Vector3.zero;

    // MoveTowards(position) -> void
    public abstract void MoveTowards(Vector3 position);
    // ApplyForce(force) -> void
    public abstract void ApplyForce(Vector3 force);
    // Stop() -> void
    public abstract void Stop();
    // Resume() -> void
    public abstract void Resume();
}
