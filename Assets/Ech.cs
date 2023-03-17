using System.Collections;
using System.Collections.Generic;
using JumpFrog;
using Sirenix.OdinInspector;
using UnityEngine;

public class Ech : Singleton<Ech>
{
    [SerializeField] private SpriteRenderer anh;
    private GameDataManager gameData;

    public Rigidbody2D rigidbody;

    void Start()
    {
        gameData = GameDataManager.Instance;
    }

    private void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    [Button]
    public void FrogJump(float power)
    {
        rigidbody.constraints = RigidbodyConstraints2D.None;
        /*anh.sprite = gameData.anh[gameData.playerData.currentSkin * 2 + 1];*/
        anh.sprite = gameData.anh[1];
        rigidbody.AddForce(Vector2.one * power, ForceMode2D.Force);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*anh.sprite = gameData.anh[gameData.playerData.currentSkin * 2];*/
        anh.sprite = gameData.anh[0];
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        
        GameUI.Instance.EndJump();
    }

    // Update is called once per frame
    void Update()
    {
    }
}