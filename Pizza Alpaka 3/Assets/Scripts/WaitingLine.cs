using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingLine : MonoBehaviour
{

    private List<Vector3> positionList;
    private Vector3 entrancePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CreateWaitingLine(List<Vector3> positionList)
    {
        this.positionList = positionList;
        entrancePosition = positionList[positionList.Count - 1] + new Vector3(-8f, 0);
        foreach (Vector3 position in positionList)
        {
          //  World_Sprite
        }
    }
}
