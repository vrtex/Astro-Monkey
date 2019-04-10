using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.IO;
using Microsoft.Xna.Framework;

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
            int mapWidth = 0;
            int mapHeight = 0;
            using(StreamReader fs = File.OpenText(filepath))
            {
                string file = fs.ReadToEnd();
                file = Regex.Replace(file, @"\n", "");

                Regex headerRegex = new Regex(@"<map version=.*?width=.(\d+).*?height=.(\d+)..*?>");
                MatchCollection headerMatches = headerRegex.Matches(file);
                foreach(Match m in headerMatches)
                {
                    Group g1 = m.Groups[1];
                    Group g2 = m.Groups[2];
                    mapWidth = int.Parse(g1.Value);
                    mapHeight = int.Parse(g2.Value);
                    Console.WriteLine(mapWidth);
                    Console.WriteLine(mapHeight);
                }

                Regex regex = new Regex(@"<data encoding=.csv.>(.*?)<\/data>");
                MatchCollection matches = regex.Matches(file);
                // Console.WriteLine(matches.Count);
                foreach(Match m in matches)
                {
                    GroupCollection groups = m.Groups;
                    string[] objects = groups[1].Value.Split(',');
                    int i = 0;
                    foreach(string o in objects)
                    {
                        ++i;
                        int index = int.Parse(o);
                        if(index == 0)
                            continue;

                        SpwanUsingTypeIndex(i % mapWidth, i / mapWidth, index);
                    }
                    // TODO this thing
                }
            }
        }

        private void SpwanUsingTypeIndex(int x, int y, int index)
        {
            Tuple<Type, float> objectInfo = ObjectsDictionary.objects[index];

            float spacing = 128;

            Transform spawnTransform = new Transform(
                new Vector2(x * spacing, y * spacing),
                new Vector2(sceneScale, sceneScale),
                objectInfo.Item2
                );

            GameObject spawned = (GameObject)Activator.CreateInstance(objectInfo.Item1, new object[] {spawnTransform});

            GameManager.SpawnObject(spawned);
        }

        public virtual void UnLoad()
        {
            foreach(GameObject obj in objects)
                obj.Destroy();
            Graphics.ViewManager.Instance.PlayerTransform = null;
        }

        public List<T> GetObjectsByClass<T>() where T : GameObject
        {
            List<T> toReturn = new List<T>();

            foreach(GameObject o in objects)
                if(o is T)
                    toReturn.Add((T)o);

            return toReturn;
        }
    }
}
