using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/// <summary>
/// Loads all scenes as levels and stores their data
/// </summary>
public class LevelManager : Singleton<LevelManager>
{
	#region Fields
	List<GameObject> levels = new List<GameObject>();
    int level = 0;
	#endregion

	#region Properties

	#endregion

	protected LevelManager(){}

	void Awake()
	{
		
	}

    /// <summary>
    /// starts round, and moves us to the next level
    /// </summary>
    public void NextLevel()
    {
        //turn off current level
        levels[level].SetActive(false);

        //up the current level
        level++;

        if (level == levels.Count) //check if we are at the end of the levels
        {
            level = 0; //goto beginign again
        }

        //set the new current level active
        levels[level].SetActive(true);
    }
}
