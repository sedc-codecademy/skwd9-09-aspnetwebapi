﻿using SEDC.NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.NotesAPI
{
    public static class StaticDB
    {
        public static List<string> SimpleNotes = new List<string>
        {
            "Go to the gym",
            "Write your homework",
            "Buy groceries"
        };

        public static List<Note> Notes = new List<Note>()
        {
            new Note(){ Text = "Do Homework", Color = "blue", Tags = new List<Tag>()
                {
                    new Tag(){ Name = "HomeWork", Color = "cyan"},
                    new Tag(){ Name = "SEDC", Color = "blue"}
                }
            },
            new Note(){ Text = "Drink more Water", Color = "blue", Tags = new List<Tag>()
                {
                    new Tag(){ Name = "Healthy", Color = "orange"},
                    new Tag(){ Name = "Priority High", Color = "red"}
                }
            },
            new Note(){ Text = "Go to the gym", Color = "blue", Tags = new List<Tag>()
                {
                    new Tag(){ Name = "exercise", Color = "blue"},
                    new Tag(){ Name = "Priority Medium", Color = "yellow"}
                }
            }
        };
    }
}