using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTeleporter : MonoBehaviour
{
    private ShortRangedTeleport SRT;
    private LongRangedTeleport LRT;
    public Canvas teleCanvas;

    private void Start()
    {
        SRT = GetComponent<ShortRangedTeleport>();
        LRT = GetComponent<LongRangedTeleport>();
    }
    public void TurnOnTelePowers()
    {
        SRT.enabled = !SRT.enabled;
        LRT.enabled = !LRT.enabled;
        teleCanvas.enabled = !teleCanvas.enabled;
    }
}
