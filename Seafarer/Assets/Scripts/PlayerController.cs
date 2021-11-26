using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void OnFoodChanged(int food, int deltaFood);
    public static OnFoodChanged onFoodChanged;

    public delegate void OnMoved(int toX, int toY);
    public static OnMoved onMoved;

    public int food = 30;
    public int appetite = 0;

    public GameObject splash;

    public static bool inControl = true;

    private float fishingTimer; 
    private bool canFish;

    private bool upArrow, downArrow, leftArrow, rightArrow;
    private Vector2 moveDir;

    void Start()
    {
        ResetFishingState();
    }

    void Update()
    {
        if (inControl)
        {
            moveDir = Vector2.zero;
            GetInput();
            Move();
        }

        if (!canFish)
        {
            fishingTimer += Time.deltaTime;
            if (fishingTimer >= 1f)
                canFish = true;
        }
    }

    void GetInput()
    {
        // movement
        upArrow = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        downArrow = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        leftArrow = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        rightArrow = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        if (upArrow)
            moveDir = new Vector2(0, 1);
        else if (downArrow)
            moveDir = new Vector2(0, -1);
        else if (leftArrow)
            moveDir = new Vector2(-1, 0);
        else if (rightArrow)
            moveDir = new Vector2(1, 0);

        // fishing
        if (Input.GetKeyDown(KeyCode.F))
            TryToFish();

    }

    #region Fishing
    private void ResetFishingState()
    {
        canFish = false;
        fishingTimer = 0;
    }

    private void TryToFish()
    {
        if (canFish)
        {
            Fish();
        }
    }

    private void Fish()
    {
        // calculate
        int r = Random.Range(0, 5);
        if (r > 0)
        {
            if (r > 3)
            {
                AddFood(5);
                NoticeMgr.Instance.ShowMessage("钓到大鱼。食物+5");
            }
            else
            {
                AddFood(3);
                NoticeMgr.Instance.ShowMessage("钓到小鱼。食物+3");
            }

        }
        else
        {
            NoticeMgr.Instance.ShowMessage("什么也没钓到");
        }

        ResetFishingState();
    }
    #endregion

    // 传送
    public void Teleport(Vector2 _destination)
    {
        Instantiate(splash, transform.position, Quaternion.identity);
        transform.position = new Vector3(_destination.x, _destination.y, 0);
        if (onMoved != null)
            onMoved((int)transform.position.x, (int)transform.position.y);
    }

    private bool CanMove()
    {
        if (moveDir != Vector2.zero) {
            if (food >= appetite) return true;
            else
            {
                NoticeMgr.Instance.ShowMessage("食物不足。按F钓鱼。");
                return false;
            }
        }
        return false;
    }

    private void Move()
    {
        if (CanMove())
        {
            Vector2 des = moveDir + new Vector2(transform.position.x, transform.position.y);
            Teleport(des);
            AddFood(-appetite);
        }

        if (moveDir.x != 0)
        {
            transform.localScale = new Vector3(-moveDir.x, 1f, 1f);
        }
    }

    private void AddFood(int _deltaFood)
    {
        food += _deltaFood;
        if (onFoodChanged != null)
            onFoodChanged(food, _deltaFood);
    }
}
