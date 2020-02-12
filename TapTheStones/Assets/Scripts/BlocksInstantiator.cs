using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksInstantiator : MonoBehaviour
{
    // Start is called before the first frame update
    const float LEFTB = -6.37f, RIGHTB = -1.55f;
    public List<GameObject> blocksPrefabs;
    public int columnsCount = 1;
    void Start()
    {
        InvokeRepeating("InstantiateBlocks", 0, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateBlocks(){
        float yOffset = 4.50f;
        float xOffset = -3.5f;

        for(int i = 0; i < 7; i++){
            Instantiate(blocksPrefabs[Random.Range(0, blocksPrefabs.Count)], new Vector3(xOffset, yOffset, 0), Quaternion.identity);
            yOffset = yOffset - 1;
            //xOffset = xOffset - 1;
        }
    }
}
