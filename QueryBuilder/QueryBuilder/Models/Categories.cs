﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    public class Categories : IClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Categories()
        {

        }
        public Categories(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /*public override string ToString()
        {
            return $"Cateogry Name: {this.Name}";
        }*/
    }
}
