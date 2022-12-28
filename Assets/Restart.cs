using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public int targetFrameRate = 60;

    private void Start() {
        Application.targetFrameRate = targetFrameRate;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
