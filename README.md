# LastFM Artwork Generator

This simple command line tool can create an album collage of your last.fm tracked listening habits.

Currently only a 3x3 square image of top albums is supported.

## Usage

Run from the command line. The first argument is the username to create the artwork for. The optional
second argument decides the period of the top albums. Possible values:

* OneMonth
* ThreeMonths
* SixMonths
* OneYear (default)
* AllTime

The collage is always written to "output.png" in the active directory.

## Why?

After not having used C# for nine years I wanted to take a look at .NET Core and current C# tools.
