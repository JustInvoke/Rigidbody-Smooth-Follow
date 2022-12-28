using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFollower : MonoBehaviour
{
    public Vector3 offset;
    public Material followerMat;

    private void Awake() {
        var followerObj = new GameObject(transform.name + " follower", typeof(MeshFilter), typeof(MeshRenderer));

        var mesh = followerObj.GetComponent<MeshFilter>();
        mesh.sharedMesh = GetComponent<MeshFilter>().sharedMesh;

        var rend = followerObj.GetComponent<MeshRenderer>();
        rend.sharedMaterial = followerMat;

        var follower = followerObj.AddComponent<Follower>();
        follower.SetTarget(gameObject, offset);
    }
}
