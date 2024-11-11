using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{

    public GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {

        int count = 0;

        while(count <= 10)
        {
            Instantiate(prefab, transform.position + new Vector3(count * 3, 0, 0), transform.rotation);
            count++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //whenever B key hit we'll generate a prefab at the position of the original prefab
        //whenever Space key hit we'll generate a prefab at the position of the spawn object that this script is attached to

        if(Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(prefab);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }

    }
}
