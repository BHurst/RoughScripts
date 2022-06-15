using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityChaperone : MonoBehaviour
{
    public List<RootCharacter> previousTargets = new List<RootCharacter>();
    public List<RootCharacter> previouslyTargeted = new List<RootCharacter>();

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
            Destroy(gameObject);
    }
}