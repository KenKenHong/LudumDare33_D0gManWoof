using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip howl;
    public AudioClip footsteps;
    public float turnSmoothing = 15f;

    private Animator anim;
    private HashIDs hash;

    void Awake()
    {

    }
}