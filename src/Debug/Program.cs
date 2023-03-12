using System;
using System.IO;
using System.Reflection;
using TagLib;
using File = System.IO.File;

namespace Debug
{
	/// <summary>
	/// Stub program to debug some scenarios. Modify it as you need, this is not meant to be reuseable program.
	/// </summary>
	class Program
	{
		static readonly string AssemblyLocation = Path.GetDirectoryName (Assembly.GetAssembly (typeof (Program)).Location);
		public static readonly string Samples = Path.Combine (AssemblyLocation, "..", "..", "..", "..", "TaglibSharp.Tests", "samples");

		/// <summary>
		/// Ouput message on the console and on the Visual Studio Output
		/// </summary>
		/// <param name="str"></param>
		static void Log (string str)
		{
			Console.WriteLine (str);
			System.Diagnostics.Debug.WriteLine (str);
		}

		/// <summary>
		/// Tags the mp3 based on the number before the file ex. Num - file.mp3
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <param name="dir"></param>
		static void TagMP3(uint start, uint end, string dir)
		{
			uint n = start;

			while (n < end + 1) {
				var path = Directory.GetFiles (@dir, n + " - *.mp3");
				if (path.Length == 0) {
					Log ("Tag Error: " + dir + n + " - *.mp3 cannot be found");
					break;
				}
				foreach (var file in path) {
					{
						TagLib.File f = TagLib.File.Create (file);
						f.Tag.Track = n;
						f.Save ();
						n++;
					}
				}

			}
			
		}
		/// <summary>
		/// Tags all files with one tag number
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <param name="tagNumber"></param>
		/// <param name="dir"></param>
		static void TagZero (uint start, uint end, uint tagNumber, string dir)
		{
			uint n = start;

			while (n < end + 1) {
				var path = Directory.GetFiles (@dir, n + " - *.mp3");
				if (path.Length == 0) {
					Log ("Tag Error: " + dir + n + " - *.mp3 cannot be found");
					break;
				}
				foreach (var file in path) {
					{
						TagLib.File f = TagLib.File.Create (file);
						f.Tag.Track = tagNumber;
						f.Save ();
						n++;
					}
				}

			}

		}

		static void Albuming (uint start, uint end, string AlName, string dir)
		{
			uint n = start;

			while (n < end + 1) {
				var path = Directory.GetFiles (@dir, n + " - *.mp3");
				if (path.Length == 0) {
					Log ("Tag Error: " + dir + n + " - *.mp3 cannot be found");
					break;
				}
				foreach (var file in path) {
					{
						TagLib.File f = TagLib.File.Create (file);
						f.Tag.Album = AlName;
						f.Save ();
						n++;
					}
				}

			}

		}

		/// <summary>
		/// Very volitile, will alter the name of the mp3 file based on the start index, end index and new start index
		/// Do not use unless you know exactly what the function does, your files will disapear if you execute it wrong
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <param name="startNew"></param>
		/// <param name="dir"></param>
		static void AlterNameEnd(uint start, uint end, uint startNew, string dir)
		{
			uint n = end;
			uint diff = startNew - start;
			
			while (n + 1 > start) {
				var path = Directory.GetFiles (@dir, n + " - *.mp3");
				if (path.Length == 0) {
					Log ("AlterName Error: " + dir + n + " - *.mp3 cannot be found");
					break;
				}
				foreach (var file in path) {
					{
						//change file to new file name
						var newFile = file;
						string[] splited = newFile.Split (new[] { '-' }, 2);
						newFile = dir + (n + diff) + " -" + splited[1];
						System.IO.File.Move (file, newFile);
						n--;
					}
				}

			}
			
		}

		/// <summary>
		/// Very volitile, will alter the name of the mp3 file based on the start index, end index and new start index
		/// Do not use unless you know exactly what the function does, your files will disapear if you execute it wrong
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <param name="startNew"></param>
		/// <param name="dir"></param>
		static void AlterNameStart (uint start, uint end, uint startNew, string dir)
		{
			uint n = start;
			int diff = (int)startNew - (int)start;

			while (n < end + 1) {
				var path = Directory.GetFiles (@dir, n + " - *.mp3");
				if (path.Length == 0) {
					Log ("AlterName Error: " + dir + n + " - *.mp3 cannot be found");
					break;
				}
				foreach (var file in path) {
					{
						//change file to new file name
						var newFile = file;
						string[] splited = newFile.Split (new[] { '-' }, 2);
						newFile = dir + (n + diff) + " -" + splited[1];
						System.IO.File.Move (file, newFile);
						n++;
					}
				}

			}

		}

		/// <summary>
		/// Detects for duplicated numbers in the file name where num = the num of (num - file.mp3)
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <param name="dir"></param>
		static void DupeDetection(uint start, uint end, string dir)
		{
			uint n = start;
			while (n < end + 1) {
				var path = Directory.GetFiles (@dir, n + " - *.mp3");
				if (path.Length == 0) {
					Log ("Dupe Detection: You are missing" + dir + n + " - *.mp3");
				}
				if (path.Length > 1) {
					Log ("Dupe Detection: You have a Dupe at " + n + " with " + path.Length + " occurrences");
				}
				n++;
			}
		}


		static void FucingStupidMusicApps (uint start, uint end, string dir)
		{
			uint n = start;
			string[] alph = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
			while (n < end + 1) {
				var path = Directory.GetFiles (@dir, n + " - *.mp3");
				if (path.Length == 0) {
					Log ("Tag Error: " + dir + n + " - *.mp3 cannot be found");
					break;
				}
				foreach (var file in path) {
					{
						TagLib.File f = TagLib.File.Create (file);
						int temp = ((int)n)-1;
						string name = "";
						while (temp > 25) {
							temp -= 26;
							name += alph[25];
						}
						name += alph[temp];
						f.Tag.Album = name;
						f.Save ();
						n++;
					}
				}

			}

		}
		static void Main (string[] args)
		{
			//Log ("--------------------");
			//Log ("* Start : Samples directory: " + Samples);
			//Log ("");

			//uint start = 276;
			//uint newStart = start + 1;
			//string dir = "D:\\MediaHuman\\Nightcore Corporation ©\\";
			//TagZero (0, 1, 0, dir);
			

			string test = "C:\\Users\\georg_d9nxt11\\Desktop\\Test\\";
			FucingStupidMusicApps (1, 100, test);
			
			/*
			// Override command arguments
			args = new[] { "sample.wav" };

			foreach (var fname in args) {
				var fpath = Samples + fname;
				var tpath = Samples + "tmpwrite" + Path.GetExtension (fname);

				Log ("+ File  : " + fpath);
				if (!File.Exists (fpath)) {
					Log ("  # File not found: " + fpath);
					continue;
				}

				Log ("  read  : " + fpath);
				var rfile = TagLib.File.Create (fpath);
				Log ("  Type  : " + rfile.MimeType);

				File.Copy (fpath, tpath, true);

				var file = TagLib.File.Create (tpath);
				Log ("  Type  : " + file.MimeType);

				Log ("  rboy1 test start  : " + file.MimeType);

				var MKVTag = (TagLib.Matroska.Tag)file.GetTag (TagTypes.Matroska);
				MKVTag.Title = "my Title";
				MKVTag.Set ("SUBTITLE", null, "my SubTitle");
				MKVTag.Set ("DESCRIPTION", null, "my Description");
				MKVTag.Set ("TVCHANNEL", null, "my Network");
				MKVTag.Set ("LAW_RATING", null, "my Rating");
				MKVTag.Set ("ACTOR", null, "my MediaCredits");
				MKVTag.Set ("GENRE", null, "my Genres");
				MKVTag.Set ("SEASON", null, "my Season");
				MKVTag.Set ("EPISODE", null, "my Episode");

				var bannerFile = Samples + "sample_invalidifdoffset.jpg";
				var videoPicture = new Picture (bannerFile);
				MKVTag.Pictures = new IPicture[] { videoPicture };

				Log ("  rboy1 test save  : " + file.MimeType);
				file.Save ();

				Log ("  rboy1 test read  : " + file.MimeType);
				var tagFile = TagLib.File.Create (tpath);

				Log ("  rboy1 test end  : " + file.MimeType);

				var tag = file.Tag;
				var pics = file.Tag.Pictures;

				var mtag = (TagLib.Matroska.Tag)file.GetTag (TagTypes.Matroska);
				mtag.PerformersRole = new[] { "TEST role 1", "TEST role 2" };

				Log ("    Picture            : " + pics[0].Description);

				var tracks = mtag.Tags.Tracks;
				var audiotag = mtag.Tags.Get (tracks[1]);
				if (audiotag != null) {
					audiotag.Clear ();
					audiotag.Title = "The Noise";
					audiotag.Set ("DESCRIPTION", null, "Useless background noise");
				}

				Log ("  Erase : " + tag.Title);
				file.RemoveTags (TagTypes.Matroska);
				file.Save ();

				Log ("  Write : " + tag.Title);

				tag.TitleSort = "title, TEST";
				tag.AlbumSort = "album, TEST";
				tag.PerformersSort = new[] { "performer 1, TEST", "performer 2, TEST" };
				tag.ComposersSort = new[] { "composer 1, TEST", "composer 2, TEST" };
				tag.AlbumArtistsSort = new[] { "album artist 1, TEST", "album artist 2, TEST" };


				tag.Album = "TEST album";
				tag.AlbumArtists = new[] { "TEST album artist 1", "TEST album artist 2" };
				tag.BeatsPerMinute = 120;
				tag.Comment = "TEST comment";
				tag.Composers = new[] { "TEST composer 1", "TEST composer 2" };
				tag.Conductor = "TEST conductor";
				tag.Copyright = "TEST copyright";
				tag.Disc = 1;
				tag.DiscCount = 2;
				tag.Genres = new[] { "TEST genre 1", "TEST genre 2" };
				tag.Grouping = "TEST grouping";
				tag.Lyrics = "TEST lyrics 1\r\nTEST lyrics 2";
				tag.Performers = new[] { "TEST performer 1", "TEST performer 2" };
				tag.Title = "TEST title";
				tag.Track = 5;
				tag.TrackCount = 10;
				tag.Year = 1999;

				// Insert new picture
				Array.Resize (ref pics, 2);
				pics[1] = new Picture (Samples + "sample_sony2.jpg");
				file.Tag.Pictures = pics;

				file.Save ();


				Log ("  Done  : " + tag.Title);

				// Now read it again
				file = TagLib.File.Create (tpath);
				tag = file.Tag;
				mtag = (TagLib.Matroska.Tag)file.GetTag (TagTypes.Matroska);

				Log ("  Read  : " + tag.Title);

				Log ("    Album              : " + tag.Album);
				Log ("    JoinedAlbumArtists : " + tag.JoinedAlbumArtists);
				Log ("    BeatsPerMinute     : " + tag.BeatsPerMinute);
				Log ("    Comment            : " + tag.Comment);
				Log ("    JoinedComposers    : " + tag.JoinedComposers);
				Log ("    Conductor          : " + tag.Conductor);
				Log ("    Copyright          : " + tag.Copyright);
				Log ("    Disc               : " + tag.Disc);
				Log ("    DiscCount          : " + tag.DiscCount);
				Log ("    JoinedGenres       : " + tag.JoinedGenres);
				Log ("    Grouping           : " + tag.Grouping);
				Log ("    Lyrics             : " + tag.Lyrics);
				Log ("    JoinedPerformers   : " + tag.JoinedPerformers);
				Log ("    Title              : " + tag.Title);
				Log ("    Track              : " + tag.Track);
				Log ("    TrackCount         : " + tag.TrackCount);
				Log ("    Year               : " + tag.Year);

				Log ("    TitleSort          : " + tag.TitleSort);
				Log ("    AlbumSort          : " + tag.AlbumSort);
				Log ("    PerformersSort     : " + tag.JoinedPerformersSort);
				Log ("    ComposersSort      : " + string.Join ("; ", tag.ComposersSort));
				Log ("    AlbumArtistsSort   : " + string.Join ("; ", tag.AlbumArtistsSort));


				Log ("    PerformersRole     : " + string.Join ("; ", mtag.PerformersRole));

				Log ("  Done  : " + tag.Title);
			}

			Log ("* End");*/
		}
	}
}
