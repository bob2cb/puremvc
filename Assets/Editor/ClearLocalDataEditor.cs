#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class ClearLocalData
{
    [MenuItem("Tools/Clear Local Data", false, 150)]
    public static void clear()
    {
        Directory.Delete(Application.persistentDataPath, true);
        PlayerPrefs.DeleteAll();
        EditorUtility.DisplayDialog("清除缓存资源", "清除成功", "确定");
    }
}
#endif
