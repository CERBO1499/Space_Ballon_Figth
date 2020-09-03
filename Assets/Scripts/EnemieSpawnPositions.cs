using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class EnemieSpawnPositions : MonoBehaviour
{

    [SerializeField] public ElvlType _lvlType;
    [SerializeField]GameObject [] enemies;   

    EnemiIA  [] enemiIA;

    private void Start() {   


        
        chekLevelEnemie();

    }



    void chekLevelEnemie(){

        switch (_lvlType)
        {
            case ElvlType.Uno:
            enemies=GameObject.FindGameObjectsWithTag("1");
            enemiIA=new EnemiIA[enemies.Length];

             for (int i = 0; i < enemies.Length; i++)
             {
              enemiIA[i]=enemies[i].GetComponent<EnemiIA>();
              enemiIA[i].minX=-7f;
              enemiIA[i].maxX=7f;
              enemiIA[i].minY=-9.18f;
              enemiIA[i].maxY=7.61f;

              enemiIA[i].currentLvlEnemie=1;
            }    
            break;

            case ElvlType.dos:
            enemies=GameObject.FindGameObjectsWithTag("2");
            enemiIA=new EnemiIA[enemies.Length];

             for (int i = 0; i < enemies.Length; i++)
             {
              enemiIA[i]=enemies[i].GetComponent<EnemiIA>();
              enemiIA[i].minX=-7f;
              enemiIA[i].maxX=7f;
              enemiIA[i].minY=14.28f;
              enemiIA[i].maxY=49.2f;


               enemiIA[i].currentLvlEnemie=2;
             }
            
            break;

            case ElvlType.tres:
            enemies=GameObject.FindGameObjectsWithTag("3");
            enemiIA=new EnemiIA[enemies.Length];

             for (int i = 0; i < enemies.Length; i++)
             {
              enemiIA[i]=enemies[i].GetComponent<EnemiIA>();
              enemiIA[i].minX=-7f;
              enemiIA[i].maxX=7f;
              enemiIA[i].minY=56.96f;
              enemiIA[i].maxY=78.53f;

               enemiIA[i].currentLvlEnemie=3;
             }
            break;
            case ElvlType.cuatro:
            enemies=GameObject.FindGameObjectsWithTag("4");
            enemiIA=new EnemiIA[enemies.Length];

             for (int i = 0; i < enemies.Length; i++)
             {
              enemiIA[i]=enemies[i].GetComponent<EnemiIA>();
              enemiIA[i].minX=-7f;
              enemiIA[i].maxX=7f;
              enemiIA[i].minY=86.38f;
              enemiIA[i].maxY=112.95f;

                             enemiIA[i].currentLvlEnemie=4;

             }
            break;
            case ElvlType.cinco:
            enemies=GameObject.FindGameObjectsWithTag("5");
            enemiIA=new EnemiIA[enemies.Length];

             for (int i = 0; i < enemies.Length; i++)
             {
              enemiIA[i]=enemies[i].GetComponent<EnemiIA>();
              enemiIA[i].minX=-7f;
              enemiIA[i].maxX=7f;
              enemiIA[i].minY=156f;
              enemiIA[i].maxY=194.56f;


                enemiIA[i].currentLvlEnemie=5;

             }
            break;
            case ElvlType.seis:
            enemies=GameObject.FindGameObjectsWithTag("6");
            enemiIA=new EnemiIA[enemies.Length];

             for (int i = 0; i < enemies.Length; i++)
             {
              enemiIA[i]=enemies[i].GetComponent<EnemiIA>();
              enemiIA[i].minX=-7f;
              enemiIA[i].maxX=7f;
              enemiIA[i].minY=202.86f;
              enemiIA[i].maxY=231.39f;

            enemiIA[i].currentLvlEnemie=6;

             }
            break;
            case ElvlType.siete:
            enemies=GameObject.FindGameObjectsWithTag("7");
            enemiIA=new EnemiIA[enemies.Length];

             for (int i = 0; i < enemies.Length; i++)
             {
              enemiIA[i]=enemies[i].GetComponent<EnemiIA>();
              enemiIA[i].minX=-7f;
              enemiIA[i].maxX=7f;
              enemiIA[i].minY=239.03f;
              enemiIA[i].maxY=269.11f;

                enemiIA[i].currentLvlEnemie=7;

             }
            break;
            case ElvlType.ocho:
            enemies=GameObject.FindGameObjectsWithTag("8");
            enemiIA=new EnemiIA[enemies.Length];

             for (int i = 0; i < enemies.Length; i++)
             {
              enemiIA[i]=enemies[i].GetComponent<EnemiIA>();
              enemiIA[i].minX=-7f;
              enemiIA[i].maxX=7f;
              enemiIA[i].minY=277.29f;
              enemiIA[i].maxY=307.14f;

             enemiIA[i].currentLvlEnemie=8;

             }
            break;
            case ElvlType.nueve:
            enemies=GameObject.FindGameObjectsWithTag("9");
            enemiIA=new EnemiIA[enemies.Length];

             for (int i = 0; i < enemies.Length; i++)
             {
              enemiIA[i]=enemies[i].GetComponent<EnemiIA>();
              enemiIA[i].minX=-7f;
              enemiIA[i].maxX=7f;
              enemiIA[i].minY=315f;
              enemiIA[i].maxY=341.17f;
            enemiIA[i].currentLvlEnemie=9;

             }
            break;
            case ElvlType.diez:
            enemies=GameObject.FindGameObjectsWithTag("10");
            enemiIA=new EnemiIA[enemies.Length];

             for (int i = 0; i < enemies.Length; i++)
             {
              enemiIA[i]=enemies[i].GetComponent<EnemiIA>();
              enemiIA[i].minX=-7f;
              enemiIA[i].maxX=7f;
              enemiIA[i].minY=394.6f;
              enemiIA[i].maxY=443f;


                enemiIA[i].currentLvlEnemie=10;

             }
            break;






           
        }
         

        }


        public void _typeLvl(ElvlType lvlType){
            lvlType=_lvlType;
            
        }

       



    
       

    }
    



        



        

                










        

    





    

