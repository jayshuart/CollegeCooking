using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Add new foods to the bottom
public enum FoodType
{
	Butter,
	Cheese
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
    #endregion

    #region Properties
    #endregion

    protected GameManager() { }

    void Awake()
    {
    }

    public void StartGame()
    {
        MenuManager.Instance.GoToScreen("GameScreen");
    }

    /// <summary>
    /// Will be called in other places later on
    /// </summary>
    public void StartRound()
    {
    }



    void Update()
    {


    }
}
