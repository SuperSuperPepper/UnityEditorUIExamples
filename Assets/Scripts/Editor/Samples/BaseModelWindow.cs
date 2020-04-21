using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

enum ExampleFlagsEnum
{
    None = 0, // Custom name for "Nothing" option
    A = 1 << 0,
    B = 1 << 1,
    AB = A | B, // Combination of two flags
    C = 1 << 2,
    All = ~0, // Custom name for "Everything" option
}

public class BaseModelWindow : SamplesBaseEditorWindow
{
   
    [MenuItem("SEditorTools/基础功能窗口入口")]
    public static void OpenWindow()
    {
        var window = EditorWindow.GetWindow<BaseModelWindow>();
        window.Show();
        //window.ShowAsDropDown(new Rect(),new Vector2(300, 600));
    }

    private void OnEnable()
    {
        Title = "基础功能窗口";
        Description = "最基础的编辑器控件，主要为一些赋值控件";

    }

    Bounds bounds;
    BoundsInt boundsInt;
    AnimationCurve curve = new AnimationCurve();

    bool toggle;
    bool toggleLeft;


    double delayedDou;
    double dou;
    int delayedInt;
    int i;
    int sliderInt;
    string delayedText;
    string text;
    string password;
    string textArea ="";

    float delayedFloat;
    float f;
    float fSlider;

    float fKnob;
    long longvalue;
    ExampleFlagsEnum m_Flags;
    Gradient gradient = new Gradient();
    GUIStyle m_style;
    GUIStyle Style
    {
        get
        {
            if (m_style==null)
            {
                m_style  = new GUIStyle(GUI.skin.label);
                m_style.richText = true;
            }
            return m_style;
        }
    }

    Vector2 pos;
    Vector2 v2;
    Vector2Int v2Int;
    Vector3 v3;
    Vector3Int v3Int;
    Vector4 v4;

    GameObject go;
    AnimationClip clip;

    Rect rect;
    RectInt rectInt;

    protected override void OnGUI()
    {
        base.OnGUI();

        pos = EditorGUILayout.BeginScrollView(pos);

        if (GUILayout.Button("这是一个按钮"))
        {
            Debug.Log("Click Button");
        }
        EditorGUILayout.LabelField("空格");
        EditorGUILayout.Separator();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("这是一个默认Lable");
        EditorGUILayout.LabelField("这是高300，宽50的Label", GUILayout.Width(300), GUILayout.Height(50));
        EditorGUILayout.LabelField("这是一个拾色器");
        EditorGUILayout.ColorField(Color.white);
        EditorGUILayout.LabelField("Bounds");
        bounds = EditorGUILayout.BoundsField(bounds);
        EditorGUILayout.LabelField("BoundsInt");
        boundsInt = EditorGUILayout.BoundsIntField(boundsInt);
        EditorGUILayout.LabelField("AnimationCurve");
        curve = EditorGUILayout.CurveField(curve);
        
        EditorGUILayout.LabelField("<color=#ff0000>注意比对延迟设置和直接设置的区别</color>", Style);        
        EditorGUILayout.Space();

        toggle = EditorGUILayout.Toggle("Toggle",toggle);
        toggleLeft = EditorGUILayout.ToggleLeft("ToggleLeft", toggleLeft);

        //double
        EditorGUILayout.LabelField("延迟设置"+delayedDou.ToString());
        delayedDou = EditorGUILayout.DelayedDoubleField("DelayedDouble", delayedDou);
        EditorGUILayout.LabelField("直接设置"+dou.ToString());
        dou = EditorGUILayout.DoubleField("Double", dou);
        delayedInt = EditorGUILayout.DelayedIntField("DelayedInt", delayedInt);
        //int
        i = EditorGUILayout.IntField("Int", i);      
        sliderInt = EditorGUILayout.IntSlider(sliderInt, 0, 100);

        //text
        delayedText = EditorGUILayout.DelayedTextField("DelayedText", delayedText);
        text = EditorGUILayout.TextField("Text", text);
        password = EditorGUILayout.PasswordField("Password",password);
        EditorGUILayout.LabelField("TextArea");
        textArea = EditorGUILayout.TextArea(textArea);
        //float
        delayedFloat = EditorGUILayout.DelayedFloatField("DelayedFloat", delayedFloat);
        f = EditorGUILayout.FloatField("Float", f);
        fSlider = EditorGUILayout.Slider("FloatSlider", fSlider, 0, 10);
        fKnob = EditorGUILayout.Knob(new Vector2(100, 100), fKnob, 0, 10, "Knob", Color.blue, Color.red, true);
        longvalue = EditorGUILayout.LongField("Long",longvalue);

        //vector
        v2 = EditorGUILayout.Vector2Field("Vector2", v2);
        v2Int = EditorGUILayout.Vector2IntField("Vector2Int", v2Int);

        v3 = EditorGUILayout.Vector3Field("Vector3", v3);
        v3Int = EditorGUILayout.Vector3IntField("Vector3Int", v3Int);

        v4 = EditorGUILayout.Vector4Field("Vector4", v4);

        EditorGUILayout.LabelField("枚举Field");
        m_Flags = (ExampleFlagsEnum)EditorGUILayout.EnumFlagsField(m_Flags);

        EditorGUILayout.LabelField("注意两者的区别");
        m_Flags  = (ExampleFlagsEnum)EditorGUILayout.EnumPopup(m_Flags);

        gradient = EditorGUILayout.GradientField("Gradient", gradient);

        go = (GameObject)EditorGUILayout.ObjectField("GameObject",go,typeof(GameObject),true);
        clip = (AnimationClip)EditorGUILayout.ObjectField("Clip", clip, typeof(AnimationClip), true);

        EditorGUILayout.LabelField("Rect");
        rect = EditorGUILayout.RectField(rect);
        EditorGUILayout.LabelField("RectInt");
        rectInt = EditorGUILayout.RectIntField(rectInt);


        EditorGUILayout.HelpBox("这是一个信息Box", MessageType.Info);
        EditorGUILayout.HelpBox("这是一个警告Box", MessageType.Warning);
        EditorGUILayout.HelpBox("这是一个错误Box", MessageType.Error);

        EditorGUILayout.SelectableLabel("SelectableLabel");


        EditorGUILayout.EndScrollView();
    }

}
