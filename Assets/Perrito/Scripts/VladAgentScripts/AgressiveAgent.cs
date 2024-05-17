using UnityEngine;

/// <summary>
/// Represents an aggressive agent with perception and decision-making capabilities.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class AgressiveAgent : BasicAgent {

    [SerializeField] Animator animator;
    [SerializeField] AgressiveAgentStates agentState;
    Rigidbody rb;
    string currentAnimationStateName;
    [SerializeField] bool isInTheArea = false;
    [SerializeField] Transform m_area;

    void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agentState = AgressiveAgentStates.None;
        currentAnimationStateName = "";
    }

    void Update () {
        decisionManager();
    }

    public void turnbool(Transform t_target) {
        isInTheArea = !isInTheArea;
        target = t_target;
    }

    /// <summary>
    /// Manages decision-making based on the agent's perception.
    /// </summary>
    void decisionManager () {
        AgressiveAgentStates newState;
        if (target == null) {
            newState = AgressiveAgentStates.Wander;
        } else if (isInTheArea) {
            newState = AgressiveAgentStates.Pursuit;
            if (Vector3.Distance(transform.position, target.position) < stopThreshold) {
                newState = AgressiveAgentStates.Attack;
            }
        } else {
            newState = AgressiveAgentStates.Return;
        }
        changeAgentState(newState);
        movementManager();
    }

    /// <summary>
    /// Changes the state of the agent only if its a new state
    /// </summary>
    /// <param name="t_newState">The new state of the agent.</param>
    void changeAgentState (AgressiveAgentStates t_newState) {
        if (agentState == t_newState) {
            return;
        }
        agentState = t_newState;
        if (agentState != AgressiveAgentStates.Wander) {
            wanderNextPosition = null;
        }
    }

    /// <summary>
    /// Manages movement based on the current state of the agent.
    /// </summary>
    void movementManager () {
        switch (agentState) {
            case AgressiveAgentStates.None:
                rb.velocity = Vector3.zero;
                break;
            case AgressiveAgentStates.Pursuit:
                pursuiting();
                break;
            case AgressiveAgentStates.Attack:
                attacking();
                break;
            case AgressiveAgentStates.Return:
                returning();
                break;
            case AgressiveAgentStates.Wander:
                wandering();
                break;
        }
    }

    /// <summary>
    /// Moves the agent randomly within the environment.
    /// </summary>
    private void wandering () {
        if (!currentAnimationStateName.Equals("Z_Walk_InPlace")) {
            Debug.Log(currentAnimationStateName);
            animator.Play("Z_Walk_InPlace", 0);
            currentAnimationStateName = "Z_Walk_InPlace";
        }
        if (( wanderNextPosition == null ) ||
            ( Vector3.Distance(transform.position, wanderNextPosition.Value) < 0.5f )) {
            wanderNextPosition = SteeringBehaviours.wanderNextPos(this);
        }
        rb.velocity = SteeringBehaviours.seek(this, wanderNextPosition.Value);
    }

    /// <summary>
    /// Handles pursuing the target.
    /// </summary>
    private void pursuiting () {
        if (!currentAnimationStateName.Equals("Z_Run_InPlace") && !currentAnimationStateName.Equals("Z_Walk_InPlace")) {
            animator.Play("Z_Run_InPlace", 0);
            currentAnimationStateName = "Z_Run_InPlace";
        }
        maxVel *= 2;
        rb.velocity = SteeringBehaviours.seek(this, target.position);
        rb.velocity = SteeringBehaviours.arrival(this, target.position, slowingRadius, stopThreshold);
        if (Vector3.Distance(transform.position, target.position) <= slowingRadius) {
            if (!currentAnimationStateName.Equals("Z_Walk_InPlace")) {
                animator.Play("Z_Walk_InPlace", 0);
                currentAnimationStateName = "Z_Walk_InPlace";
            }
        }
        maxVel /= 2;
    }

    /// <summary>
    /// Handles attacking the target.
    /// </summary>
    private void attacking () {
        if (!currentAnimationStateName.Equals("Z_Attack")) {
            animator.Play("Z_Attack", 0);
            currentAnimationStateName = "Z_Attack";
        }
    }

    /// <summary>
    /// Handles escaping from the target.
    /// </summary>
    private void returning() {
        if (!currentAnimationStateName.Equals("Z_Run_InPlace")) {
            animator.Play("Z_Run_InPlace", 0);
            currentAnimationStateName = "Z_Run_InPlace";
        }

        if (Vector3.Distance(transform.position, target.position) < stopThreshold) {
            target = null;
        }
        rb.velocity = SteeringBehaviours.seek(this, target.position);
    }

    /// <summary>
    /// Enumeration of possible agent states.
    /// </summary>
    private enum AgressiveAgentStates {
        None,
        Pursuit,
        Attack,
        Return,
        Wander
    }
}