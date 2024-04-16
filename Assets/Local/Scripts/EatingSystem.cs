using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingSystem : MonoBehaviour
{
    private GameObject eatingPoint;
    private GameObject foodObject;
    [SerializeField] private AudioSource eatingAudioSource;
    [SerializeField] private AudioClip eatingAudioClip;

    private void Start()
    {
        eatingPoint = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "FishCooked":
                foodObject = other.gameObject;
                Destroy(foodObject);
                eatingAudioSource.PlayOneShot(eatingAudioClip);
                break;
        }
    }
}
