﻿using System.Drawing;
using System.Security.Principal;

namespace Lab_05.Models;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AnimalCategory Category { get; set; }
    public double weight { get; set; }
    public Color color { get; set; }
    
}