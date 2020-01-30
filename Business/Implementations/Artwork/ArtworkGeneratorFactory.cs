using System;
using ListeningHabitsArtworkGenerator.Business.Contracts.Artwork;

public enum ArtworkStyle
{
    SquareCollage
}

namespace ListeningHabitsArtworkGenerator.Business.Implementations.Artwork
{
    public class ArtworkGeneratorFactory
    {
        public static IArtworkGenerator Create(ArtworkStyle style)
        {
            switch (style)
            {
                case ArtworkStyle.SquareCollage:
                    {
                        return new SquareCollageArtworkGenerator();
                    }
            }

            throw new ApplicationException("Unknown artwork style provided.");
        }
    }
}
