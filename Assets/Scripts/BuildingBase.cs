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

			//Locker Rooms

            AddItem(new BuildingType
            {
                Id = 1,
                Name = "Lounge",
				Description = "A place where a Kiman can revitalize their mind.",
				IsMaleOnly = true,
				Width = 1,
				Length = 1,
				BasePrefab = Resources.Load("LoungeBase", typeof(GameObject)) as GameObject,
				TransPrefab = Resources.Load("LoungeTrans", typeof(GameObject)) as GameObject,
				Icon = Resources.Load("LoungeIcon", typeof(Texture2D)) as Texture2D,

            });

			AddItem(new BuildingType
			        {
				Id = 2,
				Name = "Restaurant",
				Description = "A place where a Kimans can revitalize their body.",
				IsMaleOnly = false,
				Width = 1,
				Length = 1,
				BasePrefab = Resources.Load("RestaurantBase", typeof(GameObject)) as GameObject,
				TransPrefab = Resources.Load("RestaurantTrans", typeof(GameObject)) as GameObject,
				Icon = Resources.Load("RestaurantIcon", typeof(Texture2D)) as Texture2D,
			});
			
			//Baths

			AddItem(new BuildingType
			        {
				Id = 3,
				Name = "Baths",
			Description = "A place where a Kiman can revitalize their spirit.",
				IncreaseAWE = 5,  
				IncreaseACH = 5,
				IncreaseAura = 10,
				Width = 1,
				Length = 1,
				BasePrefab = Resources.Load("BathsBase", typeof(GameObject)) as GameObject,
				TransPrefab = Resources.Load("BathsTrans", typeof(GameObject)) as GameObject,
				Icon = Resources.Load("BathsIcon", typeof(Texture2D)) as Texture2D,
			});

			AddItem(new BuildingType
			        {
				Id = 4,
				Name = "Steam Room ",
				Description = "A Steam Room.",
				IncreaseACH = 5,
				Width = 1,
				Length = 1,                
			});

			AddItem(new BuildingType
			        {
				Id = 5,
				Name = "Dry Sauna",
				Description = "A Dry Sauna.",
				IncreaseACH = 5,
				Width = 1,
				Length = 1,                
			});
			
			AddItem(new BuildingType
			        {
				Id = 6,
				Name = "Showers",
				Description = "The Showers.",
				IncreaseACH = 5,
				Width = 1,
				Length = 1,                
			});

			AddItem(new BuildingType
			        {
				Id = 7,
				Name = "Cold Pool",
				Description = "A cold pool.",
				IncreaseACH = 5,
				Width = 1,
				Length = 1,                
			});

			AddItem(new BuildingType
			        {
				Id = 8,
				Name = "Jacuzzi",
				Description = "A Jacuzzi.",
				IncreaseACH = 5,
				Width = 1,
				Length = 1,                
			});

			AddItem(new BuildingType
			        {
				Id = 9,
				Name = "Mud Bath",
				Description = "A Mud Bath.",
				IncreaseACH = 5,
				IncreaseFUN = 5,
				Width = 1,
				Length = 1,                
			});

			AddItem(new BuildingType
			        {
				Id = 10,
				Name = "Swimming Pool",
				Description = "Standard Swimming Pool.",
				IncreaseFUN = 5,
				Width = 1,
				Length = 1,                
			});

		}

	//Code use to make the buildings and add them to the dictionaries
	static void AddItem(BuildingType type)
	{
		//Check for throws
		if (type.Id == 0)
			throw new Exception("Enemy must have a unique id set.");

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