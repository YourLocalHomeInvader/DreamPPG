	// https://discord.com/invite/Yj45Gy3sfQ
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace dream
{
        public class dream
    {

        public static void Main()
        {
	CategoryBuilder.Create("<color=green> Dream", "<color=green> NPC list for Dream, Made By Your Local Home Invader (Connor Cochran)", ModAPI.LoadSprite("sprites/Dream.png"));
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"), 
                    NameOverride = "<color=green> Dream (Regular Version)", 
                    NameToOrderByOverride = "a",
                    DescriptionOverride = "\n<color=green>Yo its the one dude from Minecraft!!", 
                    CategoryOverride = ModAPI.FindCategory("<color=green> Dream"),
                    ThumbnailOverride = ModAPI.LoadSprite("sprites/Dream.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        var skin = ModAPI.LoadTexture("sprites/skin.png");
                        var flesh = ModAPI.LoadTexture("sprites/flesh.png");
                        var bone = ModAPI.LoadTexture("sprites/bone.png");

                        var person = Instance.GetComponent<PersonBehaviour>();

                        person.SetBodyTextures(skin, flesh, bone, 1);
						
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"), 
                    NameOverride = "<color=green> Dream (Square Version)", 
                    NameToOrderByOverride = "a",
                    DescriptionOverride = "\n<color=green>Yo its the one dude from Minecraft!!", 
                    CategoryOverride = ModAPI.FindCategory("<color=green> Dream"),
                    ThumbnailOverride = ModAPI.LoadSprite("sprites/DreamS.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        var skin = ModAPI.LoadTexture("sprites/skinS.png");
                        var flesh = ModAPI.LoadTexture("sprites/flesh.png");
                        var bone = ModAPI.LoadTexture("sprites/bone.png");

                        var person = Instance.GetComponent<PersonBehaviour>();

                        person.SetBodyTextures(skin, flesh, bone, 1);
						
                    }
                }
            );



ModAPI.Register(
			new Modification()
			{
				OriginalItem = ModAPI.FindSpawnable("Pistol"),
				NameOverride = "<color=green> Dream Beat",
				DescriptionOverride = "\n<color=green>**Disable Collision before using** Press F to play the music",
				CategoryOverride = ModAPI.FindCategory("<color=green> Dream"), 
				ThumbnailOverride = ModAPI.LoadSprite("sprites/Dream Beat.png"), 
                               NameToOrderByOverride = "a",
				AfterSpawn = (Instance) => 
					{
				
				      	Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("sprites/Dream Beat.png", 1f);
						var firearm = Instance.GetComponent<FirearmBehaviour>();
						Cartridge customCartridge = ModAPI.FindCartridge("9mm");
						customCartridge.name = "DMusic";
						firearm.Cartridge = customCartridge;
						customCartridge.Damage = 0f;
						customCartridge.StartSpeed *= 0f; 
						customCartridge.PenetrationRandomAngleMultiplier *= 0f; 
						customCartridge.Recoil *= 0f; 
						customCartridge.ImpactForce *= 0f; 
						firearm.ShotSounds = new AudioClip[]
						{
							ModAPI.LoadSound("sounds/Trance Music.mp3"),
						};
						Instance.FixColliders();
						
                    }
                }
            );

ModAPI.Register(
			new Modification()
			{
				OriginalItem = ModAPI.FindSpawnable("Pistol"),
				NameOverride = "<color=green> Dream Boss",
				DescriptionOverride = "\n<color=yellow>**Disable Collision before using**Press F to Use it",
				CategoryOverride = ModAPI.FindCategory("<color=green> Dream"), 
				ThumbnailOverride = ModAPI.LoadSprite("sprites/Dream Boss.png"), 
                               NameToOrderByOverride = "a",
				AfterSpawn = (Instance) => 
				{
						ModAPI.Notify("<color=red>" + "Oh No! " + "\n <color=orange>" + "Not Rumpelstiltskin");
				      	Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("sprites/rumpelstiltskin.png", 1f);
						var firearm = Instance.GetComponent<FirearmBehaviour>();
						Cartridge customCartridge = ModAPI.FindCartridge("9mm");
						customCartridge.name = "DMusic";
						firearm.Cartridge = customCartridge;
						customCartridge.Damage = 10f;
						customCartridge.StartSpeed *= 2f; 
						customCartridge.PenetrationRandomAngleMultiplier *= 0f; 
						customCartridge.Recoil *= 0f; 
						customCartridge.ImpactForce *= 0f;
						firearm.ShotSounds = new AudioClip[]
						{
						ModAPI.LoadSound("sounds/Pickle.mp3"),
						ModAPI.LoadSound("sounds/breathe air.mp3"),
						ModAPI.LoadSound("sounds/AUGH.mp3"),
						ModAPI.LoadSound("sounds/Scream.mp3"),
						};
						Instance.FixColliders();
						Instance.AddComponent<UseEventTrigger>().Action = () =>
						{
          					ModAPI.CreateParticleEffect("BigZap", Instance.transform.position);
          					ModAPI.CreateParticleEffect("Explosion", Instance.transform.position);
						};
					}
				}
			);
		}
	}
}
