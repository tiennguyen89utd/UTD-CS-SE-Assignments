﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    class Wumpus : Entity
    {
        bool Sleeping;
        public Wumpus(Map map, int position)
            : base(map, position)
        {
            // Start off sleeping
            Sleeping = true;
        }

        public override void Update()
        {
            // Move to random adj room if not sleeping
            if (!Sleeping)
            {
                if (Map.random.Next(4) != 0) // 75% chance to move
                {
                    var adjRooms = Map.getAdjacentRooms(Position);
                    Move(adjRooms[Map.random.Next(3)]);
                }
                
            }

            // Smell a wumpus if next to player
            if (isAdjacentToPlayer())
            {
                Console.WriteLine("I smell a Wumpus!");
            }
        }

        public override void AffectPlayer()
        {
            // Wake up if sleeping
            if (Sleeping)
            {
                Console.WriteLine("... Ooops! Bumped a Wumpus");
                Sleeping = false;
            }
            // Lose the game if awake
            else
            {
                Console.WriteLine("The Wumpus caught you!");
                Map.EndGame(false);
            }
            
        }
    }
}
