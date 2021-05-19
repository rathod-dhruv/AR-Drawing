using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARDraw : MonoBehaviour
{
    Camera arCamera;

    Vector3 anchor = new Vector3(0,0,0.3f);

    bool anchorUpdate = false;
    //should anchor update or not

    public GameObject linePrefab;
    //prefab which genrate the line for user

    LineRenderer lineRenderer;
    //LineRenderer which connects and generate

    public List<LineRenderer> lineList = new List<LineRenderer>();
    //List of lines drawn

    public Transform linePool;
    
    public bool use;
    //code is in use or not

    public bool startLine;
    //already started line or not


    void Start()
    {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (use)
        {
            if (startLine)
            {   
                UpdateAnchor();
                DrawLinewContinue();
            }
        }
    }

    void UpdateAnchor()
    {   
        if(anchorUpdate)
        {
            Vector3 temp = Input.mousePosition;
            temp.z = 0.3f;
            anchor = arCamera.ScreenToWorldPoint(temp);
        }
    }


    public void MakeLineRenderer()
    {
        GameObject tempLine = Instantiate(linePrefab);
        tempLine.transform.SetParent(linePool);
        tempLine.transform.position = Vector3.zero;
        tempLine.transform.localScale = new Vector3(1, 1, 1);
        
        anchorUpdate = true;
        UpdateAnchor();

        lineRenderer = tempLine.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, anchor);

        startLine = true;
        lineList.Add(lineRenderer);
    }

    public void DrawLinewContinue()
    {
        lineRenderer.positionCount = lineRenderer.positionCount + 1;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, anchor);
    }

    public void StartDrawLine()
    {
        use = true;

        if (!startLine)
        {
            MakeLineRenderer();
        }
    }

    public void StopDrawLine()
    {
        use = false;
        startLine = false;
        lineRenderer = null;
        
        anchorUpdate = false;
    }

    public void Undo()
    {
        LineRenderer undo = lineList[lineList.Count-1];
        Destroy(undo.gameObject);
        lineList.RemoveAt(lineList.Count - 1);
    }

    public void ClearScreen()
    {
        foreach (LineRenderer item in lineList)
        {
            Destroy(item.gameObject);
        }
        lineList.Clear();
    }

    
}