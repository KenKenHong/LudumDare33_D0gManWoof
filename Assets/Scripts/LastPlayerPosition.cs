using UnityEngine;
using System.Collections;

public class LastPlayerPosition : MonoBehaviour
{
    public Transform player;
    public Vector3 position = new Vector3(1000f, 1000f, 1000f);
    public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);
    public float outlineMaxIntensity = 1f;
    public float outlineMinIntensity = 0f;
    public float fadeSpeed = 1f;
    public float musicFadeSpeed = 1f;

    private DangerFilter danger;
    private Outline outline;
    private AudioSource dangerAudio;
	
    void Awake()
    {
        danger = GameObject.FindGameObjectWithTag("DangerFilter").GetComponent<DangerFilter>();
        outline = GameObject.FindGameObjectWithTag("Outline").GetComponent<Outline>();
    }

    void Update()
    {
        SwitchPlayerSighted();
        MusicFade();
    }

    void SwitchPlayerSighted()
    {
        danger.playerSighted = (position != resetPosition);

        if (position != resetPosition)
        {
            outline.alpha = outlineMaxIntensity;
            outline.transform.position = player.position;
            outline.transform.rotation = player.rotation;
        }

        outline.alpha = Mathf.Lerp(outline.alpha, outlineMinIntensity, fadeSpeed * Time.deltaTime);
    }

    void MusicFade()
    {

    }
}