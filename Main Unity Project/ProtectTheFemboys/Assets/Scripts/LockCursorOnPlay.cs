using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursorOnPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Lock Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

}
