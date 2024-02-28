using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileReader
{
    private static readonly string m_Path = Application.persistentDataPath;
    private static readonly string m_FileType = ".bin";


    private static string FilePath(string fileName)
    {
        return Path.Combine(m_Path, fileName + m_FileType);
    }

//save files
    public static void Serialize(string fileName, HashSet<ScoreItem> hashScoreSet)
    {
        var path = FilePath(fileName);
        FileStream fs = File.Exists(path) ? new FileStream(path, FileMode.Open) : new FileStream(path, FileMode.Create);

        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            formatter.Serialize(fs, hashScoreSet);
        }
        catch (SerializationException e)
        {
            Debug.Log("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            fs.Close();
        }
    }

//get files
    public static void Deserialize(string fileName, out HashSet<ScoreItem> hash)
    {
        var path = FilePath(fileName);
        if (!File.Exists(path) || new FileInfo(path).Length <5)
        {
            hash = new HashSet<ScoreItem>();
            return;
        }

        FileStream fs = new FileStream(path, FileMode.Open);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            hash = (HashSet<ScoreItem>)formatter.Deserialize(fs);
        }
        catch (SerializationException e)
        {
            Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            fs.Close();
        }
    }

    public static void ClearFile(string fileName)
    {
        var path = FilePath(fileName);
        FileStream fs = new FileStream(path, FileMode.Open);

        if (!File.Exists(path) || new FileInfo(path).Length == 0) return;

        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            formatter.Serialize(fs, new());
        }
        catch (SerializationException e)
        {
            Debug.Log("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            fs.Close();
        }
    }
}