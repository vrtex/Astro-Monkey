﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.IO;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Core
{
    class Scene
    {
        protected float sceneScale = SceneManager.scale;

        public List<GameObject>					objects				= new List<GameObject>();
		public List<GameObject>					doors				= new List<GameObject>();
		public List<GameObject>					interactives		= new List<GameObject>();
		public List<Assets.Objects.NavPoint>	navigationPoints	= new List<Assets.Objects.NavPoint>();

		public virtual void Reset() { }

        public virtual void Load()
        {
            // ??
            foreach(GameObject obj in objects)
                obj.Destroy();
            objects.Clear();
			doors.Clear();
			interactives.Clear();
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
                }

                Regex regex = new Regex(@"<data encoding=.csv.>(.*?)<\/data>");
                MatchCollection matches = regex.Matches(file);
				// Console.WriteLine(matches.Count);

				//Zapisanie informacji o punktach nawigacyjnych
				int groupIndex = 0;
				Util.NavPointPosition[,] navTypes = new Util.NavPointPosition[mapWidth, mapHeight];
				for(int x = 0; x < mapWidth; ++x)
				{
					for(int y = 0; y < mapWidth; ++y)
					{
						navTypes[x, y] = Util.NavPointPosition.None;
					}
				}

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
						if(groupIndex == 0) //podłoga
						{
							navTypes[i % mapWidth, i / mapWidth] = Util.NavPointPosition.All;
						}
						else if(groupIndex == 1) //meble
						{
							if(ObjectsDictionary.navPos.ContainsKey(index))
								navTypes[i % mapWidth, i / mapWidth] = ObjectsDictionary.navPos[index];
						}
					}					
					++groupIndex;
				}
				SpawnNavigationPoints(navTypes);

			}
            GameManager.FinalizeSpwaning();
        }

        private void SpwanUsingTypeIndex(int x, int y, int index)
        {
            Tuple<Type, float> objectInfo = ObjectsDictionary.objects[index];

            float spacing = 32;

            Transform spawnTransform = new Transform(
                new Vector2(x * spacing, y * spacing) * sceneScale,
                new Vector2(sceneScale, sceneScale),
                objectInfo.Item2
                );

			if(index == 217)
			{
				spawnTransform.position.Y += 1;
			}

            GameObject spawned = (GameObject)Activator.CreateInstance(objectInfo.Item1, new object[] {spawnTransform});

            GameManager.SpawnObject(spawned);
        }

		private void SpawnNavigationPoints(Util.NavPointPosition[,] navTypes)
		{
			float spacing = 32;
			float innerSpacing = 8;

			for(int x = 0; x < navTypes.GetLength(0); ++x)
			{
				for(int y = 0; y < navTypes.GetLength(1); ++y)
				{
					if(navTypes[x, y] == Util.NavPointPosition.All
					|| navTypes[x, y] == Util.NavPointPosition.Up
					|| navTypes[x, y] == Util.NavPointPosition.UpLeft
					|| navTypes[x, y] == Util.NavPointPosition.Left
					|| navTypes[x, y] == Util.NavPointPosition.CornerUpLeft
					|| navTypes[x, y] == Util.NavPointPosition.CornerDownLeft
					|| navTypes[x, y] == Util.NavPointPosition.CornerUpRight)
					{
						Transform spawnTransform = new Transform(
							new Vector2(x * spacing, y * spacing) * sceneScale + new Vector2(-innerSpacing, -innerSpacing) * sceneScale,
							new Vector2(sceneScale, sceneScale)
							);

						GameObject spawned = (GameObject)Activator.CreateInstance(typeof(Assets.Objects.NavPoint), new object[] {spawnTransform});
						GameManager.SpawnObject(spawned);
						navigationPoints.Add(spawned as Assets.Objects.NavPoint);
					}
					if(navTypes[x, y] == Util.NavPointPosition.All
					|| navTypes[x, y] == Util.NavPointPosition.Up
					|| navTypes[x, y] == Util.NavPointPosition.UpRight
					|| navTypes[x, y] == Util.NavPointPosition.Right
					|| navTypes[x, y] == Util.NavPointPosition.CornerDownRight
					|| navTypes[x, y] == Util.NavPointPosition.CornerUpRight
					|| navTypes[x, y] == Util.NavPointPosition.CornerUpLeft)
					{
						Transform spawnTransform = new Transform(
							new Vector2(x * spacing, y * spacing) * sceneScale + new Vector2(innerSpacing, -innerSpacing) * sceneScale,
							new Vector2(sceneScale, sceneScale)
							);

						GameObject spawned = (GameObject)Activator.CreateInstance(typeof(Assets.Objects.NavPoint), new object[] {spawnTransform});
						GameManager.SpawnObject(spawned);
						navigationPoints.Add(spawned as Assets.Objects.NavPoint);
					}
					if(navTypes[x, y] == Util.NavPointPosition.All
					|| navTypes[x, y] == Util.NavPointPosition.Down
					|| navTypes[x, y] == Util.NavPointPosition.DownRight
					|| navTypes[x, y] == Util.NavPointPosition.Right
					|| navTypes[x, y] == Util.NavPointPosition.CornerUpRight
					|| navTypes[x, y] == Util.NavPointPosition.CornerDownLeft
					|| navTypes[x, y] == Util.NavPointPosition.CornerDownRight)
					{
						Transform spawnTransform = new Transform(
							new Vector2(x * spacing, y * spacing) * sceneScale + new Vector2(innerSpacing, innerSpacing) * sceneScale,
							new Vector2(sceneScale, sceneScale)
							);

						GameObject spawned = (GameObject)Activator.CreateInstance(typeof(Assets.Objects.NavPoint), new object[] {spawnTransform});
						GameManager.SpawnObject(spawned);
						navigationPoints.Add(spawned as Assets.Objects.NavPoint);
					}
					if(navTypes[x, y] == Util.NavPointPosition.All
					|| navTypes[x, y] == Util.NavPointPosition.Down
					|| navTypes[x, y] == Util.NavPointPosition.DownLeft
					|| navTypes[x, y] == Util.NavPointPosition.Left
					|| navTypes[x, y] == Util.NavPointPosition.CornerDownRight
					|| navTypes[x, y] == Util.NavPointPosition.CornerUpLeft
					|| navTypes[x, y] == Util.NavPointPosition.CornerDownLeft)
					{
						Transform spawnTransform = new Transform(
							new Vector2(x * spacing, y * spacing) * sceneScale + new Vector2(-innerSpacing, innerSpacing) * sceneScale,
							new Vector2(sceneScale, sceneScale)
							);

						GameObject spawned = (GameObject)Activator.CreateInstance(typeof(Assets.Objects.NavPoint), new object[] {spawnTransform});
						GameManager.SpawnObject(spawned);
						navigationPoints.Add(spawned as Assets.Objects.NavPoint);
					}
				}
			}

			foreach(Assets.Objects.NavPoint nav in navigationPoints)
			{
				foreach(Assets.Objects.NavPoint innernav in navigationPoints)
				{
					if(nav != innernav)
					{
						if(Vector2.Distance(nav.transform.position, innernav.transform.position) < (innerSpacing * 2 + 1f) * sceneScale)
						{
							nav.neighbors.Add(innernav);
						}
					}
				}
			}
		}

        public virtual void UnLoad()
        {
            foreach(GameObject obj in objects)
                obj.Destroy();
            Graphics.ViewManager.Instance.PlayerTransform = null;
        }

        protected void RepairSpawns()
        {
            foreach(GameObject gameObject in objects)
                GameManager.SpawnObject(gameObject);
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
