using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   
   public Popupcode[] popupcodes;
   public Popupcode currentPopupcode;

   private void Awake()
   {
       if (instance == null)
         {
              instance = this;
         }
         else
         {
              Destroy(gameObject);
         }

         DontDestroyOnLoad(gameObject);
   }

   private void Start()
   {
    if(popupcodes.Length > 0 )
    {
        currentPopupcode = popupcodes[0];
    }
   }

   public void SetPopupcode(Popupcode popupcode)
   {
       currentPopupcode = popupcode;
   }
}
