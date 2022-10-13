using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float shipSpeed = 30f;

    [SerializeField] private float rollLimit = 45f;
    [SerializeField] private float rollTime = 0.1f;

    [SerializeField] private float pitchLimit = 30f;
    [SerializeField] private float pitchTime = 0.1f;

    [SerializeField] private Transform aimObject;
    [SerializeField] private Transform shipObject;

    public void Move(Vector3 movement)
    {
        aimObject.position += movement * speed * Time.deltaTime;
        KeepInFrame(aimObject);
        MoveTowardsObjectXY(shipObject, aimObject, shipSpeed);
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

    private void MoveTowardsObjectXY(Transform obj, Transform target, float speed)
    {
        Vector2 targetPos = target.position;
        obj.position = Vector2.MoveTowards(obj.position, targetPos, speed * Time.deltaTime);
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
