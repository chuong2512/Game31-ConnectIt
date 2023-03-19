using System;
using System.Collections;
using System.Collections.Generic;
using ConnectIt;
using UnityEngine;

public class CreateLine : Singleton<CreateLine>
{
    public Color32[] colors;

    public LineConnect[] LineConnects;
    public Line[] CheckLines;

    public LineConnect currentLine;

    public void Create(Node node)
    {
        currentLine = LineConnects[node.index];

        currentLine.Clear();

        currentLine.AddStartPos(node.transform.position);
    }

    public void CreateEndPos(Node node)
    {
        currentLine.AddStartPos(node.transform.position);
    }


    private void AddNode(Node node)
    {
        Add(node.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool Add(Vector3 vector3)
    {
        return currentLine.AddPos(vector3);
    }

    public void Clear()
    {
        currentLine?.Clear();
    }

    public bool CheckGame()
    {
        for (int i = 0; i < LineConnects.Length; i++)
        {
            if (CheckLines[i].CheckFalse(LineConnects[i].listPos))
            {
                return false;
            }
        }

        return true;
    }

    public bool CheckPos(Vector3 transformPosition)
    {
        for (int i = 0; i < LineConnects.Length; i++)
        {
            if (LineConnects[i].listPos.Contains(transformPosition))
            {
                if (LineConnects[i].listPos[^1] != transformPosition)
                {
                    return false;
                }
            }
        }

        return true;
    }
}