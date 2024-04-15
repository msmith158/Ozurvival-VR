using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class FloorTrackingFix : MonoBehaviour
{
    private XRInputSubsystem xrInputSubsystem;
    private int loopCount = 0;
    [SerializeField] private int retries;

    // Start is called before the first frame update
    void Start()
    {
        xrInputSubsystem = GetXRInputSubsystem();
    }

    // Update is called once per frame
    void Update()
    {
        // Try to set tracking origin mode to floor a certain amount of times. If limit reached, disable script to reduce active if/else calls.
        if (loopCount < retries)
        {
            xrInputSubsystem.TrySetTrackingOriginMode(TrackingOriginModeFlags.Floor);
            loopCount++;
        }
        else if (loopCount >= retries)
        {
            enabled = false;
        }
    }

    private XRInputSubsystem GetXRInputSubsystem()
    {
        List<XRInputSubsystem> subsystems = new List<XRInputSubsystem>();
        SubsystemManager.GetInstances(subsystems);
        return subsystems.FirstOrDefault();
    }
}
