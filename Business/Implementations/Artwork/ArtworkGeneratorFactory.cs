using System;

public enum ArtworkStyle {
    SquareCollage
}

public class ArtworkGeneratorFactory {
    public static IArtworkGenerator Create(ArtworkStyle style) {
        switch(style) {
            case ArtworkStyle.SquareCollage: {
                return new SquareCollageArtworkGenerator();
            }
        }

        throw new ApplicationException("Unknown artwork style provided.");
    }
}