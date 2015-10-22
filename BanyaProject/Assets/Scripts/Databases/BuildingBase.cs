using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class BuildingBase
    {
		//Make a list for the buildings
        public static List<BuildingType> Types;
		//Short and finding tools
        public static Dictionary<int, BuildingType> TypesById;
        public static Dictionary<string, BuildingType> TypesByName;

        static BuildingBase()
        {
			//Instatiate tools and list
            Types = new List<BuildingType>();
            TypesByName = new Dictionary<string, BuildingType>();
            TypesById = new Dictionary<int, BuildingType>();

		//MAIN BUILDING DATABASE

            AddItem(new BuildingType
            {
                Id = 1,
                Name = "Lounge",
                Description = "A place where a Kiman can relax.",
				auraTHG = 5,
				buildingType = BuildingTypes.Mind,
				BasePrefab = Resources.Load("LoungeBase", typeof(GameObject)) as GameObject,
				TransPrefab = Resources.Load("LoungeTrans", typeof(GameObject)) as GameObject,
				Icon = Resources.Load("LoungeIcon", typeof(Texture2D)) as Texture2D,
				costPerSquare = 100,

            });

			AddItem(new BuildingType
			        {
				Id = 2,
                Name = "Restaurant",
				auraACH = 5,
				buildingType = BuildingTypes.Body,
                Description = "A place where a Kiman can eat.",
				BasePrefab = Resources.Load("RestaurantBase", typeof(GameObject)) as GameObject,
				TransPrefab = Resources.Load("RestaurantTrans", typeof(GameObject)) as GameObject,
				Icon = Resources.Load("RestaurantIcon", typeof(Texture2D)) as Texture2D,
				costPerSquare = 150,
			});

			AddItem(new BuildingType
			        {
				Id = 3,
				Name = "Baths",
				auraAWE = 5,
				buildingType = BuildingTypes.Spirit,
			    Description = "A place where a Kiman can bathe.",
				BasePrefab = Resources.Load("BathsBase", typeof(GameObject)) as GameObject,
				TransPrefab = Resources.Load("BathsTrans", typeof(GameObject)) as GameObject,
				Icon = Resources.Load("BathsIcon", typeof(Texture2D)) as Texture2D,
				costPerSquare = 150,
			});

            AddItem(new BuildingType
            {
                Id = 4,
                Name = "Corridor",
				buildingType = BuildingTypes.None,
                Description = "A path or connection part",
				BasePrefab = Resources.Load("CorridorBase", typeof(GameObject)) as GameObject,
				TransPrefab = Resources.Load("CorridorBase", typeof(GameObject)) as GameObject,
				costPerSquare = 50,
            });
		}

	//Code use to make the buildings and add them to the dictionaries
	static void AddItem(BuildingType type)
	{
		//Check for throws
		if (type.Id == 0)
			throw new Exception("Building must have a unique id set.");

		//Check for repeated name and add the item to dictionaries
		Types.Add(type);
		TypesById.Add(type.Id, type);
		if (!TypesByName.ContainsKey(type.Name))
			TypesByName.Add(type.Name, type);
	}

	//Methods used for getting database members based on its ID or its Name
         public static BuildingType Get(string name)
        {
            BuildingType result = null;
            TypesByName.TryGetValue(name, out result);
            return result;
        }

        public static BuildingType Get(int id)
        {
            BuildingType result = null;
            TypesById.TryGetValue(id, out result);
            return result;
        }


    }