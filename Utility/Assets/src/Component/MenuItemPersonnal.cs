using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuItemPersonnal
{
    private const string kUILayerName = "UI";
    
#if UNITY_EDITOR

    [MenuItem("GameObject/UI/Mobile Cursor", priority = 10)]
    public static void CreateMobileCursor(MenuCommand menuCommand)
    {
        Object mobileCursor = AssetDatabase.LoadAssetAtPath("Assets/src/Component/Gameplay/Mobile/Prefab/Mobile Cursor Controller.prefab", typeof(object));
        GameObject obj = (GameObject) PrefabUtility.InstantiatePrefab(mobileCursor);
        PrefabUtility.UnpackPrefabInstance(obj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
        
       
        
        #region CANVAS CHECK

        if (Selection.activeGameObject == null)
        {
            Canvas canvas = GameObject.FindObjectOfType<Canvas>();

            if (canvas == null)
            {
                var go = CreateNewUI();
                    
                GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
                if (go.transform.parent as RectTransform)
                {
                    RectTransform rect = go.transform as RectTransform;
                    rect.anchorMin = Vector2.zero;
                    rect.anchorMax = Vector2.one;
                    rect.anchoredPosition = Vector2.zero;
                    rect.sizeDelta = Vector2.zero;
                }
                Selection.activeGameObject = go;
                
                canvas = go.GetComponent<Canvas>();
            }

            obj.transform.SetParent(canvas.transform);
            obj.transform.localPosition = Vector3.zero;
        }
        else
        {
            if (Selection.activeGameObject.GetComponent<Canvas>())
            {
                obj.transform.SetParent(Selection.activeGameObject.transform);
            }
            else
            {
                Canvas canvas = GameObject.FindObjectOfType<Canvas>();

                if (canvas == null)
                {
                    var go = CreateNewUI();
                    
                    GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
                    if (go.transform.parent as RectTransform)
                    {
                        RectTransform rect = go.transform as RectTransform;
                        rect.anchorMin = Vector2.zero;
                        rect.anchorMax = Vector2.one;
                        rect.anchoredPosition = Vector2.zero;
                        rect.sizeDelta = Vector2.zero;
                    }
                    Selection.activeGameObject = go;

                    canvas = go.GetComponent<Canvas>();
                }

                obj.transform.SetParent(canvas.transform);
                obj.transform.localPosition = Vector3.zero;
            }
        }

        #endregion

        Undo.RegisterCreatedObjectUndo(obj, "Create Mobile Cursor");
        
        RectTransform objRect = obj.GetComponent<RectTransform>();
        objRect.sizeDelta = new Vector2(0, 0);
        objRect.localScale = new Vector3(1, 1, 1);
        
        Selection.activeGameObject = obj;
    }

    
    private static GameObject CreateNewUI()
    {
        // Root for the UI
        var root = ObjectFactory.CreateGameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        root.layer = LayerMask.NameToLayer(kUILayerName);
        Canvas canvas = root.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        
        CanvasScaler canvasScaler = root.GetComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = new Vector2(1920, 1080);
        canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        canvasScaler.matchWidthOrHeight = 0.5f;
        
        // Works for all stages.
        StageUtility.PlaceGameObjectInCurrentStage(root);
        bool customScene = false;
        PrefabStage prefabStage = PrefabStageUtility.GetCurrentPrefabStage();
        if (prefabStage != null)
        {
            Undo.SetTransformParent(root.transform, prefabStage.prefabContentsRoot.transform, "");
            customScene = true;
        }

        Undo.SetCurrentGroupName("Create " + root.name);

        // If there is no event system add one...
        // No need to place event system in custom scene as these are temporary anyway.
        // It can be argued for or against placing it in the user scenes,
        // but let's not modify scene user is not currently looking at.
        if (!customScene)
            CreateEventSystem(false);
        return root;
    }
    private static void CreateEventSystem(bool select)
    {
        CreateEventSystem(select, null);
    }
    private static void CreateEventSystem(bool select, GameObject parent)
    {
        StageHandle stage = parent == null ? StageUtility.GetCurrentStageHandle() : StageUtility.GetStageHandle(parent);
        var esys = stage.FindComponentOfType<EventSystem>();
        if (esys == null)
        {
            var eventSystem = ObjectFactory.CreateGameObject("EventSystem");
            if (parent == null)
                StageUtility.PlaceGameObjectInCurrentStage(eventSystem);
            else
                GameObjectUtility.SetParentAndAlign(eventSystem, parent);
            esys = ObjectFactory.AddComponent<EventSystem>(eventSystem);
            ObjectFactory.AddComponent<StandaloneInputModule>(eventSystem);

            Undo.RegisterCreatedObjectUndo(eventSystem, "Create " + eventSystem.name);
        }

        if (select && esys != null)
        {
            Selection.activeGameObject = esys.gameObject;
        }
    }

#endif
}
