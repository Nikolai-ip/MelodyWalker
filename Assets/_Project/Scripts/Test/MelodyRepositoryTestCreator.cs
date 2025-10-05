using System;
using System.Collections.Generic;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Repositories;

namespace _Project.Scripts.Test
{
    public static class MelodyRepositoryTestCreator
    {
        public static MelodyRepository GetMelodyRepository()
        {
            return new MelodyRepository(new List<Melody>()
            {
                GetMelody1(),
                GetMelody2(),
                GetMelody3(),
                GetMelody4(),
                GetMelody5(),
                GetMelody6(),
            });
        }
        public static Melody GetMelody1()
        {
            var tacts = new List<Tact>
            {
                new(new List<Tuple<float, Note>>
                {
                    new(0.25f, new Note(1)),
                    new(0.3f, new Note(2)),
                    new(0.6f, new Note(3)),
                    new(0.45f, new Note(4))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.35f, new Note(5)),
                    new(0.2f, new Note(6)),
                    new(0.5f, new Note(7)),
                    new(0.3f, new Note(8))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.25f, new Note(1)),
                    new(0.3f, new Note(2)),
                    new(0.6f, new Note(3)),
                    new(0.45f, new Note(4))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.35f, new Note(5)),
                    new(0.2f, new Note(6)),
                    new(0.5f, new Note(7)),
                    new(0.3f, new Note(8))
                })
            };

            return new Melody(tacts);
        }

        public static Melody GetMelody2()
        {
            var tacts = new List<Tact>
            {
                new(new List<Tuple<float, Note>>
                {
                    new(0.3f, new Note(2)),
                    new(0.25f, new Note(4)),
                    new(0.4f, new Note(5)),
                    new(0.5f, new Note(3))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.2f, new Note(3)),
                    new(0.35f, new Note(6)),
                    new(0.4f, new Note(5)),
                    new(0.3f, new Note(2))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.15f, new Note(4)),
                    new(0.25f, new Note(5)),
                    new(0.3f, new Note(6)),
                    new(0.45f, new Note(4))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.5f, new Note(7)),
                    new(0.25f, new Note(6)),
                    new(0.4f, new Note(5)),
                    new(0.2f, new Note(3))
                })
            };
            return new Melody(tacts);
        }

        public static Melody GetMelody3()
        {
            var tacts = new List<Tact>
            {
                new(new List<Tuple<float, Note>>
                {
                    new(0.2f, new Note(1)),
                    new(0.2f, new Note(3)),
                    new(0.2f, new Note(4)),
                    new(0.2f, new Note(3)),
                    new(0.2f, new Note(1))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.3f, new Note(2)),
                    new(0.3f, new Note(5)),
                    new(0.3f, new Note(7)),
                    new(0.2f, new Note(5))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.4f, new Note(6)),
                    new(0.2f, new Note(5)),
                    new(0.4f, new Note(3)),
                    new(0.3f, new Note(2))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.25f, new Note(1)),
                    new(0.25f, new Note(2)),
                    new(0.25f, new Note(3)),
                    new(0.25f, new Note(1))
                })
            };
            return new Melody(tacts);
        }

        public static Melody GetMelody4()
        {
            var tacts = new List<Tact>
            {
                new(new List<Tuple<float, Note>>
                {
                    new(0.4f, new Note(3)),
                    new(0.4f, new Note(5)),
                    new(0.4f, new Note(8)),
                    new(0.4f, new Note(5))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.2f, new Note(4)),
                    new(0.3f, new Note(6)),
                    new(0.5f, new Note(4)),
                    new(0.2f, new Note(2))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.6f, new Note(1)),
                    new(0.3f, new Note(3)),
                    new(0.3f, new Note(2)),
                    new(0.1f, new Note(1))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.2f, new Note(4)),
                    new(0.4f, new Note(3)),
                    new(0.6f, new Note(5)),
                    new(0.5f, new Note(2))
                })
            };
            return new Melody(tacts);
        }

        public static Melody GetMelody5()
        {
            var tacts = new List<Tact>
            {
                new(new List<Tuple<float, Note>>
                {
                    new(0.25f, new Note(2)),
                    new(0.25f, new Note(4)),
                    new(0.5f, new Note(5)),
                    new(0.25f, new Note(2))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.3f, new Note(6)),
                    new(0.2f, new Note(5)),
                    new(0.4f, new Note(4)),
                    new(0.5f, new Note(3))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.15f, new Note(4)),
                    new(0.15f, new Note(5)),
                    new(0.3f, new Note(6)),
                    new(0.4f, new Note(4))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.5f, new Note(7)),
                    new(0.3f, new Note(6)),
                    new(0.4f, new Note(5)),
                    new(0.2f, new Note(2))
                })
            };
            return new Melody(tacts);
        }

        public static Melody GetMelody6()
        {
            var tacts = new List<Tact>
            {
                new(new List<Tuple<float, Note>>
                {
                    new(0.15f, new Note(1)),
                    new(0.3f, new Note(2)),
                    new(0.45f, new Note(3)),
                    new(0.15f, new Note(4))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.25f, new Note(5)),
                    new(0.25f, new Note(7)),
                    new(0.25f, new Note(8)),
                    new(0.25f, new Note(6))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.4f, new Note(5)),
                    new(0.3f, new Note(4)),
                    new(0.3f, new Note(2)),
                    new(0.2f, new Note(1))
                }),
                new(new List<Tuple<float, Note>>
                {
                    new(0.2f, new Note(3)),
                    new(0.4f, new Note(5)),
                    new(0.6f, new Note(4)),
                    new(0.3f, new Note(2))
                })
            };
            return new Melody(tacts);
        }
    }
}