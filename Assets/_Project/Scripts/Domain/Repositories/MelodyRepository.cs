using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Services;

namespace _Project.Scripts.Domain.Repositories
{
    public class MelodyRepository
    {
        public List<Melody> Melodies { get; }
        public MelodyRepository(List<Melody> melodies)
        {
            Melodies = melodies;
        }
    }
}