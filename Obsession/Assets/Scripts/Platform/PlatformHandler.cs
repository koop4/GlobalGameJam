using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class PlatformHandler : MonoBehaviour {

    private enum RectDirection { Left, Right, Up, Down }

    public enum Model { Fixed = 0, Rectangular = 1, Circular = 2, Spinner = 3}

    public Model model = 0;

    public float time = 0.01f;

    public float step = 0.1f;

    public float deltaX, deltaY = 0.0f;

    


    private Vector2 startPosition;

    private RectDirection rectDirection;


    void Awake()
    {
        if (time <= 0)
            time = 0.01f;
        startPosition = transform.position; 
        if (model.Equals(Model.Rectangular))
            StartCoroutine(moveRectangular());
        else
            if (model.Equals(Model.Circular))
                StartCoroutine(moveCircular());
            else
            if (model.Equals(Model.Spinner))
                StartCoroutine(moveSpinner());
    }
    private IEnumerator moveRectangular()
    {
        rectDirection = RectDirection.Right;
        while (true)
        {
            bool end = true;
            switch (rectDirection)
            {
                case RectDirection.Left:
                    gameObject.transform.position = gameObject.transform.position + new Vector3(-step, 0, 0);
                    break;
                case RectDirection.Right:
                    gameObject.transform.position = gameObject.transform.position + new Vector3(step, 0, 0);
                    break;
                case RectDirection.Up:
                    gameObject.transform.position = gameObject.transform.position + new Vector3(0, step, 0);
                    break;
                case RectDirection.Down:
                    gameObject.transform.position = gameObject.transform.position + new Vector3(0, -step, 0);
                    break;
            }
            if ((gameObject.transform.position.x - startPosition.x >= deltaX) && (rectDirection == RectDirection.Right))
                rectDirection = RectDirection.Up;
            else
                if ((gameObject.transform.position.x <= startPosition.x) && (rectDirection == RectDirection.Left))
                    rectDirection = RectDirection.Down;
                else
                    if ((gameObject.transform.position.y - startPosition.y >= deltaY) && (rectDirection == RectDirection.Up))
                        rectDirection = RectDirection.Left;
                    else
                        if ((gameObject.transform.position.y <= startPosition.y) && (rectDirection == RectDirection.Down))
                            rectDirection = RectDirection.Right;
                        else
                            end = false;
            if (end)
                if (deltaY == 0)
                {
                    if (rectDirection == RectDirection.Up)
                        rectDirection = RectDirection.Left;
                    else
                        if (rectDirection == RectDirection.Down)
                            rectDirection = RectDirection.Right;
                }
                else
                    if (deltaX == 0)
                        if (rectDirection == RectDirection.Left)
                            rectDirection = RectDirection.Down;
                        else
                            if (rectDirection == RectDirection.Right)
                                rectDirection = RectDirection.Up;
                
            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator moveCircular()
    {
        float alpha = 0.0f;
        while (true)
        {
            gameObject.transform.position = new Vector2(startPosition.x + deltaX * Mathf.Cos(alpha * 0.005f), startPosition.y + deltaY * Mathf.Sin(alpha * 0.005f));
            alpha += step;
            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator moveSpinner()
    {
        int inc = 1;
        int counter = 35;
        gameObject.transform.Rotate(0, 0, -35);
        while (true)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, inc));
            if (counter == 70)
            {
                counter = 0;
                inc = -inc;
            }
            counter++;
            yield return new WaitForSeconds(time);
        }
    }

#if UNITY_EDITOR

    [CustomEditor(typeof(PlatformHandler))]
    public class PlatformHandlerEditor : Editor
    {
        public SerializedProperty
        model_Prop,
        time_Prop,
        deltaX_Prop,
        deltaY_Prop,
        step_Prop;
        

        void OnEnable()
        {
            // Setup the SerializedProperties

            model_Prop = serializedObject.FindProperty("model");
            /*deltaX_Prop = serializedObject.FindProperty("deltaX");
            deltaY_Prop = serializedObject.FindProperty("deltaY");
            time_Prop = serializedObject.FindProperty("time");*/
        }

        public override void OnInspectorGUI()
        {
            //serializedObject.Update();
            EditorGUILayout.PropertyField(model_Prop);
            PlatformHandler.Model m = (PlatformHandler.Model)model_Prop.enumValueIndex;

            
            if (m != Model.Fixed)
            {
                SerializedProperty t = serializedObject.FindProperty("time");
                EditorGUILayout.PropertyField(t);
                if (m == Model.Circular || m == Model.Rectangular)
                {
                    SerializedProperty dX = serializedObject.FindProperty("deltaX");
                    SerializedProperty dY = serializedObject.FindProperty("deltaY");
                    EditorGUILayout.PropertyField(dX);
                    EditorGUILayout.PropertyField(dY);
                    SerializedProperty s = serializedObject.FindProperty("step");
                    EditorGUILayout.PropertyField(s);
                }
                
                
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}
