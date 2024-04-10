using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class CraftingSystem : MonoBehaviour
{
    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    [SerializeField] private Rigidbody resultPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stone"))
        {
            Rigidbody prefabInstance;
            prefabInstance = Instantiate(resultPrefab, this.transform.position, this.transform.rotation);
            object2.SetActive(false);
            object1.SetActive(false);
        }
    }
}
