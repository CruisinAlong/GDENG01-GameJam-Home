using UnityEngine;
using System.Collections;

/*
 * Holder for event names
 * Created By: NeilDG
 */ 
public class EventNames {
	public const string ON_UPDATE_SCORE = "ON_UPDATE_SCORE";
	public const string ON_CORRECT_MATCH = "ON_CORRECT_MATCH";
	public const string ON_WRONG_MATCH = "ON_WRONG_MATCH";
	public const string ON_INCREASE_LEVEL = "ON_INCREASE_LEVEL";

	public const string ON_PICTURE_CLICKED = "ON_PICTURE_CLICKED";


	public class ARBluetoothEvents {
		public const string ON_START_BLUETOOTH_DEMO = "ON_START_BLUETOOTH_DEMO";
		public const string ON_RECEIVED_MESSAGE = "ON_RECEIVED_MESSAGE";
	}

	public class ARPhysicsEvents {
		public const string ON_FIRST_TARGET_SCAN = "ON_FIRST_TARGET_SCAN";
		public const string ON_FINAL_TARGET_SCAN = "ON_FINAL_TARGET_SCAN";
	}

	public class ExtendTrackEvents {
		public const string ON_TARGET_SCAN = "ON_TARGET_SCAN";
		public const string ON_TARGET_HIDE = "ON_TARGET_HIDE";
		public const string ON_SHOW_ALL = "ON_SHOW_ALL";
		public const string ON_HIDE_ALL = "ON_HIDE_ALL";
		public const string ON_DELETE_ALL = "ON_DELETE_ALL";
	}

	public class X01_Events {
		public const string ON_FIRST_SCAN = "ON_FIRST_SCAN";
		public const string ON_FINAL_SCAN = "ON_FINAL_SCAN";
		public const string EXTENDED_TRACK_ON_SCAN = "EXTENDED_TRACK_ON_SCAN";
		public const string EXTENDED_TRACK_REMOVED = "EXTENDED_TRACK_REMOVED";
	}

	public class X22_Events {
		public const string ON_FIRST_SCAN = "ON_FIRST_SCAN";
		public const string ON_FINAL_SCAN = "ON_FINAL_SCAN";
		public const string EXTENDED_TRACK_ON_SCAN = "EXTENDED_TRACK_ON_SCAN";
		public const string EXTENDED_TRACK_REMOVED = "EXTENDED_TRACK_REMOVED";
	}

	public class S18_Events {
		public const string ON_FIRST_SCAN = "FIRST_TARGET_SCAN";
		public const string ON_FINAL_SCAN = "ON_FINAL_SCAN";
	}

	public class PlayerMode
	{
		public const string MOP_MODE = "MOP_MODE";
		public const string BROOM_MODE = "BROOM_MODE";
		public const string VACUUM_MODE = "VACUUM_MODE";
        public const string MODE4 = "MODE4";
		public const string PAUSEMODE = "PAUSEMODE";
    }

	public class Clean_Events
	{
		public const string NUM_CLEANABLES_LEFT = "NUM_CLEANABLES_LEFT";
		public const string PARAM_CLEANABLES_LEFT = "PARAM_CLEANABLES_LEFT";
	}

	public class SFXNames
	{
		public const string BRUSH = "Brush";
		public const string CLICK = "Click";
		public const string MOP = "Mop";
		public const string ROOMBA = "Roomba";
		public const string SUCTION = "Suction";
		public const string WIN = "Win";
		public const string BG_CONVERSATION = "Conversation_BG";
		public const string BG_CHEER = "Cheer_BG";
		public const string BG_LAUGHING = "Laughing_BG";
		public const string BG_TV = "TV_BG";
		public const string BG_WHISTLE = "Whistle_BG";
        public const string BG_DINNER = "Dinner_BG";
		public const string BG_PLAYING = "Playing_BG";
		public const string BG_PLAYING2 = "Playing2_BG";
		public const string BG_PLAYING3 = "Playing3_BG";
		public const string BG_NIGHTTIME = "Nighttime_BG";

        public const string STOP_BG = "STOP_BG";
		
	}
}







