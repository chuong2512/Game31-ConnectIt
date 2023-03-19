using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Line : MonoBehaviour
{
    [ReadOnly] public Node startNode, endNode;
    
    public Color Color;

    public mau[] Maus;

    private void OnValidate()
    {
        Maus = GetComponentsInChildren<mau>();
    }

    public void ShowGame(Node node1)
    {
        startNode = Instantiate(node1, Maus[0].transform.position, Quaternion.identity) as Node;
        endNode = Instantiate(node1, Maus[^1].transform.position, Quaternion.identity) as Node;
        
        startNode.transform.SetParent(Level.Instance.nodeTrans);
        endNode.transform.SetParent(Level.Instance.nodeTrans);
    }

    public void HideTutorial()
    {
        for (int i = 0; i < Maus.Length; i++)
        {
            Maus[i].gameObject.SetActive(false);
        }
    }
    
    public void ShowTutorial()
    {
        for (int i = 0; i < Maus.Length; i++)
        {
            Maus[i].gameObject.SetActive(true);
        }
    }

    public bool CheckFalse(List<Vector3> listPos)
    {
        if (!listPos.Contains(startNode.transform.position) && !listPos.Contains(endNode.transform.position))
        {
            return true;
        }

        return false;
    }
}
