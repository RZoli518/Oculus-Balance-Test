using System.Collections;
using System.Collections.Generic;
using static OVRInput;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Update()
    {
        if (OVRInput.Get(Button.PrimaryIndexTrigger))
            SceneManager.LoadScene(1);
    }
}
