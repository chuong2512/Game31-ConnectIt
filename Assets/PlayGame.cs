using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    private Button playBtn;
    
    // Start is called before the first frame update
    void Start()
    {
        playBtn = GetComponent<Button>();
        
        playBtn.onClick.AddListener(OpenScene);
    }

    private void OpenScene()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
