using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InstanceMeshCombiner : MonoBehaviour
{
    [SerializeField] private List<MeshFilter> meshFilters;

    [SerializeField] private MeshFilter targetMesh;

    [ContextMenu("CreateMesh")]
    public void CreateMesh()
    {
        var combine = new CombineInstance[meshFilters.Count];

        for (int i = 0; i < meshFilters.Count; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }

        var mesh = new Mesh();
        mesh.CombineMeshes(combine);
        targetMesh.mesh = mesh;
#if UNITY_EDITOR
        SaveMesh(targetMesh.sharedMesh, gameObject.name, false, true);
        print("Mesh is create");
#endif
    }

    #if UNITY_EDITOR
    public void SaveMesh(Mesh mesh, string name, bool makeNewInstance, bool optimize)
    {
        string path = EditorUtility.SaveFilePanel("Save new Mesh Asset", "Assets/My_Mesh/", name, "asset");
        if (string.IsNullOrEmpty(path)) return;

        path = FileUtil.GetProjectRelativePath(path);
        Mesh meshToSave = (makeNewInstance) ? Object.Instantiate(mesh) as Mesh : mesh;
        if (optimize)
            MeshUtility.Optimize(meshToSave);

        AssetDatabase.CreateAsset(meshToSave, path);
        AssetDatabase.SaveAssets();
    }
    #endif
}
