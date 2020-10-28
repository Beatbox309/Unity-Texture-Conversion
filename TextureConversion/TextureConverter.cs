using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Diagnostics;

public enum ConverterTypes { Roughness_To_Metallic_Smoothness, Unity_Default_To_Valve_VR_Standard, BGRA_Normal_To_RGB_Normal, Invert_Yellow_Normal, Invert_RGB_Texture }
public enum TextureTypes { Diffuse, Metallic, Gloss, Roughness, Normal, Texture }

public class TextureConverter : EditorWindow
{
    public ConverterTypes convType;

    public UnityEngine.Object Roughness;
    public UnityEngine.Object Metallic;
    public UnityEngine.Object Gloss;
    public UnityEngine.Object Diffuse;
    public UnityEngine.Object Normal;
    public UnityEngine.Object Texture;


    [MenuItem("Texture Conversion/Converter Window")]
    public static void ShowWindow()
    {
        GetWindow<TextureConverter>("Texture Converter");
    }

    private void OnGUI()
    {
        string TypeText = "Select Conversion Type";
        GUILayout.Label(TypeText);

        convType = (ConverterTypes)EditorGUILayout.EnumPopup(convType);
        switch (convType)
        {
            case ConverterTypes.Roughness_To_Metallic_Smoothness:
                {
                    GetTexture(TextureTypes.Roughness);
                    GetTexture(TextureTypes.Metallic);

                    if (GUILayout.Button("Convert"))
                    {
                        if (Roughness != null && Metallic != null)
                        {
                            #region IDK IF I WANNA DO DIS YET SO..
                            //string scriptDict = Directory.GetCurrentDirectory() + @"\Assets\Editor\TextureConversion\Scripts";
                            //StreamWriter sr = File.CreateText(scriptDict + @"\Temp.txt");
                            //sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Roughness));
                            //sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Metallic));
                            //sr.Close();

                            //string[] files = Directory.GetFiles(scriptDict);
                            //string pyScript = null;

                            //for (int i = 0; i < files.Length; i++)
                            //{
                            //    if (files[i].Contains("MetallicSmoothnessConverter") && !files[i].Contains(".meta"))
                            //        pyScript = files[i];
                            //}

                            //RunCmd("\"" + pyScript + "\"");

                            //UnityEngine.Debug.Log("python \"" + pyScript + "\"");
                            #endregion


                            RunConverter("MetallicSmoothnessConverter", ConverterTypes.Roughness_To_Metallic_Smoothness);
                        }
                        else UnityEngine.Debug.LogError("Missing Textures!");


                    }

                    EditorGUILayout.HelpBox("Inverts the Roughness Map and puts it into the Metallic Map's Alpha Channel", MessageType.Info, true);
                }
                break;

            case ConverterTypes.Unity_Default_To_Valve_VR_Standard:
                {
                    GetTexture(TextureTypes.Diffuse);
                    GetTexture(TextureTypes.Gloss);
                    GetTexture(TextureTypes.Normal);

                    if (GUILayout.Button("Convert"))
                    {
                        if (Diffuse != null && Gloss != null && Normal != null)
                        {
                            //string scriptDict = Directory.GetCurrentDirectory() + @"\Assets\Editor\TextureConversion\Scripts";
                            //StreamWriter sr = File.CreateText(scriptDict + @"\Temp.txt");
                            //sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Diffuse));
                            //sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Gloss));
                            //sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Normal));
                            //sr.Close();

                            //string[] files = Directory.GetFiles(scriptDict);
                            //string pyScript = null;

                            //for (int i = 0; i < files.Length; i++)
                            //{
                            //    if (files[i].Contains("UnityDefaultToValveVRStandard") && !files[i].Contains(".meta"))
                            //        pyScript = files[i];
                            //}

                            //RunCmd("\"" + pyScript + "\"");

                            //UnityEngine.Debug.Log("python \"" + pyScript + "\"");

                            RunConverter("UnityDefaultToValveVRStandard", ConverterTypes.Unity_Default_To_Valve_VR_Standard);
                        }
                        else UnityEngine.Debug.LogError("Missing Textures!");
                    }

                    EditorGUILayout.HelpBox("All-In-One Converter\n" +
                        "Seperates Metallic Map from Diffuse, Adds Gloss Map to Metallic Alpha, and fixes BGRA Normal Map"
                        , MessageType.Info, true);
                }
                break;

            case ConverterTypes.BGRA_Normal_To_RGB_Normal:
                {
                    GetTexture(TextureTypes.Normal);

                    if (GUILayout.Button("Convert"))
                    {
                        if (Normal != null)
                        {
                            //string scriptDict = Directory.GetCurrentDirectory() + @"\Assets\Editor\TextureConversion\Scripts";
                            //StreamWriter sr = File.CreateText(scriptDict + @"\Temp.txt");
                            //sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Normal));
                            //sr.Close();

                            //string[] files = Directory.GetFiles(scriptDict);
                            //string pyScript = null;

                            //for (int i = 0; i < files.Length; i++)
                            //{
                            //    if (files[i].Contains("BGRA_Normal_To_RGBA_Normal") && !files[i].Contains(".meta"))
                            //        pyScript = files[i];
                            //}

                            //RunCmd("\"" + pyScript + "\"");

                            //UnityEngine.Debug.Log("python \"" + pyScript + "\"");

                            RunConverter("BGRA_Normal_To_RGBA_Normal", ConverterTypes.BGRA_Normal_To_RGB_Normal);
                        }
                        else UnityEngine.Debug.LogError("Missing Textures!");
                    }

                    EditorGUILayout.HelpBox("Converts BGRA Normal Maps\nUse if your Normal Map is red", MessageType.Info, true);
                }
                break;

            case ConverterTypes.Invert_Yellow_Normal:
                {
                    GetTexture(TextureTypes.Normal);

                    if (GUILayout.Button("Convert"))
                    {
                        if (Normal != null)
                        {
                            //string scriptDict = Directory.GetCurrentDirectory() + @"\Assets\Editor\TextureConversion\Scripts";
                            //StreamWriter sr = File.CreateText(scriptDict + @"\Temp.txt");
                            //sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Normal));
                            //sr.Close();

                            //string[] files = Directory.GetFiles(scriptDict);
                            //string pyScript = null;

                            //for (int i = 0; i < files.Length; i++)
                            //{
                            //    if (files[i].Contains("InvertYellowNormal") && !files[i].Contains(".meta"))
                            //        pyScript = files[i];
                            //}

                            //RunCmd("\"" + pyScript + "\"");

                            //UnityEngine.Debug.Log("python \"" + pyScript + "\"");

                            RunConverter("InvertYellowNormal", ConverterTypes.Invert_Yellow_Normal);
                        }
                        else UnityEngine.Debug.LogError("Missing Textures!");
                    }

                    EditorGUILayout.HelpBox("Inverts Blue Channel on Normal Maps\nUse if your Normal Map is yellow", MessageType.Info, true);
                }
                break;

            case ConverterTypes.Invert_RGB_Texture:
                {
                    GetTexture(TextureTypes.Texture);

                    if (GUILayout.Button("Convert"))
                    {
                        if (Texture != null)
                        {
                            //string scriptDict = Directory.GetCurrentDirectory() + @"\Assets\Editor\TextureConversion\Scripts";
                            //StreamWriter sr = File.CreateText(scriptDict + @"\Temp.txt");
                            //sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Texture));
                            //sr.Close();

                            //string[] files = Directory.GetFiles(scriptDict);
                            //string pyScript = null;

                            //for (int i = 0; i < files.Length; i++)
                            //{
                            //    if (files[i].Contains("InvertRGB") && !files[i].Contains(".meta"))
                            //        pyScript = files[i];
                            //}

                            //RunCmd("\"" + pyScript + "\"");

                            //UnityEngine.Debug.Log("python \"" + pyScript + "\"");

                            RunConverter("InvertRGB", ConverterTypes.Invert_RGB_Texture);
                        }
                        else UnityEngine.Debug.LogError("Missing Textures!");
                    }

                    EditorGUILayout.HelpBox("Inverts RGB channels. Will preserve texture Alpha", MessageType.Info, true);
                }
                break;

            default:
                break;

        }
    }

    public void GetTexture(TextureTypes texType)
    {
        EditorGUILayout.Space();
        GUILayout.Label("Enter " + texType);
        switch (texType)
        {
            case TextureTypes.Diffuse:
                Diffuse = EditorGUILayout.ObjectField(Diffuse, typeof(Texture), false);
                break;

            case TextureTypes.Metallic:
                Metallic = EditorGUILayout.ObjectField(Metallic, typeof(Texture), false);
                break;

            case TextureTypes.Gloss:
                Gloss = EditorGUILayout.ObjectField(Gloss, typeof(Texture), false);
                break;

            case TextureTypes.Roughness:
                Roughness = EditorGUILayout.ObjectField(Roughness, typeof(Texture), false);
                break;

            case TextureTypes.Normal:
                Normal = EditorGUILayout.ObjectField(Normal, typeof(Texture), false);
                break;

            case TextureTypes.Texture:
                Texture = EditorGUILayout.ObjectField(Texture, typeof(Texture), false);
                break;
        }
    }

    public void RunConverter(string pyScriptName, ConverterTypes type)
    {
        // should only check the textures that are being used for this converter
        string scriptDict = Directory.GetCurrentDirectory() + @"\Assets\Editor\TextureConversion\Scripts";
        StreamWriter sr = File.CreateText(scriptDict + @"\Temp.txt");

        GetDirectroys(sr, type);

        string[] files = Directory.GetFiles(scriptDict);
        string pyScript = null;

        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].Contains(pyScriptName) && !files[i].Contains(".meta"))
                pyScript = files[i];
        }

        RunCmd("\"" + pyScript + "\"");

    }

    public void GetDirectroys(StreamWriter sr, ConverterTypes type)
    {
        switch (type)
        {
            case ConverterTypes.Roughness_To_Metallic_Smoothness:
                sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Roughness));
                sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Metallic));
                sr.Close();
                break;
            case ConverterTypes.Unity_Default_To_Valve_VR_Standard:
                sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Diffuse));
                sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Gloss));
                sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Normal));
                sr.Close();
                break;
            case ConverterTypes.BGRA_Normal_To_RGB_Normal:
                sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Normal));
                sr.Close();
                break;
            case ConverterTypes.Invert_Yellow_Normal:
                sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Normal));
                sr.Close();
                break;
            case ConverterTypes.Invert_RGB_Texture:
                sr.WriteLine(Directory.GetCurrentDirectory() + @"\" + AssetDatabase.GetAssetPath(Texture));
                sr.Close();
                break;
            default:
                break;
        }
    }

    public void RunCmd(string args)
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
