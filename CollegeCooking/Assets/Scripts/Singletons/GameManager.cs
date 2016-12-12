using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Add new foods to the bottom
using UnityEngine.Events;


public enum FoodType
{
	Butter,
	Cheese,
	Egg,
	EggYolk
}

/// <summary>
/// Handles main play cycle logic. Anything within game manager should happen during gameplay
/// and terminate when advancing to other menus.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    #region Fields
    //Assigned in inspector
    public Player lefthand;
    public Player righthand;
    public List<Sprite> taskSprites; //sprites of what tasks there are for the recipe
    public GameObject currentTaskIcon;

    //assigned in awake
    private int currentTaskNum;

	public UnityEvent winEvent = new UnityEvent();
    #endregion

    #region Properties
    #endregion

    protected GameManager() { }

    void Awake()
    {
        //set intial task num
        currentTaskNum = 0;

		winEvent.AddListener(Win);
    }

    public void StartGame()
    {
        //goto gamescreen off the bat
        MenuManager.Instance.GoToScreen("GameScreen");
    }

    /// <summary>
    /// Will be called in other places later on
    /// </summary>
    public void StartRound()
    {
    }

    /// <summary>
    /// goes to next task if we have completed the task act hand
    /// </summary>
    /// <param name="taskCompletedNum">index of the task that was done</param>
    public void NextTask(int taskCompletedNum)
    {
        //check the index' for the task that was completed vs what we were on
        if(currentTaskNum == taskCompletedNum)
        {
            //update current task index
            currentTaskNum++;

            //update spriterenderer on the current task icon
            currentTaskIcon.GetComponent<SpriteRenderer>().sprite = taskSprites[currentTaskNum];
        }
        
    }

    void Update()
    {


    }

	void Win()
	{
		//trigger whatever
		Debug.Log("Win");
	}
}
