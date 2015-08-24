using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float followspeed = 5f;

    private Vector3 offset;

	void Start ()
    {
        offset = transform.position - player.position;
	}

	void FixedUpdate ()
    {
        Vector3 camPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, camPos, followspeed * Time.deltaTime);
	}
}
