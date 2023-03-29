﻿namespace Player
{
    public interface IEntityInputSource
    {
        float HorizontalDirection { get; }

        bool Jump { get; }

        void ResetOneTimeActions();
    }
}