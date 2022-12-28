using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    private void Awake() {
        transform.rotation = Random.rotationUniform;
    }
}
