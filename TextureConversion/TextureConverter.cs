using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Diagnostics;


public enum coverterTypes { Roughgness_To_Metallic_Smoothness, Unity_Default_To_Valve_VR_Standard, BGRA_Normal_To_RGB_Normal, Invert_Yellow_Normal }

public class TextureConverter : EditorWindow
{

    public coverterTypes type;


    public UnityEngine.Object Roughness;
    public UnityEngine.Object Metallic;
    public UnityEngine.Object Gloss;
    public UnityEngine.Object Diffuse;
    public UnityEngine.Object Normal;



    [MenuItem("Texture Converter/Converter Window")]
    public static void ShowWindow()
    {
        GetWindow<TextureConverter>("Texture Converter");
    }

    private void OnGUI()
    {
        string TypeText = "Select Conversion Type";
        GUILayout.Label(TypeText);

        type = (coverterTypes)EditorGUILayout.EnumPopup(type);

        EditorGUILayout.Space();


        switch (type)
        {
            case coverterTypes.Roughgness_To_Metallic_Smoothness:
                {
                    string Rtext = "Enter Roughness";
                    GUILayout.Label(Rtext);
                    Roughness = EditorGUILayout.ObjectField(Roughness, typeof(Texture));
                    EditorGUILayout.Space();
                    string Mtext = "Enter Metallic";
                    GUILayout.Label(Mtext);
                    Metallic = EditorGUILayout.ObjectField(Metallic, typeof(Texture));

                    if (GUILayout.Button("Convert"))
                    {
                        string scriptDict = Directory.GetCurrentDirectory() + @"\Assets\Editor\TextureConversion\Scripts";
                        StreamWriter sr = File.CreateText(scriptDict + @"\Temp.txt");
                        sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Roughness));
                        sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Metallic));
                        sr.Close();

                        string[] files = Directory.GetFiles(scriptDict);
                        string pyscript = null;

                        for (int i = 0; i < files.Length; i++)
                        {
                            if (files[i].Contains("MetallicSmoothnessConverter") && !files[i].Contains(".meta"))
                                pyscript = files[i];
                        }

                        run_cmd("\"" + pyscript + "\"");

                        UnityEngine.Debug.Log("python \"" + pyscript + "\"");

                        sr.Dispose();
                    }
                }
                break;
            case coverterTypes.Unity_Default_To_Valve_VR_Standard:
                {
                    string Mtext = "Enter Diffuse";
                    GUILayout.Label(Mtext);
                    Diffuse = EditorGUILayout.ObjectField(Diffuse, typeof(Texture));

                    string Gtext = "Enter Gloss";
                    GUILayout.Label(Gtext);
                    Gloss = EditorGUILayout.ObjectField(Gloss, typeof(Texture));

                    EditorGUILayout.Space();

                    string Ntext = "Enter Normal";
                    GUILayout.Label(Ntext);
                    Normal = EditorGUILayout.ObjectField(Normal, typeof(Texture));



                    if (GUILayout.Button("Convert"))
                    {
                        string scriptDict = Directory.GetCurrentDirectory() + @"\Assets\Editor\TextureConversion\Scripts";
                        StreamWriter sr = File.CreateText(scriptDict + @"\Temp.txt");
                        sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Diffuse));
                        sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Gloss));
                        sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Normal));
                        sr.Close();

                        string[] files = Directory.GetFiles(scriptDict);
                        string pyscript = null;

                        for (int i = 0; i < files.Length; i++)
                        {
                            if (files[i].Contains("UnityDefaultToValveVRStandard") && !files[i].Contains(".meta"))
                                pyscript = files[i];
                        }

                        run_cmd("\"" + pyscript + "\"");

                        UnityEngine.Debug.Log("python \"" + pyscript + "\"");
                    }
                }
                break;
            case coverterTypes.BGRA_Normal_To_RGB_Normal:
                {
                    string Ntext = "Enter Normal";
                    GUILayout.Label(Ntext);
                    Normal = EditorGUILayout.ObjectField(Normal, typeof(Texture));



                    if (GUILayout.Button("Convert"))
                    {
                        string scriptDict = Directory.GetCurrentDirectory() + @"\Assets\Editor\TextureConversion\Scripts";
                        StreamWriter sr = File.CreateText(scriptDict + @"\Temp.txt");
                        sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Normal));
                        sr.Close();

                        string[] files = Directory.GetFiles(scriptDict);
                        string pyscript = null;

                        for (int i = 0; i < files.Length; i++)
                        {
                            if (files[i].Contains("BGRA_Normal_To_RGBA_Normal") && !files[i].Contains(".meta"))
                                pyscript = files[i];
                        }

                        run_cmd("\"" + pyscript + "\"");

                        UnityEngine.Debug.Log("python \"" + pyscript + "\"");

                    }
                }
                break;
            case coverterTypes.Invert_Yellow_Normal:
                {
                    string Ntext = "Enter Normal";
                    GUILayout.Label(Ntext);
                    Normal = EditorGUILayout.ObjectField(Normal, typeof(Texture));



                    if (GUILayout.Button("Convert"))
                    {
                        string scriptDict = Directory.GetCurrentDirectory() + @"\Assets\Editor\TextureConversion\Scripts";
                        StreamWriter sr = File.CreateText(scriptDict + @"\Temp.txt");
                        sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Normal));
                        sr.Close();

                        string[] files = Directory.GetFiles(scriptDict);
                        string pyscript = null;

                        for (int i = 0; i < files.Length; i++)
                        {
                            if (files[i].Contains("InvertYellowNormal") && !files[i].Contains(".meta"))
                                pyscript = files[i];
                        }

                        run_cmd("\"" + pyscript + "\"");

                        UnityEngine.Debug.Log("python \"" + pyscript + "\"");

                    }
                }
                break;



            default:
                break;

        }
    }


    public void run_cmd(string args)
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Remove(23) + @"Local\Programs\Python\Python38-32\python.exe";
        start.Arguments = args;
        start.UseShellExecute = false;// Do not use OS shell
        start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
        start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                if (result.Length != 0)
                    UnityEngine.Debug.Log(result);
                if (stderr.Length != 0)
                    UnityEngine.Debug.LogError(stderr);
            }
        }
    }
}