using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [Header("Speed of objects")]
    [SerializeField] private float aimSpeed = 50f;
    [SerializeField] private float xYSpeed = 30f;
    //[SerializeField] private float forwardSpeed = 10f;

    [Header("Aerodynamics")]
    [SerializeField] private float rollLimit = 45f;
    [SerializeField] private float rollTime = 0.1f;
    [SerializeField] private float pitchLimit = 30f;
    [SerializeField] private float pitchTime = 0.1f;

    [Header("References")]
    [SerializeField] private Transform aimObject;
    [SerializeField] private Transform shipObject;
    [SerializeField] private float distanceToAim = 10f;

    public void Move(Vector3 movement)
    {
        //transform.parent.Translate(forwardSpeed * Time.deltaTime * Vector3.forward);

        // moving the aim object
        aimObject.Translate(aimSpeed * Time.deltaTime * movement);
        KeepInFrame(aimObject);

        // Moving the ship object
        MoveTowardsObject(shipObject, aimObject, xYSpeed, distanceToAim);
        RollObject(shipObject, movement.x, rollLimit, rollTime);
        PitchObject(shipObject, movement.y, pitchLimit, pitchTime);
        KeepInFrame(shipObject);
    }

    private void KeepInFrame(Transform transform)
    {
        Vector3 framePosition = Camera.main.WorldToViewportPoint(transform.position);

        framePosition.x = Mathf.Clamp01(framePosition.x);
        framePosition.y = Mathf.Clamp01(framePosition.y);

        transform.position = Camera.main.ViewportToWorldPoint(framePosition);
    }

    private void MoveTowardsObject(Transform obj, Transform target, float xYSpeed, float zDistance = 0)
    {
        Vector3 zVector = Vector3.forward * zDistance;
        Vector3 targetPos = target.position - zVector;
        obj.position = Vector3.MoveTowards(obj.position, targetPos, xYSpeed * Time.deltaTime);
    }

    private void RollObject(Transform obj, float hAxis, float rollLimit, float lerp)
    {
        Vector3 eulerAngles = obj.localEulerAngles;
        obj.localEulerAngles = new(eulerAngles.x, eulerAngles.y, Mathf.LerpAngle(eulerAngles.z, -hAxis * rollLimit, lerp));
    }

    private void PitchObject(Transform obj, float vAxis, float rollLimit, float lerp)
    {
        Vector3 eulerAngles = obj.localEulerAngles;
        obj.localEulerAngles = new(Mathf.LerpAngle(eulerAngles.x, -vAxis * rollLimit, lerp), eulerAngles.y, eulerAngles.z);
    }
}
