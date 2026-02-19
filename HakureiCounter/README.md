# HakureiCounter

The HakureiCounter (named after Touhou Project character Reimu Hakurei) is a simple, lightweight C# program that reads and writes an integer to a text file.
It also features a customizable display that can be used as a source in broadcasting software such as Open Broadcaster Software.

## Why?

Other software I've used for this purpose are too bloated. They cover too many use cases or have more features than what I'd need - not necessarily a issue, but sometimes I want to be able to help others set up something like a death counter for their streams.

Rather than go through an entire process of navigating a bloated UI, they can now boot this up and immediately something with a single purpose with no other fluff.

## Features

- Read and write from a text file (automatically generates a subdirectory and example text file if they don't exist)
- Can change background, text colour, and font
- Can increment and decrement counter (which automatically writes to the text file)

## Coming soon

- Allow setting up a shortcut/hotkey to increment and decrement
- More text customization (?)

## Acknowledgements

The background colour selector is developed by Richard Moss from Cyotek [(Link to the blog post with details)](https://www.cyotek.com/blog/colorpicker-controls-for-windows-forms). Thanks!