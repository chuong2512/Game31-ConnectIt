using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JumpFrog;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum State
{
    Jumping, Stop
}

public class GameUI : Singleton<GameUI>
{
    public Button back;
    public Button jump;
    public Button back1;
    public Button menu;
    public background bg;

    private GameObject level;
    public GameObject lose;
    public GameObject[] levels;

    public State currentState;

    public Slider SliderJump;
    
    // Start is called before the first frame update
    void Start()
    {
        RandomLevel();

        UpdateSlider();
        
        back.onClick.AddListener(ExitGame);
        back1.onClick.AddListener(ExitGame);
        jump.onClick.AddListener(Jump);
        menu.onClick.AddListener(RestartGame);
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowLose()
    {
        lose.SetActive(true);
    }

    public void RestartGame()
    {
        lose.SetActive(false);
        NextLevel();
    }

    public void NextLevel()
    {
        bg.Show();
        RandomLevel();
    }

    private void RandomLevel()
    {
        SetState(State.Stop);
        
        if (level != null)
        {
            Destroy(level);
        }

        level = Instantiate(levels[Random.Range(0, levels.Length)]);
    }

    [Button]
    public void Jump()
    {
        SliderJump.DOKill(SliderJump.transform);
        
        SetState(State.Jumping);
        
        Ech.Instance.FrogJump(SliderJump.value * 250 + 100);
        
        SliderJump.gameObject.SetActive(false);
    }

    private float duration = 1f;
    
    void UpdateSlider()
    {
        SliderJump.DOKill(SliderJump.transform);
        SliderJump.value = 0;
        SliderJump.DOValue(1, duration).OnComplete(() => SliderJump.DOValue(0, duration)).SetEase(Ease.Linear).SetLoops(-1);
    }
    
    public void EndJump()
    {
        SetState(State.Stop);
        
        SliderJump.gameObject.SetActive(true);
        UpdateSlider();
    }

    public void SetState(State state)
    {
        currentState = state;
        
        jump.gameObject.SetActive(state == State.Stop);
    }
}