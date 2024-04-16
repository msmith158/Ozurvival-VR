using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent (typeof(Collider))]
public class CampfireSystem : MonoBehaviour
{
    private GameObject object1;
    private GameObject object2;
    [Header("Crafting Progression")]
    [SerializeField] private GameObject campfireHalf;
    [SerializeField] private GameObject campfire;
    [SerializeField] private GameObject campfireParticles;
    [Header("Cooking")]
    [SerializeField] private GameObject cookPoint;
    [SerializeField, Range(0.1f, 3f)] private float cookSpeed;
    [SerializeField] private Material fishCookingMaterial;
    [SerializeField] private Color startColor, endColor;
    float startTime;

    private void OnEnable()
    {
        object1 = gameObject;
        startTime = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (object1.tag)
        {
            case "CampfireBase":
                switch (other.gameObject.tag)
                {
                    case "Stick":
                        object2 = other.gameObject;
                        Destroy(object2);
                        campfireHalf.SetActive(true);
                        object1.SetActive(false);
                        break;
                }
                break;
            case "CampfireHalf":
                switch (other.gameObject.tag)
                {
                    case "Leaves":
                        object2 = other.gameObject;
                        Destroy(object2);
                        campfire.SetActive(true);
                        object1.SetActive(false);
                        break;
                }
                break;
            case "Campfire":
                switch (other.gameObject.tag)
                {
                    case "Lighter":
                        campfireParticles.SetActive(true);
                        object1.tag = "CampfireLit";
                        break;
                }
                break;
            case "CampfireLit":
                switch (other.gameObject.tag)
                {
                    case "FishUncooked":
                        object2 = other.gameObject;
                        object2.transform.parent = cookPoint.transform;
                        object2.transform.position = cookPoint.transform.position;
                        object2.transform.rotation = cookPoint.transform.rotation;
                        object2.GetComponent<Rigidbody>().isKinematic = true;
                        object2.GetComponent<XRGrabInteractable>().enabled = false;
                        StartCoroutine(FishCook(object2.GetComponent<MeshRenderer>()));
                        break;
                }
                break;
        }
    }

    private IEnumerator FishCook(MeshRenderer fishObject)
    {
        fishObject.material = fishCookingMaterial;
        float tick = 0f;
        while (fishObject.material.color != endColor)
        {
            tick += Time.deltaTime * cookSpeed;
            fishObject.material.color = Color.Lerp(startColor, endColor, tick);
            yield return null;
        }
        object2.GetComponent<Rigidbody>().isKinematic = false;
        object2.tag = "FishCooked";
        object2.GetComponent<XRGrabInteractable>().enabled = true;
    }
}