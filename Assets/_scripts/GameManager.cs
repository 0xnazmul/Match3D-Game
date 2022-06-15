using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour

{
   [SerializeField]
   private Transform twinsField;

   public GameObject [] faceGameObjects;
   

   private void Start() 
   { 

      SpawnTwins();
      SpawnTwins1();
      SpawnTwins2();
      SpawnTwins3();
      SpawnTwins4();
      SpawnTwins5();


      

   }

   void SpawnTwins()
   { 
      int index = Random.Range(0, faceGameObjects.Length);
      Vector3 spawnPosition = new Vector3(120, 203, 0);
      Instantiate(faceGameObjects[index], spawnPosition, Quaternion.identity);
      
   }

   void SpawnTwins1()
   { 
      int randomObstacle = Random.Range(0, 8);
      Vector3 spawnPosition = new Vector3(120, 122, 0);

      Instantiate(faceGameObjects[randomObstacle], spawnPosition, Quaternion.identity);

   }
   void SpawnTwins2()
   { 
      int randomObstacle = Random.Range(0, 8);
      Vector3 spawnPosition = new Vector3(111, -39, 0);
      Instantiate(faceGameObjects[randomObstacle], spawnPosition, Quaternion.identity);
   }
   void SpawnTwins3()
   { 
      int randomObstacle = Random.Range(0, 8);
      Vector3 spawnPosition = new Vector3(-5, 28, 0);
      Instantiate(faceGameObjects[randomObstacle], spawnPosition, Quaternion.identity);
   }
   void SpawnTwins4()
   { 
      int randomObstacle = Random.Range(0, 8);
      Vector3 spawnPosition = new Vector3(6, 175, 0);
      Instantiate(faceGameObjects[randomObstacle], spawnPosition, Quaternion.identity);
   }
   void SpawnTwins5()
   { 
      int randomObstacle = Random.Range(0, 8);
      Vector3 spawnPosition = new Vector3(-7, -85, 0);
      Instantiate(faceGameObjects[randomObstacle], spawnPosition, Quaternion.identity);



   }
            
}
