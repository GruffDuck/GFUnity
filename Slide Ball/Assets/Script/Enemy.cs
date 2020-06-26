using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float patrolRange;
    [SerializeField]
    private float MoveSpeed;
    private Vector3 initialPos;
    private Vector3 minPatrolPos;
    private Vector3 maxPatrolPos;
    private Vector3 destinationPoint;
    private GameObject goldPrefab;

    private void Awake()
    {
        initialPos = transform.position;
        minPatrolPos = initialPos + Vector3.left * patrolRange;
        maxPatrolPos=initialPos + Vector3.right * patrolRange;
        SetDestination(maxPatrolPos);
        LoadGoldFromResources();
    }
    private void SetDestination(Vector3 destination)
    {
        destinationPoint = destination;
    }

    private void Update()
    {
        if (Math.Abs(Vector3.Distance(transform.position,maxPatrolPos))<1f)
        {
            SetDestination(minPatrolPos);
        }
       else if (Math.Abs(Vector3.Distance(transform.position, minPatrolPos)) < 1f)
        {
            SetDestination(maxPatrolPos);
        }
        transform.position = Vector3.MoveTowards(transform.position, destinationPoint, Time.deltaTime * MoveSpeed);

    }
   
    private void LoadGoldFromResources()
    {
        goldPrefab = Resources.Load<GameObject>("coin");
    }
    public void Die()
    {
        Instantiate(goldPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
