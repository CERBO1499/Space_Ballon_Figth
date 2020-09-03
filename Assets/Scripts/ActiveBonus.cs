using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBonus : MonoBehaviour
{
    [SerializeField] GameObject generatorBubble;
   private void OnTriggerExit(Collider other) {
       if(other.tag=="Player")
       {
            generatorBubble.GetComponent<BubbleGenerator>().enabled=true;
       }
       
   }
}
