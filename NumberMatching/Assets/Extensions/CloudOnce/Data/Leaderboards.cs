// <copyright file="Leaderboards.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// Provides access to leaderboards registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class Leaderboards
    {
        private static readonly UnifiedLeaderboard s_highScore = new UnifiedLeaderboard("HighScore",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkI1a-4sNcXEAIQAQ"
#else
            "HighScore"
#endif
            );

        public static UnifiedLeaderboard HighScore
        {
            get { return s_highScore; }
        }

        private static readonly UnifiedLeaderboard s_hardModeHighScore = new UnifiedLeaderboard("HardModeHighScore",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkI1a-4sNcXEAIQAw"
#else
            "HardModeHighScore"
#endif
            );

        public static UnifiedLeaderboard HardModeHighScore
        {
            get { return s_hardModeHighScore; }
        }

        public static string GetPlatformID(string internalId)
        {
            return s_leaderboardDictionary.ContainsKey(internalId)
                ? s_leaderboardDictionary[internalId].ID
                : string.Empty;
        }

        private static readonly Dictionary<string, UnifiedLeaderboard> s_leaderboardDictionary = new Dictionary<string, UnifiedLeaderboard>
        {
            { "HighScore", s_highScore },
            { "HardModeHighScore", s_hardModeHighScore },
        };
    }
}
