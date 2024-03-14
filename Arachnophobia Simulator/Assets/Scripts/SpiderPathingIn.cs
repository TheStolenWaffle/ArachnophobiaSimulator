using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderPathing : MonoBehaviour
{
    public Transform startPoint; // Point where the spider will start
    public Transform endPoint; // Point where the spider will path to
    public float spiderSizeMultiplier = 0.1f; // Size multiplier for the spider

    private NavMeshAgent agent;
    private Vector3 originalScale;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        originalScale = transform.localScale;

        // Set spider's position to the start point
        if (startPoint != null)
        {
            transform.position = startPoint.position;
        }

        // Set spider's destination to the end point
        if (endPoint != null)
        {
            agent.SetDestination(endPoint.position);
        }

        // Reduce spider's size
        transform.localScale = originalScale * spiderSizeMultiplier;
    }

    void Update()
    {
        // You may add additional behaviors or checks here
    }
}