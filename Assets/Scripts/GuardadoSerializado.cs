using System.Net.Mime;
using System.Data;
using System.Security;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuardadoSerializado : Singleton<GuardadoSerializado>
{ 


    
    [SerializeField] GameObject lvlFrame;
    [SerializeField] GameObject panelSelectorLevel;
     protected override void Awake(){
                    
    }
    private void Start() {
       
    }
   
   public void Guardar(int curLevel, float posx,float posy,float posz){
       BinaryFormatter fb = new BinaryFormatter();
       FileStream Expediente = File.Create(Application.persistentDataPath+"/dtAGuardar.d");
       DatosAGuardar dtAGuardar = new DatosAGuardar();

    //    dtAGuardar=fb.Deserialize(Expediente) as DatosAGuardar;

    //    dtAGuardar.MyCurrentLevel=Manager.Instance.CurrentLevel;
    //    dtAGuardar.MyXPos=Manager.Instance.SpawnPoint.x;
    //    dtAGuardar.MyYPos=Manager.Instance.SpawnPoint.y;
    //    dtAGuardar.MyZPos=Manager.Instance.SpawnPoint.z;

        dtAGuardar.MyCurrentLevel=curLevel;
        dtAGuardar.MyXPos=posx;
        dtAGuardar.MyYPos=posy;
        dtAGuardar.MyZPos=posz;

       fb.Serialize(Expediente,dtAGuardar);
       Expediente.Close();     
        print("Guarde current lvl" + dtAGuardar.MyCurrentLevel);
        PlayerPrefs.SetInt("FirstTime",1);
        PlayerPrefs.Save();

        // GameObject myLvlFrame = Instantiate(lvlFrame,panelSelectorLevel.transform);
        // ScreenCapture.CaptureScreenshot("pick1");
        // myLvlFrame.GetComponentInChildren<Image>().sprite=(Sprite)Resources.Load(Application.persistentDataPath+"/pick1.png");

    
       
   }

   public void Cargar(){
       if(File.Exists(Application.persistentDataPath+"/dtAGuardar.d")){
           BinaryFormatter fb = new BinaryFormatter();
           FileStream Expediente = File.OpenRead(Application.persistentDataPath+"/dtAGuardar.d");
           DatosAGuardar dtAGuardar = new DatosAGuardar();

           dtAGuardar=fb.Deserialize(Expediente)as DatosAGuardar;

           TrueGameManager.Instance.CurrentLevelGameManager=dtAGuardar.MyCurrentLevel;
           TrueGameManager.Instance.PosInicial= new Vector3(dtAGuardar.MyXPos,dtAGuardar.MyYPos,dtAGuardar.MyZPos);
           SceneManager.LoadScene("CMCompleteWorld",LoadSceneMode.Single);


           print("Cargue current lvl"+dtAGuardar.MyCurrentLevel);
       }
       else{
           print("No se encontro archivo");
       }      

   }
   

}

[Serializable()]
public class DatosAGuardar : System.Object {

    // private int myCurrentLevel = Manager.Instance.CurrentLevel;   
    // private Vector3 myPosInicial = new Vector3(); 

    // private float myXPos = Manager.Instance.SpawnPoint.x;
    //  private float myYPos = Manager.Instance.SpawnPoint.y;
    //   private float myZPos = Manager.Instance.SpawnPoint.z;
     private int myCurrentLevel = 0;   
    // spublic Vector3 myPosInicial = Manager.Instance.SpawnPoint; 

    private float myXPos =0;
     private float myYPos =0;
      private float myZPos = -0.52f;

      public int MyCurrentLevel { get => myCurrentLevel; set => myCurrentLevel = value; }    
    //    public Vector3 MyPosInicial { get => myPosInicial; set => myPosInicial = value; }    
      public float MyXPos { get => myXPos; set => myXPos = value; }    
      public float MyYPos { get => myYPos; set => myYPos = value; }    
      public float MyZPos { get => myZPos; set => myZPos = value; }    
public DatosAGuardar (){
    myCurrentLevel=0;
    myXPos=0;
    myYPos=0;
    myZPos=0;
}
    

} 
