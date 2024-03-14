using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController : MonoBehaviour
{
    public float minWaitTime = 1f; // Minimum time to wait before moving again
    public float maxWaitTime = 3f; // Maximum time to wait before moving again

    private NavMeshAgent agent;
    private bool isMoving = false;
    private Animation spiderAnimation;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spiderAnimation = GetComponent<Animation>(); // Get the Animation component
        StartCoroutine(RandomMovement());
    }

    IEnumerator RandomMovement()
    {
        while (true)
        {
            if (!isMoving)
            {
                Vector3 randomPoint = RandomNavmeshPoint(10f); // Change 10f to the desired range
                MoveTo(randomPoint);
                isMoving = true;
                PlayWalkAnimation(); // Play the walk animation when the spider starts moving
                float waitTime = Random.Range(minWaitTime, maxWaitTime);
                yield return new WaitForSeconds(waitTime);
                isMoving = false;
                StopWalkAnimation(); // Stop the walk animation when the spider stops moving
            }
            yield return null;
        }
    }

    void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    void PlayWalkAnimation()
    {
        if (spiderAnimation != null)
        {
            spiderAnimation.Play("Walk");
        }
    }

    void StopWalkAnimation()
    {
        if (spiderAnimation != null)
        {
            spiderAnimation.Stop();
        }
    }

    Vector3 RandomNavmeshPoint(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas);
        return hit.position;
    }
}
