using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lighter : MonoBehaviour
{
    [SerializeField] private XRController rightHand;
    [SerializeField] private InputHelpers.Button button;
    [SerializeField] private GameObject lighterParticles;

    // Update is called once per frame
    void Update()
    {
        bool pressed;
        rightHand.inputDevice.IsPressed(button, out pressed);

        if (pressed)
        {
            switch (lighterParticles.activeSelf)
            {
                case false:
                    lighterParticles.SetActive(true);
                    Debug.Log("Hello - " + button);
                    break;
            }
        }
        if (!pressed)
        {
            switch (lighterParticles.activeSelf)
            {
                case true:
                    lighterParticles.SetActive(false);
                    break;
            }
        }
    }
}
