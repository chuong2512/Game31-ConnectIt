using DG.Tweening;
using ConnectIt;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum State
{
    Playing = 0,
    Win,
    ChooseColor,
    Choosing,
    EndChoose,
}

public class GameUI : Singleton<GameUI>
{
    public Button back1;
    public Button menu;
    public background bg;

    private GameObject level;
    public GameObject[] levels;
    public GameObject lose, win;

    public State currentState;

    private Node chooseNode = null;

    // Start is called before the first frame update
    void Start()
    {
        SetState(State.ChooseColor);

        RandomLevel();

        back1.onClick.AddListener(ExitGame);
        menu.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CheckStartChoose())
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider)
            {
                Debug.Log($"{hit.collider.transform.gameObject.name}");

                /////This is where I look for the gameObjects with the PlanetSelection components.
                Node hitObject = hit.collider.transform.GetComponent<Node>();

                if (hitObject != null)
                {
                    Debug.Log($"Index : {hitObject.index}");

                    CreateLine.Instance.Create(hitObject);
                    chooseNode = hitObject;
                    SetState(State.Choosing);
                }
            }
            else
            {
                ClearSelection();
            }


            return;
        }

        if (Input.GetMouseButton(0) && CheckChoosing())
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider)
            {
                Debug.Log($"{hit.collider.transform.gameObject.name}");

                /////This is where I look for the gameObjects with the PlanetSelection components.
                oVuong hitObject = hit.collider.transform.GetComponent<oVuong>();

                if (hitObject != null)
                {
                    if (CreateLine.Instance.CheckPos(hitObject.transform.position))
                    {
                        if (!CreateLine.Instance.Add(hitObject.transform.position))
                        {
                            if (CreateLine.Instance.currentLine.listPos[^1] != hitObject.transform.position)
                            {
                                CreateLine.Instance.Clear();
                                ClearSelection();
                            }
                        }
                    }
                    else
                    {
                        CreateLine.Instance.Clear();
                        ClearSelection();
                    }

                    return;
                }

                Node endNode = hit.collider.transform.GetComponent<Node>();

                if (endNode != null && endNode != chooseNode)
                {
                    if (CheckNode(endNode.index))
                    {
                        CreateLine.Instance.CreateEndPos(endNode);
                        CheckGame();
                    }
                    else
                    {
                        CreateLine.Instance.Clear();
                    }

                    ClearSelection();
                }
            }

            return;
        }

        if (Input.GetMouseButtonUp(0) && CheckChoosing())
        {
            CreateLine.Instance.Clear();
            ClearSelection();
        }
    }

    private void CheckGame()
    {
        if (CreateLine.Instance.CheckGame())
        {
            SetState(State.Win);
            win.SetActive(true);
        }
        else
        {
            Debug.Log("Chua Win nhe");
        }
    }

    private void ClearSelection()
    {
        SetState(State.ChooseColor);
        chooseNode = null;
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public bool CheckNode(int index)
    {
        return chooseNode.index == index;
    }

    public void ShowLose()
    {
        lose.SetActive(true);
    }

    public void ShowTutorial()
    {
        if (GameDataManager.Instance.playerData.helpCount >= 1)
        {
            PurchasingManager.Instance.Sub(1);
            Level.Instance.ShowTutorial();
        }
        else
        {
            muaBan.SetActive(true);
        }
    }

    public GameObject muaBan;

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Game");
    }

    private void RandomLevel()
    {
        level = Instantiate(levels[Random.Range(0, levels.Length)]);
    }


    public void SetState(State state)
    {
        currentState = state;
    }

    public bool CheckChoosing()
    {
        return currentState == State.Choosing;
    }

    public bool CheckStartChoose()
    {
        return currentState == State.ChooseColor;
    }
}