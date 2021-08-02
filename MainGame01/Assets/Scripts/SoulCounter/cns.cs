using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cns : MonoBehaviour
{
    public Sprite soul;
    // Start is
    // called before the first frame update
    void Start()
    {
        for(int i = 0; i < 7; i++)
        {
            GameObject j = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            j.transform.position = new Vector2(Random.Range(-14.5f, 1.5f ),Random.Range(-2.5f, 2.5f ));
            j.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = j.GetComponent<SpriteRenderer>();
            sr.sprite = soul;
            j.AddComponent<SoulCounterSouls>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
