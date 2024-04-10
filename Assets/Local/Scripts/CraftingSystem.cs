using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class CraftingSystem : MonoBehaviour
{
    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    [SerializeField] private Rigidbody axePrefab;
    [SerializeField] private Rigidbody campfirePrefab;
    private bool isActivated;

    private void Start()
    {
        object1 = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Stone":
                object2 = other.gameObject;
                Rigidbody axePrefabInstance;
                axePrefabInstance = Instantiate(axePrefab, transform.position, transform.rotation);
                Destroy(object2);
                Destroy(object1);
                break;
            case "Log":
                object2 = other.gameObject;
                Rigidbody campfirePrefabInstance;
                campfirePrefabInstance = Instantiate(campfirePrefab, transform.position, transform.rotation);
                Destroy(object2);
                Destroy(object1);
                break;
        }
    }
}