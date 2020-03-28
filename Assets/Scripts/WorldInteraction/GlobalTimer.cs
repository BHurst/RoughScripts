using UnityEngine;
using System.Collections;

public class GlobalTimer : MonoBehaviour
{

    public static float globalTimer = 0;
    // Update is called once per frame
    void Update()
    {
        globalTimer += Time.deltaTime;
    }
}