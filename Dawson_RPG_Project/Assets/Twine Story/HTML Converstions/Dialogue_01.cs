/*
------------------------------------------------
Generated by Cradle 2.0.1.0
https://github.com/daterre/Cradle

Original file: Dialogue_01.html
Story format: Harlowe
------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cradle;
using IStoryThread = System.Collections.Generic.IEnumerable<Cradle.StoryOutput>;
using Cradle.StoryFormats.Harlowe;

public partial class @Dialogue_01: Cradle.StoryFormats.Harlowe.HarloweStory
{
	#region Variables
	// ---------------

	public class VarDefs: RuntimeVars
	{
		public VarDefs()
		{
		}

	}

	public new VarDefs Vars
	{
		get { return (VarDefs) base.Vars; }
	}

	// ---------------
	#endregion

	#region Initialization
	// ---------------

	public readonly Cradle.StoryFormats.Harlowe.HarloweRuntimeMacros macros1;

	@Dialogue_01()
	{
		this.StartPassage = "BulletHeadConversationOneStart";

		base.Vars = new VarDefs() { Story = this, StrictMode = true };

		macros1 = new Cradle.StoryFormats.Harlowe.HarloweRuntimeMacros() { Story = this };

		base.Init();
		passage1_Init();
		passage2_Init();
		passage3_Init();
		passage4_Init();
		passage5_Init();
		passage6_Init();
		passage7_Init();
		passage8_Init();
		passage9_Init();
	}

	// ---------------
	#endregion

	// .............
	// #1: BulletHeadConversationOneStart

	void passage1_Init()
	{
		this.Passages[@"BulletHeadConversationOneStart"] = new StoryPassage(@"BulletHeadConversationOneStart", new string[]{  }, passage1_Main);
	}

	IStoryThread passage1_Main()
	{
		yield return text("Ahhhh! Where...where am I? What is this?!?");
		yield return lineBreak();
		yield return lineBreak();
		yield return lineBreak();
		yield return link("Uh, you're like, the main character, or the narrator, or something, I guess...", "Narrator", null);
		yield return lineBreak();
		yield return link("You seem to be a video game character. With a bullet for a head.", "VideoGame", null);
		yield return lineBreak();
		yield return link("There's no need to swear.", "Swear", null);
		yield break;
	}


	// .............
	// #2: VideoGame

	void passage2_Init()
	{
		this.Passages[@"VideoGame"] = new StoryPassage(@"VideoGame", new string[]{  }, passage2_Main);
	}

	IStoryThread passage2_Main()
	{
		yield return text("Video game? What??? I just...");
		yield return lineBreak();
		yield return text("it was all dark...");
		yield return lineBreak();
		yield return text("and then, MONSTERS!");
		yield return lineBreak();
		yield return text("And now I'm...AND WHY IS MY HEAD A BULLET!!?");
		yield return lineBreak();
		yield return text("WHAT THE FUCK IS GOING ON HERE!?");
		yield return lineBreak();
		yield return lineBreak();
		yield return link("Yup, this is definitely a video game.", "VideoGame2", null);
		yield return text(" ");
		yield break;
	}


	// .............
	// #3: Swear

	void passage3_Init()
	{
		this.Passages[@"Swear"] = new StoryPassage(@"Swear", new string[]{  }, passage3_Main);
	}

	IStoryThread passage3_Main()
	{
		yield return text("I'll swear all I damn well please, fucker!");
		yield return lineBreak();
		yield return lineBreak();
		yield return link("Okay, but it doesn't seem to be getting you anywhere", "BulletHeadConversationOneStart", null);
		yield break;
	}


	// .............
	// #4: VideoGame2

	void passage4_Init()
	{
		this.Passages[@"VideoGame2"] = new StoryPassage(@"VideoGame2", new string[]{  }, passage4_Main);
	}

	IStoryThread passage4_Main()
	{
		yield return text("So I must have entered some kind of...");
		yield return lineBreak();
		yield return text("fughe state...and now I'm...Bullethead?");
		yield return lineBreak();
		yield return lineBreak();
		yield return link("Looks that way, yup", "Controls", null);
		yield break;
	}


	// .............
	// #5: Narrator

	void passage5_Init()
	{
		this.Passages[@"Narrator"] = new StoryPassage(@"Narrator", new string[]{  }, passage5_Main);
	}

	IStoryThread passage5_Main()
	{
		yield return text("Narrator? I just...it was all dark...");
		yield return lineBreak();
		yield return text("and then, MONSTERS!");
		yield return lineBreak();
		yield return text("And now I'm...");
		yield return lineBreak();
		yield return text("AND WHY IS MY HEAD A BULLET!!?");
		yield return lineBreak();
		yield return text("WHAT THE FUCK IS GOING ON HERE!?");
		yield return lineBreak();
		yield return lineBreak();
		yield return link("I'm not sure, I just started playing a moment ago.", "Narrator2", null);
		yield break;
	}


	// .............
	// #6: Narrator2

	void passage6_Init()
	{
		this.Passages[@"Narrator2"] = new StoryPassage(@"Narrator2", new string[]{  }, passage6_Main);
	}

	IStoryThread passage6_Main()
	{
		yield return text("How can I be the narrator of something");
		yield return lineBreak();
		yield return text("if I don't even know what it is?");
		yield return lineBreak();
		yield return lineBreak();
		yield return link("Your guess is as good as mine.", "Controls", null);
		yield break;
	}


	// .............
	// #7: Controls

	void passage7_Init()
	{
		this.Passages[@"Controls"] = new StoryPassage(@"Controls", new string[]{  }, passage7_Main);
	}

	IStoryThread passage7_Main()
	{
		yield return text("I don't know how I know this,");
		yield return lineBreak();
		yield return text("but you have to use WASD to move me.");
		yield return lineBreak();
		yield return text("And Space to jump.");
		yield return lineBreak();
		yield return text("Oh, and left clicking the mouse will fire a bullet.");
		yield return lineBreak();
		yield return text("Man...this is all too trippy, you gotta help me!");
		yield return lineBreak();
		yield return lineBreak();
		yield return link("Sure, I'll do my best", "EndDialogue1", null);
		yield break;
	}


	// .............
	// #8: EndDialogue1

	void passage8_Init()
	{
		this.Passages[@"EndDialogue1"] = new StoryPassage(@"EndDialogue1", new string[]{  }, passage8_Main);
	}

	IStoryThread passage8_Main()
	{
		yield return text("Well I suppose we better have a look around");
		yield return lineBreak();
		yield return text("if you're going to get me out of this.");
		yield return lineBreak();
		yield return lineBreak();
		yield return link("EndDialogue", "EndDialogue", null);
		yield break;
	}


	// .............
	// #9: EndDialogue

	void passage9_Init()
	{
		this.Passages[@"EndDialogue"] = new StoryPassage(@"EndDialogue", new string[]{  }, passage9_Main);
	}

	IStoryThread passage9_Main()
	{
		yield return text("Double-click this passage to edit it.");
		yield break;
	}


}