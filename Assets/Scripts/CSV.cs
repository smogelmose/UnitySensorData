using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSV
{
    public CSV () { }
    string filename;

    public void WriteCSV(string name, List<Vector3> list)
    {
        filename = Application.persistentDataPath + "/" + name + ".CSV";
        if (list.Count > 0)
        {
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("x; y; z");
            tw.Close();

            tw = new StreamWriter(filename, true);

            for (int i = 0; i < list.Count; i++)
            {
                tw.WriteLine(list[i].x + ";" + list[i].y + ";" +
                                list[i].z);
            }
            tw.Close();
        }
    }
}
