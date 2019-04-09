using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.IO;

namespace AstroMonkey.Core
{
    class Scene
    {
        protected float sceneScale = SceneManager.scale;

        public List<GameObject> objects        = new List<GameObject>();


        public virtual void Reset() { }

        public virtual void Load()
        {
            // ??
            foreach(GameObject obj in objects)
                obj.Destroy();
            objects.Clear();
        }

        public void LoadFromFile(string filepath)
        {
            using(StreamReader fs = File.OpenText("AstroMonkey.tmx"))
            {
                string file = fs.ReadToEnd();
                file = Regex.Replace(file, @"\n", "");

                Regex headerRegex = new Regex(@"<map version=.*?width=.(\d+).*?height=.(\d+)..*?>");
                MatchCollection headerMatches = headerRegex.Matches(file);
                foreach(Match m in headerMatches)
                {
                    Group g1 = m.Groups[1];
                    Group g2 = m.Groups[2];
                    Console.WriteLine(g1);
                    Console.WriteLine(g2);
                }

                Regex regex = new Regex(@"<data encoding=.csv.>(.*?)<\/data>");
                MatchCollection matches = regex.Matches(file);
                // Console.WriteLine(matches.Count);
                foreach(Match m in matches)
                {
                    GroupCollection groups = m.Groups;
                    string[] objects = groups[1].Value.Split(',');

                    // TODO this thing
                }
            }
        }

        public virtual void UnLoad()
        {
            foreach(GameObject obj in objects)
                obj.Destroy();
            Graphics.ViewManager.Instance.PlayerTransform = null;
        }
    }
}
