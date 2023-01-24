using UnityEngine;

public static class Helpers
{
    #region TRANSFORM

        #region Position
        
        public static void SetPosX(this Transform t, float pos)
        {
            Vector3 position = t.position;
            position = new Vector3(pos, position.y, position.z);
            t.position = position;
        }

        public static void SetPosY(this Transform t, float pos)
        {
            Vector3 position = t.position;
            position = new Vector3(position.x, pos, position.z);
            t.position = position;
        }

        public static void SetLocalPosX(this Transform t, float pos)
        {
            Vector3 position = t.localPosition;
            position = new Vector3(pos, position.y, position.z);
            t.localPosition = position;
        }
        
        public static void SetLocalPosY(this Transform t, float pos)
        {
            Vector3 position = t.localPosition;
            position = new Vector3(position.x, pos, position.z);
            t.localPosition = position;
        }
        #endregion

        #region Scale

        public static void SetScale(this Transform t, float globalScale)
        {
            Vector3 scale = t.localScale;
            scale = new Vector3(globalScale, globalScale, globalScale);
            t.localScale = scale;
        }

        #endregion

    #endregion

    #region RECT TRANSFORM

        #region Size Delta

        public static void SetWidth(this RectTransform rt, float w)
        {
            rt.sizeDelta = new Vector2(w, rt.sizeDelta.y);
        }

        public static void SetHeight(this RectTransform rt, float h)
        {
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, h);
        }

        public static void SetSize(this RectTransform rt, float size)
        {            
            rt.sizeDelta = new Vector2(size, size);
        }

        public static float GetWidth(this RectTransform rt)
        {
            return rt.sizeDelta.x;
        }

        public static float GetHeight(this RectTransform rt)
        {
            return rt.sizeDelta.y;
        }


        #endregion

    #endregion
}
