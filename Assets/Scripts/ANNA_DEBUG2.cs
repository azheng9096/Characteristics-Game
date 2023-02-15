using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANNA_DEBUG2 : MonoBehaviour
{
    [SerializeField] GameObject DebugUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M) && Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.B)) {
            DebugUI.SetActive(!DebugUI.activeInHierarchy);
        }
    }
}
