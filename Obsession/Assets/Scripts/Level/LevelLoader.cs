using UnityEngine;
using System.Collections;


public class LevelLoader : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
        loadLevel(1);
	}

    public void loadLevel(int theLevelNumber)
    {
        /*LevelData levelData = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("LevelData" + theLevelNumber) as LevelData;
        levelData.initialize();
        GameObject level = Instantiate(Resources.Load("Prefabs/Level", typeof(GameObject))) as GameObject;
        level.name = "Level";
        level.GetComponent<LevelHandler>().setLevelData(levelData);*/
    }

}
