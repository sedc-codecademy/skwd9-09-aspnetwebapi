﻿using SEDC.NotesAndTagsApp.Models;
using System.Collections.Generic;

namespace SEDC.NotesAndTagsApp
{
    public static class StaticDb
    {
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
