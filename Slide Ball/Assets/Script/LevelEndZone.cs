using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallController>() != null)
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().NextLevel();
        }
    }
}
