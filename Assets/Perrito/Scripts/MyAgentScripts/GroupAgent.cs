using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class GroupAgent : BasicAgent {

    [SerializeField] float eyesPerceptRadious, earsPerceptRadious;
    [SerializeField] Transform eyesPercept, earsPercept;
    [SerializeField] Animator animator;
    [SerializeField] GroupAgentStates agentState;
    Rigidbody rb;
    Collider[] perceibed, perceibed2;
    string currentAnimationStateName;
    [SerializeField] string _tag; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agentState = GroupAgentStates.None;
        currentAnimationStateName = "";
    }

    // Update is called once per frame
    void Update()
    {
        perceptionManager();
        decisionManager();
    }

    private void FixedUpdate()
    {
        perceibed = Physics.OverlapSphere(eyesPercept.position, eyesPerceptRadious);
        perceibed2 = Physics.OverlapSphere(earsPercept.position, earsPerceptRadious);
    }

    void perceptionManager()
    {
        if (perceibed != null)
        {
            foreach (Collider tmp in perceibed)
            {
                if (tmp.CompareTag(_tag))
                {
                    target = tmp.transform;
                }
            }
        }
        if (perceibed2 != null)
        {
            foreach (Collider tmp in perceibed2)
            {
                if (tmp.CompareTag(_tag))
                {
                    target = tmp.transform;
                }
            }
        }
    }

    void decisionManager()
    {
        GroupAgentStates newState;
        if (target == null)
        {
            newState = GroupAgentStates.Wander;
        }
        else
        {
            newState = GroupAgentStates.Pursuit;
        }
        changeAgentState(newState);
        actionManager();
        movementManager();
    }

    void changeAgentState(GroupAgentStates t_newState)
    {
        if (agentState == t_newState)
        {
            return;
        }
        agentState = t_newState;
        if (agentState != GroupAgentStates.Wander)
        {
            wanderNextPosition = null;
        }
    }

    void actionManager()
    {
        switch (agentState)
        {
            case GroupAgentStates.None:
                break;
        }
    }

    void movementManager()
    {
        switch (agentState)
        {
            case GroupAgentStates.None:
                rb.velocity = Vector3.zero;
                break;
            case GroupAgentStates.Pursuit:
                pursuiting();
                break;
            case GroupAgentStates.Wander:
                wandering();
                break;
        }
    }

    private void wandering()
    {
        if (!currentAnimationStateName.Equals("Walk"))
        {
            Debug.Log(currentAnimationStateName);
            animator.Play("Walk", 0);
            currentAnimationStateName = "Walk";
        }
        if ((wanderNextPosition == null) ||
            (Vector3.Distance(transform.position, wanderNextPosition.Value) < 0.5f))
        {
            wanderNextPosition = SteeringBehaviours.wanderNextPos(this);
        }
        rb.velocity = SteeringBehaviours.seek(this, wanderNextPosition.Value);
    }

    private void pursuiting()
    {
        if (!currentAnimationStateName.Equals("Run") && !currentAnimationStateName.Equals("Walk"))
        {
            animator.Play("Run", 0);
            currentAnimationStateName = "Run";
        }
        maxVel *= 2;
        rb.velocity = SteeringBehaviours.seek(this, target.position);
        rb.velocity = SteeringBehaviours.arrival(this, target.position, slowingRadius, stopThreshold);
        if (Vector3.Distance(transform.position, target.position) <= slowingRadius)
        {
            if (!currentAnimationStateName.Equals("Walk"))
            {
                animator.Play("Walk", 0);
                currentAnimationStateName = "Walk";
            }
        }
        maxVel /= 2;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(eyesPercept.position, eyesPerceptRadious);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(earsPercept.position, earsPerceptRadious);
    }

    private enum GroupAgentStates
    {
        None,
        Pursuit,
        Wander
    }
}
