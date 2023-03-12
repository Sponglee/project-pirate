using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : ControlBase
{
    [Header("AIMovementControls")]
    public float internalTimer = 0f;
    public float decsisionTimer = 1f;
    public float jumpRandomizeTreshold = 30f;

}
