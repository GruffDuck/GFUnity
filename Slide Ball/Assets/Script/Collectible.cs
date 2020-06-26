using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(15,30,45)*Time.deltaTime);
    }

    public void collect()
        {
        FindObjectOfType<scoreManagr>().AddScore(3);
        Destroy(gameObject);
        }
    
}
