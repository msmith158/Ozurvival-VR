using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Axe : MonoBehaviour
{
    [SerializeField] private GameObject object2;
    [SerializeField] private Rigidbody firewoodPrefab;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Log":
                object2 = other.gameObject;
                Rigidbody firewoodPrefabInstance;
                firewoodPrefabInstance = Instantiate(firewoodPrefab, transform.position, transform.rotation);
                Destroy(object2);
                break;
        }
    }
}
