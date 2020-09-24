using UnityEngine;
using UnityEditor;

public class CMMenuItems
{
    [MenuItem("CM_Tools/Clear PlayerPrefs")]
    private static void NewMenuOption()
    {
        PlayerPrefs.DeleteAll();
    }
}