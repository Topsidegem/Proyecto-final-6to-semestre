using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class TimidAgent : BasicAgent {
    [SerializeField] float eyesPerceptRadious, earsPerceptRadious;
    [SerializeField] Transform eyesPercept, earsPercept;
    [SerializeField] Animator animator;
    [SerializeField] TimidAgentStates agentState;
    Rigidbody rb;
    Collider[] perceibed, perceibed2;
    string currentAnimationStateName;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agentState = TimidAgentStates.None;
        currentAnimationStateName = "";
    }

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
        target = null;
        if (perceibed != null)
        {
            foreach (Collider tmp in perceibed)
            {
                if (tmp.CompareTag("Player"))
                {
                    target = tmp.transform;
                }
            }
        }
        if (perceibed2 != null)
        {
            foreach (Collider tmp in perceibed2)
            {
                if (tmp.CompareTag("Player"))
                {
                    target = tmp.transform;
                }
            }
        }
    }

    void decisionManager()
    {
        TimidAgentStates newState;
        if (target == null)
        {
            newState = TimidAgentStates.Wander;
        }
        else
        {
            newState = TimidAgentStates.Escape;
        }
        changeAgentState(newState);
        actionManager();
        movementManager();
    }

    void changeAgentState(TimidAgentStates t_newState)
    {
        if (agentState == t_newState)
        {
            return;
        }
        agentState = t_newState;
        if (agentState != TimidAgentStates.Wander)
        {
            wanderNextPosition = null;
        }
    }

    void actionManager()
    {
        switch (agentState)
        {
            case TimidAgentStates.None:
                break;
            case TimidAgentStates.Escape:
                // screaming();
                break;
        }
    }

    void movementManager()
    {
        switch (agentState)
        {
            case TimidAgentStates.None:
                rb.velocity = Vector3.zero;
                break;
            case TimidAgentStates.Escape:
                escaping();
                break;
            case TimidAgentStates.Wander:
                wandering();
                break;
        }
    }

    private void wandering()
    {
        if (!currentAnimationStateName.Equals("Run"))
        {
            Debug.Log(currentAnimationStateName);
            animator.Play("Run", 0);
            currentAnimationStateName = "Run";
        }
        if ((wanderNextPosition == null) ||
            (Vector3.Distance(transform.position, wanderNextPosition.Value) < 0.5f))
        {
            wanderNextPosition = SteeringBehaviours.wanderNextPos(this);
        }
        rb.velocity = SteeringBehaviours.seek(this, wanderNextPosition.Value);
    }

    private void escaping()
    {
        if (!currentAnimationStateName.Equals("Run"))
        {
            animator.Play("Run", 0);
            currentAnimationStateName = "Run";
        }
        rb.velocity = SteeringBehaviours.flee(this, target.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(eyesPercept.position, eyesPerceptRadious);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(earsPercept.position, earsPerceptRadious);
    }

    private enum TimidAgentStates
    {
        None,
        Escape,
        Wander
    }
}
