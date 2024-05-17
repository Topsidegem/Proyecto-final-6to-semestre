using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PartnerAgent : BasicAgent {

    [SerializeField] Animator animator;
    [SerializeField] PartnerAgentStates agentState;
    Rigidbody rb;
    string currentAnimationStateName;
    [SerializeField] bool isFeed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agentState = PartnerAgentStates.None;
        currentAnimationStateName = "";
    }

    void Update() {
        decisionManager();
    }

    public void feeding(Transform t_target) {
        isFeed = true;
        target = t_target;
    }

    void decisionManager() {
        PartnerAgentStates newState;
        if (!isFeed)
        {
            newState = PartnerAgentStates.None;
        }
        else
        {
            newState = PartnerAgentStates.Pursuit;
            if (Vector3.Distance(transform.position,target.position) < stopThreshold)
            {
                newState = PartnerAgentStates.None;
            }
        }

        changeAgentState(newState);
        actionManager();
        movementManager();
    }

    void changeAgentState(PartnerAgentStates t_newState)
    {
        if (agentState == t_newState)
        {
            return;
        }
        agentState = t_newState;
    }

    void actionManager()
    {
        switch (agentState)
        {
            case PartnerAgentStates.None:
                break;
        }
    }

    void movementManager()
    {
        switch (agentState)
        {
            case PartnerAgentStates.None:
                rb.velocity = Vector3.zero;
                break;
            case PartnerAgentStates.Pursuit:
                pursuiting();
                break;
        }
    }

    private void pursuiting()
    {
        if (!currentAnimationStateName.Equals("Cat_armature|walk"))
        {
            animator.Play("Cat_armature|walk", 0);
            currentAnimationStateName = "Cat_armature|walk";
        }
        maxVel *= 2;
        rb.velocity = SteeringBehaviours.seek(this, target.position);
        rb.velocity = SteeringBehaviours.arrival(this, target.position, slowingRadius, stopThreshold);
        if (Vector3.Distance(transform.position, target.position) <= slowingRadius)
        {
            if (!currentAnimationStateName.Equals("Cat_armature|walk"))
            {
                animator.Play("Cat_armature|walk", 0);
                currentAnimationStateName = "Cat_armature|walk";
            }
        }
        maxVel /= 2;
    }

    private enum PartnerAgentStates
    {
        None,
        Pursuit
    }
}
