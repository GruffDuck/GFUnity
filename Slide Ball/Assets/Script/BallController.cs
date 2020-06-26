using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using UnityEditor;

public class BallController : MonoBehaviour
{
    public float movespeed = 1f;
    public float jumpspeed = 1f;
    [CanBeNull]
    private Rigidbody rb;
    private bool isgrounded;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Move(Vector3 direction)
    {
        rb.AddForce(direction * movespeed, ForceMode.Acceleration);
    }


    void Jump()
    {
        if (!isgrounded)
        {
            return;
        }
        rb.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision other)
    {
        isgrounded = true;
        CheckEnemyCollision(other);


    }
    private void CheckEnemyCollision(Collision collision)
    {
        bool hasCollidedWithEnemy = collision.collider.GetComponent<Enemy>();
        if (hasCollidedWithEnemy)
        {

            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit Hit, Mathf.Infinity))
            {
                Enemy enemy = Hit.collider.GetComponent<Enemy>();
                bool isOnTopOfEnemy = enemy != null;
                if (isOnTopOfEnemy)

                {
                    enemy.Die();
                    return;
                }


                else
                {
                    Die();
                }
            }
            

        }
    }
    
    private void OnCollisionExit(Collision collision)
        {
            isgrounded = false;
        }
        private void OnTriggerEnter(Collider other)
        {
            Collectible collectible = other.GetComponent<Collectible>();
            bool iscollectable = collectible != null;
            if (iscollectable)
            {
                collectible.collect();
            }
        }
        public void Die()
        {

        GameObject.Find("LevelManager").GetComponent<LevelManager>().RestartScene();
        GetComponent<MeshRenderer>().enabled = false;
        }
   
}


