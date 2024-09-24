using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static OVRInput;

public class TeleportManager : MonoBehaviour
{
    public Transform[] teleportPositions;
    private int positionIdx = 0;
    private int maxInterval = 1;
    private float currentInterval = 0;
    void Update()
    {
        Debug.Log(IsButtonPressed());
        if (currentInterval <= 0)
        {
            if (IsButtonPressed())
            {
                TeleportNextPosition();
            }
            currentInterval = maxInterval;
        }
        else
        {
            currentInterval -= Time.deltaTime;
        }
    }

    private void TeleportNextPosition() => transform.position = teleportPositions[IncrementTeleportPosition(positionIdx)].position;

    private bool IsButtonPressed() => OVRInput.Get(Button.One) || OVRInput.Get(Button.Two);

    private int IncrementTeleportPosition(int idx)
    {
        idx++;
        if (idx > teleportPositions.Length) return 0;
        return idx;
    }
}