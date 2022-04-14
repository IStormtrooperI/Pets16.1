﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    class Photo
    {
        public int Id { get; set; }
        private int pet;
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }
        public String FilePath { get; set; }

        public Photo(int id_photo)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    {"id_pet", 1 },
                    {"filePath", "exampleImage" },
                };

            Id = objectFromDB["id"];
            pet = objectFromDB["id_pet"];
            FilePath = objectFromDB["filePath"];
        }
    }
}
