﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
//Размер животного маленькое
//Размер животного среднее
//Размер животного большое
    class Size
    {
        private static int pet;
        public int Id { get; set; }
        public String Name { get; set; }
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }

        public Size(int id_size)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    { "id_pet", 1 },
                    {"name", "маленькое" },
                };

            Id = objectFromDB["id"];
            pet = objectFromDB["id_pet"];
            Name = objectFromDB["name"];
        }
    }
}
