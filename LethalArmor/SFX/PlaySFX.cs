using LCSoundTool;
using System.IO;
using UnityEngine;

namespace LethalArmor.SFX
{
    internal class PlaySFX
    {
        private static AudioClip tankHitClip;
        private static readonly string soundPath = GetSoundFilePath();

        private static AudioClip armorBreakClip;
        private static string armorBreakPath = GetSoundFilePath();

        private static string GetSoundFilePath()
        {
            // Get the path of the currently executing assembly (your mod DLL)
            string dllDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Combine the DLL path with the relative path to the sound file
            return Path.Combine(dllDirectory, "SFX");
        }

        public static void play_tankHit()
        {
            if (tankHitClip == null)
            {
                tankHitClip = SoundTool.GetAudioClip(soundPath, "tankHit1.mp3");
            }
            SoundTool.ReplaceAudioClip("TakeDamage", tankHitClip);
        }

        public static void play_brokearmor()
        {
            if (armorBreakClip == null)
            {
                armorBreakClip = SoundTool.GetAudioClip(soundPath, "armorbreak.mp3");
            }
            SoundTool.ReplaceAudioClip("TakeDamage", armorBreakClip);
        }

        public static void restore_takedamage()
        {
            SoundTool.RestoreAudioClip("TakeDamage");
        }
    }
}
