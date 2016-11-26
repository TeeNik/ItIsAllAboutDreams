using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {

    public List<GameObject> shouldBeDestroyed;

    public List<GameObject> shouldBeUsed;


    public void Start()
    {
        for(int i = 0; i < shouldBeDestroyed.Count; i++)
        {
            Destroy(shouldBeDestroyed[i]);
        }

        for (int i = 0; i < shouldBeUsed.Count; i++)
        {
            Destroy(shouldBeUsed[i]);
        }
    }
    
}
