/*
using UnityEditor;
using UnityEngine;
using System.Collections;

public class CustomToolbar : MonoBehaviour
{
    public GameObject CubePrefab;
    public GameObject SpherePrefab;
    public GameObject CylinderPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Graphics

    private const string PATH_TO_PREFABS_FOLDER = "Assets/PhysicsObject/Prefab/";

    [MenuItem("VPL Library/Physics Object (���������� ������)/Cube (���)")]
    public static void CreateCube()
    {
        EditorUtility.InstantiatePrefab(
            AssetDatabase.LoadAssetAtPath(PATH_TO_PREFABS_FOLDER + "Cube.prefab",
            typeof(PhysicsObject)));
    }

    [MenuItem("VPL Library/Physics Object (���������� ������)/Sphere (�����)")]
    public static void CreateSphere()
    {
        EditorUtility.InstantiatePrefab(
            AssetDatabase.LoadAssetAtPath(PATH_TO_PREFABS_FOLDER + "Sphere.prefab",
            typeof(PhysicsObject)));
    }

    [MenuItem("VPL Library/Physics Object (���������� ������)/Cylinder (�������)")]
    public static void CreateCylinder()
    {
        EditorUtility.InstantiatePrefab(
            AssetDatabase.LoadAssetAtPath(PATH_TO_PREFABS_FOLDER + "Cylinder.prefab",
            typeof(PhysicsObject)));
    }

    [MenuItem("VPL Library/Physics Object (���������� ������)/Material point (������������ �����)")]
    public static void CreateMaterialPoint()
    {
    }

    [MenuItem("VPL Library/Physics Object (���������� ������)/Weight 100g (���� 100�)")]
    public static void CreateWeight100()
    {
    }

    #endregion

    #region Behaviors

    [MenuItem("VPL Library/Behavior (���������)/Velocity (��������)")]
    public static void AddVelocity()
    {
    }

    [MenuItem("VPL Library/Behavior (���������)/Acceleration (���������)")]
    public static void AddAcceleration()
    {
    }

    [MenuItem("VPL Library/Behavior (���������)/Friction coefitient (���������� ������)")]
    public static void AddCoefitientFriction()
    {
    }

    #endregion
}
*/
