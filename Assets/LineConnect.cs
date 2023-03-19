using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class LineConnect : MonoBehaviour
{
    public List<Vector3> listPos = new List<Vector3>();

    public LineRenderer lineRenderer;

    void OnValidate()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void AddStartPos(Vector3 vector3)
    {
        if (!listPos.Contains(vector3))
        {
            listPos.Add(vector3);

            ShowLine();
        }
    }

    public bool AddPos(Vector3 vector3)
    {
        if (!listPos.Contains(vector3) && Check(vector3))
        {
            listPos.Add(vector3);

            ShowLine();

            return true;
        }

        return false;
    }

    private Vector2 tren = new Vector2(0,1);
    private Vector2 duoi = new Vector2(1, 0);
    private Vector2 trai = new Vector2(0, -1);
    private Vector2 phai = new Vector2(-1, 0);

    bool Check(Vector3 vector3)
    {
        var check = listPos[^1];

        if (vector3 + (Vector3) tren == check)
        {
            return true;
        }

        if (vector3 + (Vector3) duoi == check)
        {
            return true;
        }

        if (vector3 + (Vector3) trai == check)
        {
            return true;
        }

        if (vector3 + (Vector3) phai == check)
        {
            return true;
        }


        return false;
    }

    void ShowLine()
    {
        lineRenderer.positionCount = listPos.Count;
        lineRenderer.SetPositions(listPos.ToArray());
    }

    [Button]
    public void Test()
    {
        ShowLine();
    }

    public void Clear()
    {
        listPos = new List<Vector3>();
        ShowLine();
    }
}