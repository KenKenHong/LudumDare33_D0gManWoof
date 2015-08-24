using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
    public int caughtState;
    public int caughtBool;
    public int sneakingBool;
    public int movingBool;
    public int attackingTrigger;

    public int patrolBool;
    public int foundPlayerBool;
    public int chaseBool;
    public int deadBool;

    void Awake()
    {
        caughtState = Animator.StringToHash("Base Layer.Caught");
        caughtBool = Animator.StringToHash("Caught");
        sneakingBool = Animator.StringToHash("Sneaking");
        movingBool = Animator.StringToHash("Moving");
        attackingTrigger = Animator.StringToHash("Attack");

        foundPlayerBool = Animator.StringToHash("Found");
    }
}