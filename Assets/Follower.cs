using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Vector3 offset;
    Rigidbody target;
    Vector3 prevTargetPosition;
    Quaternion prevTargetRotation;

    public void SetTarget(GameObject newTarget, Vector3 newOffset) {
        target = newTarget.GetComponent<Rigidbody>();
        offset = newOffset;
        transform.SetPositionAndRotation(target.position + offset, target.rotation);
        prevTargetPosition = target.position;
        prevTargetRotation = target.rotation;
    }

    private void FixedUpdate() {
        prevTargetPosition = target.position;
        prevTargetRotation = target.rotation;
    }

    private void Update() {
        if (target != null) {
            if (Time.deltaTime < Time.fixedDeltaTime) {
                /*if (Time.timeSinceLevelLoad < 1f) {
                    transform.SetPositionAndRotation(target.position + offset, target.rotation);
                    return;
                }*/

                var t = Time.deltaTime / Time.fixedDeltaTime;

                var positionDelta = (target.position - prevTargetPosition) * 0.95f + (target.position + offset - transform.position) * 0.05f;
                transform.position += positionDelta * t;
                //transform.position = target.transform.position;

                var rotationDelta = Quaternion.Slerp(Quaternion.identity, Quaternion.Inverse(prevTargetRotation) * target.rotation, 0.95f)
                    * Quaternion.Slerp(Quaternion.identity, Quaternion.Inverse(transform.rotation) * target.rotation, 0.05f);
                transform.rotation *= Quaternion.Slerp(Quaternion.identity, rotationDelta, t);
                //transform.rotation = target.transform.rotation;
            }
            else {
                transform.SetPositionAndRotation(target.position, target.rotation);
            }
        }
    }
}
