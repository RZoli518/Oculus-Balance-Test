using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static OVRInput;

public class TeleportManager : MonoBehaviour
{
    public Transform[] teleportPositions;
    private int positionIdx = 0;
    private double maxInterval = 0.4; //how many seconds before an input.
    private float currentInterval = 0;
    void Start()
    {
        TeleportNextPosition();
    }
    void Update()
    {
        if (currentInterval <= 0)
        {
            if (IsButtonPressed())
            {
                positionIdx = IncrementTeleportPosition(positionIdx);
                TeleportNextPosition();
                currentInterval = (float)maxInterval;
            }
        }
        else
        {
            currentInterval -= Time.deltaTime;
        }
    }

    private void TeleportNextPosition() => gameObject.transform.SetPositionAndRotation(teleportPositions[positionIdx].position, gameObject.transform.rotation);

    private bool IsButtonPressed() => OVRInput.Get(Button.One) || OVRInput.Get(Button.Three);

    private int IncrementTeleportPosition(int idx)
    {
        idx++;
        if (idx == teleportPositions.Length) return 0;
        return idx;
    }
}