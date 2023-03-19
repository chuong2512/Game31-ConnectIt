using System.Collections;
using System.Collections.Generic;
using ConnectIt;
using Sirenix.OdinInspector;
using UnityEngine;

public class Level : Singleton<Level>
{
    public Transform nodeTrans;

    public Node[] nodes;

    public Line[] lines;

    public oVuong[] OVuongs;

    private void OnValidate()
    {
        OVuongs = GetComponentsInChildren<oVuong>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        ShowGame();
        HideTutorial();
    }

    private void ShowGame()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].ShowGame(nodes[i]);
        }
    }

    [Button]
    public void HideTutorial()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].HideTutorial();
        }
    }
    
    [Button]
    public void ShowTutorial()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].ShowTutorial();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
